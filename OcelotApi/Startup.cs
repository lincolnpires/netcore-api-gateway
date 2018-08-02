using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace OcelotApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            const string ocelotConfig = "ocelot.json";

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile(ocelotConfig)
                .AddConfiguration(configuration);

            Configuration = configurationBuilder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string path = "/adm";
            string secret = nameof(secret);

            services.AddOcelot(Configuration)
                .AddTransientDefinedAggregator<ValuesAggregator>()
                .AddAdministration(path, secret);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseOcelot().Wait();
        }
    }
}
