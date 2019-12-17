using Microsoft.Extensions.DependencyInjection;
using Portal.Domain.Contracts.Repositories;
using Portal.Infra.Database.Repositories;

namespace Portal.CrossCutting.DependeceInjection {
    public static class RepositoryDependencyInjection {
        public static void ConfigureServices (IServiceCollection services) {

            services.AddScoped<IUserRepository, UserRepository> ();
            services.AddScoped<ISegmentRepository, SegmentRepository> ();

            
        }
    }
}