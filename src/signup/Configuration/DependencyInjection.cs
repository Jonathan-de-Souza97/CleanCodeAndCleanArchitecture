
using signup.Application.Interfaces;
using signup.Application.UseCase;

namespace signup.Configuration
{
    public static class DependencyInjection
    {
        public static ServiceProvider DependencyInjectionConfig(this IServiceCollection service)
        {
            service.AddScoped<ISignup, Signup>();

            return service.BuildServiceProvider();
        }
    }
}
