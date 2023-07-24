using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CostSplitterAPI.Data;
using CostSplitterAPI.Services.Users;

namespace CostSplitterAPI.Services.Extensions
{

    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<DataContext>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();      
            services.AddRazorPages();
           

        }
   
    }
}
