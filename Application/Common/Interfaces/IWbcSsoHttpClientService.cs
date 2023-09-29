using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace Wbc.Application.Common.Interfaces
{
    public interface IWbcSsoHttpClientService
    {
        Task<HttpClient> GetHttpClientWithAccessToken(string scope, CancellationToken cancellationToken);
        Task<T> PostWithTokenAsync<T>(IPayLoadObject obj, string scope, string postUrl, CancellationToken cancellationToken) where T : IPayLoadObject;
        Task<HttpResponseMessage> PostWithTokenAsync(IPayLoadObject obj, string scope, string postUrl, CancellationToken cancellationToken);
        Task<T> GetWithTokenAsync<T>(string scope, string getUrl, CancellationToken cancellationToken) where T : IPayLoadObject;
        Task<UserInfoResponse> GetUserInfoAsync(string scope, CancellationToken cancellationToken);
        Task<DiscoveryDocumentResponse> GetDiscoveryDocumentAsync(CancellationToken cancellationToken);



    }
}
