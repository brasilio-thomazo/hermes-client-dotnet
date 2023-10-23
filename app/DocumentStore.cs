namespace br.dev.optimus.hermes.app
{
    internal class DocumentStore : ITask
    {
        private readonly QueueStatus status;
        private readonly Queue<ITask> queues;


        public DocumentStore(Queue<ITask> queues, QueueStatus status)
        {
            this.queues = queues;
            this.status = status;
        }

        public async Task RunAsync()
        {
            status.Running++;
            Console.WriteLine("document::store");
            queues.Enqueue(new ImageStore(status));
            status.Running--;
            status.Completed++;
            await Task.CompletedTask;
        }
    }
}