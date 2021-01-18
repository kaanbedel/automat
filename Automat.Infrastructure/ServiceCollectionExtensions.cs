using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Automat.Data;
using Automat.Application;
using Automat.Application.Abstraction;

namespace Automat.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCommonInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {

            serviceCollection.AddTransient<IProductService, ProductService>();
            serviceCollection.AddTransient<IPaymentService, CreditCardPaymentService>();
            serviceCollection.AddTransient<IPaymentService, CreditCardContactlessPaymentService>();
            serviceCollection.AddTransient<IPaymentService, CashPaymentService>();
            serviceCollection.AddTransient<IPaymentService, CoinPaymentService>();
        }

        public static void AddPersistenceInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
