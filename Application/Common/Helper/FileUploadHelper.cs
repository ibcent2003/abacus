using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Models;

namespace Wbc.Application.Common.Helper
{
    public static class FileUploadHelper
    {
        public static async Task<FileUploadResultModel> UploadFile(this FileUploadModel file, string repoPath, CancellationToken cancellationToken)
        {
            try
            {
                var uploadFolder = Path.Combine(repoPath, file.FileName);

                var uniqueFileName = Guid.NewGuid() + Path.GetExtension(file.FormFile.FileName);

                var filePath = Path.Combine(uploadFolder, uniqueFileName);

                if (!Directory.Exists(uploadFolder)) Directory.CreateDirectory(uploadFolder);

                await using var writer = new FileStream(filePath, FileMode.Create);

                await file.FormFile.CopyToAsync(writer, cancellationToken);

                return new FileUploadResultModel
                {
                    IsSuccessful = true,
                    UniqueFileName = uniqueFileName,
                    ContentType = file.FormFile.ContentType,
                    FullPath = filePath
                };
            }
            catch (Exception e)
            {
                return new FileUploadResultModel
                {
                    IsSuccessful = false,
                    ErrorMsg = e.Message
                };
            }


        }
    }
}
