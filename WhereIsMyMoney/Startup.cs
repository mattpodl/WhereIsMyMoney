using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhereIsMyMoney.Data;
using WhereIsMyMoney.Helpers;

namespace WhereIsMyMoney
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var dbUri =
                "postgres://jdofjrfy:7tJDeHp7R7EpjXgTOAsuLmGk92A7qCXw@dumbo.db.elephantsql.com:5432/jdofjrfy"; //Configuration.GetValue<string>("dbUri");
            services.AddDbContext<ExpensesDbContext>(options => options.UseNpgsql(ConnectionStringParser.Get(dbUri)));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ExpensesDbContext expensesDbContext)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseMvc();
            expensesDbContext.Database.EnsureCreated();
        }
    }
}