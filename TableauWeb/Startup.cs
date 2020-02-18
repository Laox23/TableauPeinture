using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TableauWeb.Data;
using TableauWeb.Model;
using TableauWeb.Services;

namespace TableauWeb
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
            //services.AddControllers();
            //services.AddRazorPages();

            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Tableaux/Index", "");
            });

            services.AddDbContext<TableauxContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("TableauxContext")));

            services.AddIdentity<Utilisateur, Role>(options => options.Stores.MaxLengthForKeys = 128)
            .AddEntityFrameworkStores<TableauxContext>()
            .AddDefaultTokenProviders();

            //services.AddIdentity<Utilisateur, IdentityRole>()
            //    .AddEntityFrameworkStores<TableauxContext>();

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
            //    .AddEntityFrameworkStores<TableauxContext>();

            services.AddSingleton<NamesService>();

            services.AddScoped<IFichierService, FichierService>();
           // services.AddScoped<IFichierService, BlobService>();

            services.AddDirectoryBrowser();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            UserManager<Utilisateur> userManager, RoleManager<Role> roleManager)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            UtilisateurDataInitializer.SeedData(userManager, roleManager);

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Tableaux}/{action=Index}/{id?}");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                //endpoints.MapControllers();
                //endpoints.MapGet("api/finitions", (context) =>
                //{
                //    var finitions = app.ApplicationServices.GetService<JsonFinitionsService>().GetListe();
                //    var json = JsonSerializer.Serialize(finitions);
                //    return context.Response.WriteAsync(json);
                //});
            });

        
        }
    }
}
