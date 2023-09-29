using System.Collections.Generic;
using Wbc.Application.MenuResource.Commands.UpdateResourceArea;
using Wbc.Application.MenuResource.Query.GetTopResource;

namespace Wbc.Application.MenuResource.Query.GetResourceArea
{
    public class ResourceAreaVm
    {
        public IEnumerable<TopResourceDto> ResourceHeaders { get; set; }
        public UpdateResourceAreaCommand UpdateCommand { get; set; }
    }
}
