namespace br.dev.optimus.hermes.app;
internal class ImageStore : ITask
{
    private readonly QueueStatus status;

    public ImageStore(QueueStatus status)
    {
        this.status = status;
    }

    public async Task RunAsync()
    {
        status.Running++;
        Console.WriteLine("image::store");
        status.Running--;
        status.Completed++;
        await Task.CompletedTask;
    }
}