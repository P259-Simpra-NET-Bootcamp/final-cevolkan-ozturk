using ECommerce.Data;
using ECommerce.Data.Repository;
namespace ECommerce.Service.RestExtension;

public static class RepositoryExtension
{
    public static void AddRepositoryExtension(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository,ProductRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICouponRepository, CouponRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();    
    }
}
