using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VueCliMiddleware;
using Microsoft.EntityFrameworkCore;
using CgiMovieApiVue.Data;
using CgiMovieApiVue.Models;
using CgiMovieApiVue.Data.EFCore;

namespace CgiMovieApiVue
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

           services.AddDbContext<ApiDbContext>(b => b.UseLazyLoadingProxies()
          .UseInMemoryDatabase("MoviesDb"));


            //services.AddDbContext<ApiDbContext>(options =>
            //{
            //    options.UseInMemoryDatabase("MoviesDb");
            //});


            services.AddScoped<EfCoreMovieRepository>();

            services.AddControllers();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp";
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSpaStaticFiles();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                    spa.Options.SourcePath = "ClientApp";
                else
                    spa.Options.SourcePath = "dist";

                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "serve");
                }

            });

            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using var serviceScope = serviceScopeFactory.CreateScope();

            var context = serviceScope.ServiceProvider.GetService<ApiDbContext>();
            AddTestData(context);

        }

        private void AddTestData(ApiDbContext context)
        {
            var category1 = new Category()
            {
                Name = "Comedy"
            };

            var category2 = new Category()
            {
                Name = "Action"
            };

            var category3 = new Category()
            {
                Name = "Horror"
            };

            context.Category.Add(category1);
            context.Category.Add(category2);
            context.Category.Add(category3);

            var movie1 = new Movie()
            {
                Title = "Title 1",
                Year = 2020,
                Rating = "Täielik jama",
                Description = "Desc 1",
                CategoryId = category1.Id
            };
            context.Movie.Add(movie1);

            var movie2 = new Movie()
            {
                Title = "Title 2",
                Year = 2019,
                Rating = "Jama ruudus",
                Description = "Desc 2",
                CategoryId = category1.Id
            };
            context.Movie.Add(movie2);

            var movie3 = new Movie()
            {
                Title = "Title 3",
                Year = 2018,
                Rating = "Jama kuubis",
                Description = "Desc 3",
                CategoryId = category1.Id
            };
            context.Movie.Add(movie3);




            var movie4 = new Movie()
            {
                Title = "Title 4",
                Year = 2020,
                Rating = "Täielik jama",
                Description = "Desc 5",
                CategoryId = category2.Id
            };
            context.Movie.Add(movie4);

            var movie5 = new Movie()
            {
                Title = "Title 5",
                Year = 2019,
                Rating = "Jama ruudus",
                Description = "Desc 5",
                CategoryId = category2.Id
            };
            context.Movie.Add(movie5);

            var movie6 = new Movie()
            {
                Title = "Title 6",
                Year = 2018,
                Rating = "Jama kuubis",
                Description = "Desc 6",
                CategoryId = category2.Id
            };
            context.Movie.Add(movie6);


            var movie7 = new Movie()
            {
                Title = "Title 4",
                Year = 2020,
                Rating = "Täielik jama",
                Description = "Desc 5",
                CategoryId = category3.Id
            };
            context.Movie.Add(movie7);

            var movie8 = new Movie()
            {
                Title = "Title 8",
                Year = 2019,
                Rating = "Jama ruudus",
                Description = "Desc 8",
                CategoryId = category3.Id
            };
            context.Movie.Add(movie8);

            var movie9 = new Movie()
            {
                Title = "Title 9",
                Year = 2018,
                Rating = "Jama kuubis",
                Description = "Desc 9",
                CategoryId = category3.Id
            };
            context.Movie.Add(movie9);




            context.SaveChanges();

        }
    }
}
