using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Wbc.Application.Common.Interfaces;

namespace Wbc.WebUI.Services
{

    public class LongRunningTaskChannel : ILongRunningTaskChannel
    {
        private const int MaxMessageInChannel = 100;
        private readonly Channel<int> _channel;
        private readonly ILogger<LongRunningTaskChannel> _logger;
        public LongRunningTaskChannel(ILogger<LongRunningTaskChannel> logger)
        {
            var options = new BoundedChannelOptions(MaxMessageInChannel)
            {
                SingleWriter = false,
                SingleReader = true
            };

            _logger = logger;
            _channel = Channel.CreateBounded<int>(options);
        }

        public async Task<bool> AddFileAsync(int fileId, CancellationToken ct = default)
        {
            while (await _channel.Writer.WaitToWriteAsync(ct) && !ct.IsCancellationRequested)
            {
                if (_channel.Writer.TryWrite(fileId))
                {
                    Log.ChannelMessageWritten(_logger, fileId);

                    return true;
                }
            }

            return false;
        }

        public IAsyncEnumerable<int> ReadAllAsync(CancellationToken ct = default) => _channel.Reader.ReadAllAsync(ct);

        internal static class EventIds
        {
            public static readonly EventId ChannelMessageWritten = new EventId(100, "ChannelMessageWritten");
        }

        private static class Log
        {
            private static readonly Action<ILogger, int, Exception> _channelMessageWritten = LoggerMessage.Define<int>(LogLevel.Information, EventIds.ChannelMessageWritten, "Filename {FileName} was written to the channel.");

            public static void ChannelMessageWritten(ILogger logger, int fileId)
            {
                _channelMessageWritten(logger, fileId, null);
            }
        }
    }
}
