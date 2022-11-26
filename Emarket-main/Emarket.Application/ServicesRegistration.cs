using Emarket.Core.Application.Interfaces.Services;
using Emarket.Core.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Emarket.Infrastructure.Persistence
{
    public static class ServicesRegistration
    {
        //Se le conoce como un Extension Methods - Decorator
        public static void AddApplicationLayer(this IServiceCollection services)
        {
           
            #region Services
            
            services.AddTransient<ICategoryServices, ServicesCategory>();
            services.AddTransient<IAdsServices, ServicesAd>();
            services.AddTransient<IUserServices, ServicesUser>();
            services.AddTransient<IHomeServices, ServicesHome>();

            #endregion

        }
    }
}
