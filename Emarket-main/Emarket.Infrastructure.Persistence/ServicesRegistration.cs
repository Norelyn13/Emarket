using Emarket.Core.Application.Interfaces.Repositories;
using Emarket.Infrastructure.Persistence.Context;
using Emarket.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Emarket.Infrastructure.Persistence
{
    public static class ServicesRegistration
    {

        //Se le conoce como un Extension Methods - Decorator
        public static void AddPersitsenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if(configuration.GetValue<bool>("UseInMemoryDataBase"))
            {
                //Base de datos de texteo
                services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("DbPrueba"));
            }
            else
            {
                // Base de datos en producion

                services.AddDbContext<ApplicationDbContext>(Options => 
                Options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                m=>m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            #region Repositories

            //Generics
            services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));

            //Repo detallados
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IAdsRepository, AdsRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            #endregion

        }
    }
}
