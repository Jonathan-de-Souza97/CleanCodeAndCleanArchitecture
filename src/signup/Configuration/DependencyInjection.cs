
using signup.Application.Interfaces;
using signup.Application.UseCase;
using signup.Architecture.Configuration;
using signup.Architecture.Interface;
using signup.Architecture.Repository;

namespace signup.Configuration
{
    public static class DependencyInjection
    {
        public static ServiceProvider DependencyInjectionConfig(this IServiceCollection service)
        {
            service.AddScoped<ISignup, Signup>();
            service.AddScoped<IGetUsers, GetUsers>();


            service.AddScoped<IAccountRepository, AccountRepository>();

            return service.BuildServiceProvider();
        }
    }
}
