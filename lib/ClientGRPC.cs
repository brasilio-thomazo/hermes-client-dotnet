namespace br.dev.optimus.hermes.lib;

using br.dev.optimus.hermes.grpc;
using br.dev.optimus.hermes.lib.model;
using Grpc.Core;
using static br.dev.optimus.hermes.grpc.Hermes;

public class ClientGRPC
{
    private readonly HermesClient client;

    public ClientGRPC(string host, int port)
    {
        var channel = new Channel(host, port, ChannelCredentials.Insecure);
        client = new HermesClient(channel);
    }

    public ClientGRPC(string host, int port, string username, string password)
    {
        var channel = new Channel(host, port, ChannelCredentials.Insecure);
        client = new HermesClient(channel);
    }

    public async Task<IEnumerable<DocumentType>?> GetDocumentTypesAsync()
    {
        var reply = await client.DocumentTypeListAsync(new ListRequest());
        if (reply == null)
        {
            return null;
        }

        return reply.List.Select(t => new DocumentType
        {
            Id = t.Id,
            Name = t.Name,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt
        });
    }

    public async Task<IEnumerable<Department>?> GetDepartmentsAsync()
    {
        var reply = await client.DepartmentListAsync(new ListRequest());
        if (reply == null)
        {
            return null;
        }

        return reply.List.Select(t => new Department
        {
            Id = t.Id,
            Name = t.Name,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt
        });
    }

    public async Task<Document?> StoreDocument(Document document)
    {
        var request = new DocumentRequest()
        {
            DepartmentId = document.DepartmentId,
            DocumentTypeId = document.DocumentTypeId,
            Code = document.Code,
            Identity = document.Identity,
            Name = document.Name,
            DateDocument = document.DateDocument,
        };
        var reply = await client.DocumentStoreAsync(request);
        if (reply == null)
        {
            return null;
        }
        document.Id = reply.Id;
        document.CreatedAt = reply.CreatedAt;
        document.UpdatedAt = reply.UpdatedAt;
        return document;
    }
}
