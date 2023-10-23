namespace br.dev.optimus.hermes.app;

internal class DocumentSave : ITask
{
    private readonly QueueStatus status;

    public DocumentSave(QueueStatus status)
    {
        this.status = status;
    }

    public async Task RunAsync()
    {
        Console.WriteLine("document::save");
        await Task.Delay(1000);
        status.Running--;
        status.Completed++;
    }
}