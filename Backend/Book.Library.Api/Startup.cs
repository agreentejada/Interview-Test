using Book.Library.Api.Services;
using Book.Library.Api.Utils;
using Book.Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Book.Library.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Using Sqlite instead of SQL Server provides a few different advantages.
            // 1. The project runs without testers being required to install SQL Server Local DB.
            // This greatly reduces the friction of testing.
            // 2. Sqlite is easy to delete and debug.

            services.AddDbContext<ApplicationDbContext>(
                option => option.UseSqlite(Configuration.GetConnectionString("DefaultConnection"))
            );


            // Feels needlessly unnecessary, as we are already adding services within this file.
            // Will keep anyways.
            ApplicationServices.AddServices(services);

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }
    }

    public static class ApplicationBuilder
    {
        // Initializing the database doesn't need any state from the Startup class, and can be put into it's own class.
        // Extension methods maintain the method calling consistency in Program.cs!
        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                // Replacing GetService with GetRequired service ensure that there's an error if the service isn't found.
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var jsonFileHelper = serviceScope.ServiceProvider.GetRequiredService<JsonFileHelper>();

                dbContext.Database.EnsureDeleted();
                if (dbContext.Database.EnsureCreated())
                {
                    jsonFileHelper.SeedDatabase();
                }
            }
        }
    }
}
