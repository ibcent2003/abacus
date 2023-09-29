using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Application.MasterItems.Query.GetVehicleModel
{
    public class GetVehicleModelList : IRequest<IList<VehicleModel>>
    {
        //public int MakeId { get; set; }
    }
    public class GetDocumentListHandler : IRequestHandler<GetVehicleModelList, IList<VehicleModel>>
    {
        private readonly IApplicationDbContext _context;


        public GetDocumentListHandler(IApplicationDbContext context)
        {
            this._context = context;

        }

        public async Task<IList<VehicleModel>> Handle(GetVehicleModelList request, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.VehicleModels.Where(x => x.IsActive == true).ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

        }
    }
}
