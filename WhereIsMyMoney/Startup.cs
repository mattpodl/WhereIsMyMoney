using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using WhereIsMyMoney.Data;
using WhereIsMyMoney.Helpers;
using WhereIsMyMoney.Services;

namespace WhereIsMyMoney
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o =>
            {
                o.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("*",
                            "http://localhost:4200").AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            
            
            var dbUri =
                Configuration.GetSection("ConnectionString").GetValue<string>("WimmDbContext");
            var cos = Configuration.GetConnectionString("WimmDbContext");
            services.AddDbContext<WimmDbContext>(options => options.UseNpgsql(ConnectionStringParser.Get(dbUri)));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo {Title = "Expense API", Version = "v1"}));
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IExpensesRepository, ExpensesRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            WimmDbContext wimmDbContext)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Expenses API"));
            app.UseMvc();
            wimmDbContext.Database.EnsureCreated();
        }
    }
}