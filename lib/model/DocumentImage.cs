namespace br.dev.optimus.hermes.lib.model
{
    public class DocumentImage
    {
        public ulong Id { get; set; }
        public string? DocumentId { get; set; }
        public string Disk { get; set; } = "s3";
        public string? Filename { get; set; }
        public uint Pages { get; set; }
        public ulong CreatedAt { get; set; }
        public ulong UpdatedAt { get; set; }
        public ErrorReply? Error { get; set; }
    }
}