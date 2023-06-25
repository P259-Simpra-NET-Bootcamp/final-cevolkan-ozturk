using ECommerce.Base;
using ECommerce.Data.Repository;

namespace ECommerce.Data.Uow;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Category> CategoryRepository { get; }
  
    IGenericRepository<Entity> Repository<Entity>() where Entity : BaseModel;

    void Complete();
    void CompleteWithTransaction();
}
