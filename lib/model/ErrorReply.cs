using Grpc.Core;

namespace br.dev.optimus.hermes.lib.model
{
    public class ErrorReply
    {
        public StatusCode Code { get; set; } = StatusCode.Unknown;
        public string? Error { get; set; }
    }
}