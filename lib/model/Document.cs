namespace br.dev.optimus.hermes.lib.model
{
    public class Document
    {
        public string? Id { get; set; }
        public ulong DocumentTypeId { get; set; }
        public ulong DepartmentId { get; set; }
        public string Code { get; set; } = "";
        public string Identity { get; set; } = "";
        public string Name { get; set; } = "";
        public string? Comment { get; set; }
        public string? Storage { get; set; }
        public string? DateDocument { get; set; }
        public ulong CreatedAt { get; set; }
        public ulong UpdatedAt { get; set; }
        public DocumentImage? Image { get; set; }
        public List<DocumentFile>? Files { get; set; }
        public ErrorReply? Error { get; set; }
    }
}