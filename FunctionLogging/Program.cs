using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;

var host = new HostBuilder()
    .ConfigureAppConfiguration((hostContext, configurationBuilder) =>
    {
        if (hostContext.HostingEnvironment.IsDevelopment())
        {
            var entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                configurationBuilder.AddUserSecrets(entryAssembly, optional: true, reloadOnChange: false);
            }
        }
    })
    .ConfigureLogging((hostContext, builder) =>
    {
        if (hostContext.HostingEnvironment.IsDevelopment())
        {
            // This is needed as it isn't picking up the logging section from the user secrets
            builder.AddConfiguration(hostContext.Configuration.GetSection("logging"));
        }
    })
    .ConfigureFunctionsWorkerDefaults()
    .Build();

host.Run();
