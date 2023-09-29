using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Wbc.Application.Common.Interfaces
{
    public interface ILongRunningTaskChannel
    {
        Task<bool> AddFileAsync(int fileId, CancellationToken ct = default);
        IAsyncEnumerable<int> ReadAllAsync(CancellationToken ct = default);
    }
}
