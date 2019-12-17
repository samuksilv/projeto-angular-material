using Microsoft.Extensions.DependencyInjection;
using Portal.Domain.BusinessLogic;
using Portal.Domain.Contracts.BusinessLogic;

namespace Portal.CrossCutting.DependeceInjection {
    public static class BusinessLogicDependencyInjection {
        public static void ConfigureServices (IServiceCollection services) {

            services.AddScoped<IUserService, UserService> ();

        }
    }
}