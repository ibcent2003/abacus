namespace Wbc.Domain.Entities
{
    public class ProcessSubmittedDocument
    {
        public int Id { get; set; }
        public int DocumentOwnerId { get; set; }
        public int ProcessRequiredDocumentId { get; set; }
        public ProcessRequiredDocument ProcessRequiredDocument { get; set; }
        public string DocumentUrl { get; set; }
        public string DocumentExtension { get; set; }
        public string DocumentName { get; set; }
    }
}
