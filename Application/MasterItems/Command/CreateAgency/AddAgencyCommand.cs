using Application.MasterItems.Query.GetAgency;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Configuration;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Command.CreateAgency
{
    public class AddAgencyCommand : IRequest<int>
    {
        public AgencyVm AgencyVm { get; set; }
    }

    public class AddAgencyCommandHandler : IRequestHandler<AddAgencyCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly AdminConfiguration _adminConfiguration;


        public AddAgencyCommandHandler(IApplicationDbContext context, AdminConfiguration adminConfiguration)
        {
            _context = context;
            _adminConfiguration = adminConfiguration;
        }

        public async Task<int> Handle(AddAgencyCommand request, CancellationToken cancellationToken)
        {
            var agencyVm = request.AgencyVm.AgencyDto;

            //Uplaod Submitted Logo
            var fileUploadModel = request.AgencyVm.LogoUploaded;
            var uploadResult = await fileUploadModel.UploadFile(_adminConfiguration.DocumentRepoUrl, cancellationToken);
            fileUploadModel.ContentType = uploadResult.ContentType;
            fileUploadModel.UniqueFileName = uploadResult.UniqueFileName;

            var entity = new Agency
            {
                AgencyName = agencyVm.AgencyName,
                AgencyCode = agencyVm.AgencyCode,
                Description = agencyVm.Description,
                logo = fileUploadModel.UniqueFileName,
                IsActive= true

            };

            _context.Agencies.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
