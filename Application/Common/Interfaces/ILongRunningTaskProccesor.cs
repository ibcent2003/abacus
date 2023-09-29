using System.Threading;
using System.Threading.Tasks;

namespace Wbc.Application.Common.Interfaces
{
    public interface ILongRunningTaskProccesor
    {
        Task ProcessFile(int fileId, CancellationToken cancellationToken);
    }
}
