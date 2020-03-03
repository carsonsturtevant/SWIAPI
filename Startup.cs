using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SWIAPI.Data;
using SWIAPI.Services;

namespace SWIAPI
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
            services.Configure<PeopleImageDatabaseSettings>(
                Configuration.GetSection(nameof(PeopleImageDatabaseSettings)));
            services.AddSingleton<IPeopleImageDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<PeopleImageDatabaseSettings>>().Value);
            services.AddSingleton<PeopleImageService>();

            services.Configure<FilmImageDatabaseSettings>(
                Configuration.GetSection(nameof(FilmImageDatabaseSettings)));
            services.AddSingleton<IFilmImageDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<FilmImageDatabaseSettings>>().Value);
            services.AddSingleton<FilmImageService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
