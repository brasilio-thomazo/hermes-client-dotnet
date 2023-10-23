namespace br.dev.optimus.hermes.lib.model
{
    public class DocumentFile
    {
        public string? Path { get; set; }
        public string? File { get; set; }
        public uint Page { get; set; }
        public string? Error { get; set; }
    }
}