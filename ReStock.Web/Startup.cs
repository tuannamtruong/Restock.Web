using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReStock.DataProvider;
using ReStock.Web.Services.Data;

namespace ReStock.Web
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
            services.AddDbContext<RestockDbContext>();
            //services.AddDbContext<RestockDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddTransient<IShoppingItemRepository, ShoppingItemRepository>();
            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddTransient<IStockRepository, StockRepository>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "catpage",
                    "{category}/Page{recipePage:int}",
                    new { Controller = "Recipe", action = "RecipeListDetail" });
                endpoints.MapControllerRoute(
                    "page",
                    "Page{recipePage:int}",
                    new { Controller = "Recipe", action = "RecipeListDetail", productPage = 1 });
                endpoints.MapControllerRoute(
                    "category",
                    "{category}",
                    new { Controller = "Recipe", action = "RecipeListDetail", productPage = 1 });

                endpoints.MapControllerRoute(
                    "pagination",
                    "Recipes/Page{recipePage}",
                    new { Controller = "Recipe", action = "RecipeListDetail", productPage = 1 });


                //endpoints.MapControllerRoute(
                //    name: "pagination",
                //    pattern: "Recipes/Page{recipePage}",
                //    new { Controller = "Recipe", action = "RecipeListDetail" });
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Recipe}/{action=RecipeListDetail}/{id?}");
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
