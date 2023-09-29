using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wbc.Application.Common.Configuration;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;
using Wbc.Domain.Entities;

namespace Wbc.Application.Subscription.Command.AddSubscriber
{
    public class AddSubscriberCommand : IRequest<int>, IPayLoadObject
    {
        public AddSubscriberCommand()
        {
            DocumentsUploaded = new List<FileUploadModel>();
        }

        public string AdminEmailAddress { get; set; }
        public string AdminPhoneNumber { get; set; }
        public string City { get; set; }
        public string ConfirmPassword { get; set; }
        public string CountryCode { get; set; }
        public List<FileUploadModel> DocumentsUploaded { get; set; }
        public string EmailAddress { get; set; }
        public string EntityName { get; set; }
        public string FaxNumber { get; set; }
        public string FirstName { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string PostCode { get; set; }
        public string StreetNumber { get; set; }
        public string Tin { get; set; }
        public string ProcessCode { get; set; }
    }

    public class AddSubscriberCommandHandler : IRequestHandler<AddSubscriberCommand, int>
    {
        private readonly AdminConfiguration _adminConfiguration;
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;
        private readonly ILongRunningTaskChannel _longRunningTaskChannel;
        public AddSubscriberCommandHandler(AdminConfiguration adminConfiguration, IApplicationDbContext context, IDateTime dateTime, ILongRunningTaskChannel longRunningTaskChannel)
        {
            _adminConfiguration = adminConfiguration;
            _context = context;
            _dateTime = dateTime;
            _longRunningTaskChannel = longRunningTaskChannel;
        }


        public async Task<int> Handle(AddSubscriberCommand request, CancellationToken cancellationToken)
        {

            //Upload All Supporting Documents
            if (request.DocumentsUploaded.Any())

                foreach (var fileUploadModel in request.DocumentsUploaded)
                {
                    var uploadFolder = Path.Combine(_adminConfiguration.DocumentRepoUrl, fileUploadModel.FileName);

                    var uniqueFileName = Guid.NewGuid() + Path.GetExtension(fileUploadModel.FormFile.FileName);

                    var filePath = Path.Combine(uploadFolder, uniqueFileName);

                    if (!Directory.Exists(uploadFolder)) Directory.CreateDirectory(uploadFolder);

                    await fileUploadModel.FormFile.CopyToAsync(new FileStream(filePath, FileMode.Create), cancellationToken);

                    fileUploadModel.ContentType = fileUploadModel.FormFile.ContentType;

                    fileUploadModel.UniqueFileName = uniqueFileName;
                }

            var obj = new LongRunningRequestTemp
            {
                JsonContent = request.Serialize(),
                CreatedOn = _dateTime.Now,
                IsProcessed = false,
                ProcessCode = request.ProcessCode
            };

            _context.LongRunningRequestTemps.Add(obj);

            var result = await _context.SaveChangesAsync(cancellationToken);

            await _longRunningTaskChannel.AddFileAsync(obj.Id, cancellationToken);

            return result;
        }
    }
}