using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json;
using Wbc.Application.Common.Configuration;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Infrastructure.Services
{
    public class WbcSsoHttpClientService : IWbcSsoHttpClientService
    {
        private readonly AdminConfiguration _configuration;
        private readonly HttpClient _client;

        public WbcSsoHttpClientService(AdminConfiguration configuration, HttpClient client)
        {
            _configuration = configuration;
            _client = client;
        }

        public async Task<DiscoveryDocumentResponse> GetDiscoveryDocumentAsync(CancellationToken cancellationToken)
        {
            var discoveryDocument = await _client.GetDiscoveryDocumentAsync(_configuration.AuthenticationBaseUrl, cancellationToken);

            if (discoveryDocument.IsError) throw new HttpRequestException(discoveryDocument.Error);

            return discoveryDocument;
        }

        private async Task<TokenResponse> GetAccessToken(string scope, CancellationToken cancellationToken)
        {
            var disc = await GetDiscoveryDocumentAsync(cancellationToken);

            var tokenResponse = await _client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disc.TokenEndpoint,
                ClientId = _configuration.ClientId,
                ClientSecret = _configuration.ClientSecret,
                Scope = scope

            }, cancellationToken);

            if (tokenResponse.IsError) throw new HttpRequestException(tokenResponse.Error);

            return tokenResponse;
        }

        public async Task<UserInfoResponse> GetUserInfoAsync(string accessToken, CancellationToken cancellationToken)
        {
            var disc = await GetDiscoveryDocumentAsync(cancellationToken);

            var response = await _client.GetUserInfoAsync(new UserInfoRequest
            {
                Address = disc.UserInfoEndpoint,
                Token = accessToken

            }, cancellationToken);

            if (response.IsError) throw new Exception(response.Error);

            return response;
        }

        public async Task<HttpClient> GetHttpClientWithAccessToken(string scope, CancellationToken cancellationToken)
        {

            var tokenResponse = await GetAccessToken(scope, cancellationToken);

            _client.SetBearerToken(tokenResponse.AccessToken);

            return _client;

        }

        public async Task<T> PostWithTokenAsync<T>(IPayLoadObject obj, string scope, string postUrl, CancellationToken cancellationToken) where T : IPayLoadObject
        {

            var response = await PostWithTokenAsync(obj, scope, postUrl, cancellationToken);

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);

        }

        public async Task<HttpResponseMessage> PostWithTokenAsync(IPayLoadObject obj, string scope, string postUrl, CancellationToken cancellationToken)
        {

            var client = await GetHttpClientWithAccessToken(scope, cancellationToken);

            var response = await client.PostAsJsonAsync(postUrl, obj, cancellationToken);

            if (!response.IsSuccessStatusCode) throw new HttpRequestException(response.StatusCode.ToString());

            return response;
        }

        public async Task<T> GetWithTokenAsync<T>(string scope, string getUrl, CancellationToken cancellationToken) where T : IPayLoadObject
        {

            var client = await GetHttpClientWithAccessToken(scope, cancellationToken);

            var response = await client.GetAsync(getUrl, cancellationToken);

            if (!response.IsSuccessStatusCode) throw new HttpRequestException(response.StatusCode.ToString());

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);

        }

    }
}
