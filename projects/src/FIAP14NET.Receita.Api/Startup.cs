using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIAP14NET.Receita.Core.Persistencia.Contexto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace FIAP14NET.Receita.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration
        {
            get;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            string connection = @"Server=(localdb)\mssqllocaldb;Database=Receita;Trusted_Connection=True;";
            services.AddDbContext<ReceitaContexto>(options => options.UseSqlServer(connection));

            services.Configure<GzipCompressionProviderOptions>( o => o.Level = System.IO.Compression.CompressionLevel.Fastest);

            services.AddResponseCompression(o =>
            {
                o.Providers.Add<GzipCompressionProvider>();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(a => {
                a.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API");
            });

            app.UseResponseCompression();

            app.UseMvc();
        }
    }
}
