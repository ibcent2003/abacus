namespace Wbc.Application.Common.Models
{
    public class FileUploadResultModel
    {
        public string UniqueFileName { get; set; }
        public string ContentType { get; set; }
        public bool IsSuccessful { get; set; }
        public string ErrorMsg { get; set; }
        public string FullPath { get; set; }
    }
}
