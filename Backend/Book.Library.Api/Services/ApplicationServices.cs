using Book.Library.Api.Utils;
using Book.Library.Business.Services;
using Book.Library.Data.Repositories;

namespace Book.Library.Api.Services
{
    public static class ApplicationServices
    {
        public static void AddServices(IServiceCollection services)
        {
            // If we are going to use AddServices method, we should add all user-created services here.
            services.AddAutoMapper(typeof(AutoMapperProfiles));

            // Should this really be a service? It's only used once.
            services.AddScoped<JsonFileHelper>();

            services.AddTransient<IGenericService, GenericService>();
            services.AddTransient<IGenericRepository, GenericRepository>();

        }
    }
}
