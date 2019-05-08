using AutoMapper;
using FIAP14NET.Receita.Core.AutoMapper;
using FIAP14NET.Receita.Core.Dominio.Interfaces;
using FIAP14NET.Receita.Core.Persistencia.Contexto;
using FIAP14NET.Receita.Core.Persistencia.Contexto.Repositories;
using FIAP14NET.Receita.Core.Persistencia.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FIAP14NET.Receita.Site
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

			string connection = @"Server=tcp:trabfiap14net.database.windows.net,1433;Initial Catalog=MasterChef;Persist Security Info=False;User ID=fiap14net;Password=f1@p14NET;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
			services.AddDbContext<ReceitaContexto>(options => options.UseSqlServer(connection));
            services.AddTransient<IReceitaRepository, ReceitaRepository>();
            services.AddSingleton<ImageStore>();

            //services.AddDbContext<ReceitaContexto>(options => options.UseSqlServer(connection));

            //services.AddDbContext<ReceitaContexto>(options =>
            //                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            //services.AddScoped<ReceitaContextoFactory>();

            //Mapper.Initialize(cfg => AutoMapperConfiguration.RegisterMappings());

            //// Application
            //var mappingConfig = AutoMapperConfiguration.RegisterMappings();

            ////IMapper mapper = mappingConfig.CreateMapper();
            ////services.AddSingleton(mapper);

            //services.AddSingleton(mappingConfig.CreateMapper());
            //services.AddScoped<IMapper>(sp =>
            //  new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            ////services.AddScoped<IMapperConfigurationExpression>();

            services.AddAutoMapper();	

            // Application
            var mappingConfig = AutoMapperConfiguration.RegisterMappings();

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // injecao de dependencia do automapper
            //services.AddSingleton(AutoMapperConfiguration.RegisterMappings()); // n precisa de uma referencia do autommaper, pode ser singleton pra todas as requests
            // pega o servico do autommaper do http context e injeta via scoped nas classes onde vamos utilizar o automapper
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Receitas}/{action=Index}/{id?}");
            });
        }

		//public class ReceitaContextoFactory : IDesignTimeDbContextFactory<ReceitaContexto>
		//{
		//	public ReceitaContexto CreateDbContext(string[] args)
		//	{
		//		var optionsBuilder = new DbContextOptionsBuilder<ReceitaContexto>();
		//		optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Receita;Trusted_Connection=True;");

		//		return new ReceitaContexto(optionsBuilder.Options);
		//	}
		//}
	}
}
