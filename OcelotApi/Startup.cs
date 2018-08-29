using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace OcelotApi
{
    public class Startup
    {
        const string ocelot = nameof(ocelot);
        const string corsPolicy = nameof(corsPolicy);
        const string Logging = nameof(Logging);
        readonly ILogger<Startup> logger;

        public Startup(IConfiguration configuration, IHostingEnvironment env, ILogger<Startup> logger)
        {
            this.logger = logger;
            logger.LogDebug(nameof(Startup));

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables()
                .AddJsonFile($"{ocelot}.json")
                .AddJsonFile($"{ocelot}.{env.EnvironmentName}.json")
                .AddConfiguration(configuration);

            Configuration = configurationBuilder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            logger.LogDebug("Running Startup.ConfigureServices(IServiceCollection)");

            services.AddCors(options =>
            {
                options.AddPolicy(corsPolicy, policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });

            IConfigurationSection GatewayConfig = Configuration.GetSection(nameof(GatewayConfig));
            string administrationPath = GatewayConfig.GetValue<string>(nameof(administrationPath));
            string administrationSecret = GatewayConfig.GetValue<string>(nameof(administrationSecret));

            services.AddOcelot(Configuration)
                .AddTransientDefinedAggregator<ValuesAggregator>()
                .AddDelegatingHandler<LogRequestDelegatingHandler>(global: true)
                .AddAdministration(administrationPath, administrationSecret);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(corsPolicy);

            app.UseLogRequest();

            app.UseOcelot().Wait();
        }
    }
}
