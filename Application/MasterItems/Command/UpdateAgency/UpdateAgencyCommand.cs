using Application.MasterItems.Query.GetAgency;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Configuration;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Command.UpdateAgency
{
    public class UpdateAgencyCommand : IRequest<Unit>
    {
        public AgencyVm AgencyVm { get; set; }
    }

    public class UpdateAgencyCommandHandler : IRequestHandler<UpdateAgencyCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly AdminConfiguration _adminConfiguration;


        public UpdateAgencyCommandHandler(IApplicationDbContext context, AdminConfiguration adminConfiguration)
        {
            _context = context;
            _adminConfiguration = adminConfiguration;
        }

        public async Task<Unit> Handle(UpdateAgencyCommand request, CancellationToken cancellationToken)
        {
            var agencyVm = request.AgencyVm.AgencyDto;

            //Uplaod Submitted Logo
            var fileUploadModel = request.AgencyVm.LogoUploaded;
            var uploadResult = await fileUploadModel.UploadFile(_adminConfiguration.DocumentRepoUrl, cancellationToken);
            fileUploadModel.ContentType = uploadResult.ContentType;
            fileUploadModel.UniqueFileName = uploadResult.UniqueFileName;

            var entity = await _context.Agencies.FindAsync(request.AgencyVm.AgencyDto.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Agency), request.AgencyVm.AgencyDto.Id);
            }

            entity.AgencyName = agencyVm.AgencyName;
            entity.AgencyCode = agencyVm.AgencyCode;
            entity.logo = fileUploadModel.UniqueFileName;
            entity.Description = agencyVm.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }



}
