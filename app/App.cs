using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace br.dev.optimus.hermes.app
{
    internal class App : BackgroundService
    {
        private readonly ILogger<App> _logger;
        private readonly IConfiguration _config;
        private readonly Queue<ITask> queues = new();
        private readonly Stack<ITask> stacks = new();
        private readonly QueueStatus status = new();

        public App(ILogger<App> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        protected override async Task ExecuteAsync(CancellationToken token)
        {
            var maxThreads = Environment.ProcessorCount / 2;
            var options = new ParallelOptions { MaxDegreeOfParallelism = maxThreads, CancellationToken = token };

            for (int i = 0; i < 20; i++)
            {
                var store = new DocumentStore(queues, status);
                queues.Enqueue(store);
            }

            while (!token.IsCancellationRequested)
            {
                if (queues.Count > 0)
                {
                    var actions = new List<ITask>(queues.Count);
                    while (queues.Count != 0)
                    {
                        status.Total++;
                        actions.Add(queues.Dequeue());
                    }
                    await Parallel.ForEachAsync(actions, options, async (action, cancelToken) => await action.RunAsync());
                    continue;
                }

                if (stacks.Count > 0 && status.Running == 0)
                {
                    var actions = new List<ITask>(stacks.Count);
                    while (stacks.Count != 0)
                    {
                        actions.Add(stacks.Pop());
                    }
                    await Parallel.ForEachAsync(actions, options, async (action, cancelToken) => await action.RunAsync());
                    continue;
                }

            }
        }
    }
}