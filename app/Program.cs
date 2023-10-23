using dotenv.net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace br.dev.optimus.hermes.app;
internal class Program
{
    static void Main(string[] args)
    {
        DotEnv.Load();
        var host = Host.CreateDefaultBuilder(args).ConfigureServices(ConfigureServices).Build();
        host.Run();
    }

    static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        IConfiguration config = new ConfigurationBuilder().AddEnvironmentVariables().Build();
        services.AddSingleton<IConfiguration>(config);
        services.AddHostedService<App>();
    }
}
