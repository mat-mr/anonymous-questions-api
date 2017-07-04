using AnonymousQuestions.Domain;
using AnonymousQuestions.Repository;
using AnonymousQuestions.Repository.Context;
using AnonymousQuestions.Repository.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AnonymousQuestions.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // Configure DbContext
            bool useInMemoryDatabase = Configuration.GetValue<bool>("InMemoryDatabase", true);

            if (useInMemoryDatabase)
            {
                services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase());
            }
            else
            {
                // TO-DO: Adicionar lógica para utilizar base de verdade
            }

            services.AddScoped<IQuestionRepository, QuestionRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var context = app.ApplicationServices.GetService<ApiContext>();

            bool useInMemoryDatabase = Configuration.GetValue<bool>("InMemoryDatabase", true);

            if (useInMemoryDatabase)
            {
                TestDataCreator.Create(context);
            }

            app.UseMvc();
        }
    }
}
