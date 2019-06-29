using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using BookManage.Convertor;
using BookManage.Repository;
using BookManage.Repository.Mysql;
using BookManage.Metadata;

namespace BookManage
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
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            var connectionString = Configuration.GetConnectionString("LocalMysqlDB");
            services.AddSingleton(new MysqlConnectionProvider(connectionString));

            services.AddSingleton<ITheBookRepository, MysqlTheBookRepository>();
            services.AddSingleton<ICategoryRepository, MysqlCategoryRepository>();
            services.AddSingleton<IColorRepository, MysqlColorRepository>();

            services.AddSingleton<IMetaCategoryRepository, MysqlMetaCategoryRepository>();
            services.AddSingleton<IMetaColorRepository, MysqlMetaColorRepository>();

            services.AddSingleton<ITheBookConvertor, TheBookConvertor>();
            services.AddSingleton<ICategoryConvertor, CategoryConvertor>();
            services.AddSingleton<IColorConvertor, ColorConvertor>();

            services.AddSingleton<IMetaCategoryConvertor, MetaCategoryConvertor>();
            services.AddSingleton<IMetaColorConvertor, MetaColorConvertor>();

            services.AddSingleton<IMetaCategoryProvider, MetaCategoryProvider>();
            services.AddSingleton<IMetaColorProvider, MetaColorProvider>();

            services.AddMvc();
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

            app.ApplicationServices.GetRequiredService<IMetaCategoryProvider>().Load();
            app.ApplicationServices.GetRequiredService<IMetaColorProvider>().Load();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}");

                routes.MapSpaFallbackRoute(name: "spa-fallback", defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
