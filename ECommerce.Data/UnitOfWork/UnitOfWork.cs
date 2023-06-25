using ECommerce.Base;
using ECommerce.Data.Context;
using ECommerce.Data.Repository;

namespace ECommerce.Data.Uow;

public class UnitOfWork : IUnitOfWork
{
    public IGenericRepository<Category> CategoryRepository { get; private set; }
    
    private readonly ECommerceEfDbContext dbContext;
    private readonly ECommerceDapperDbContext dapperDbContext;
    private bool disposed;

    public UnitOfWork(ECommerceEfDbContext dbContext, ECommerceDapperDbContext dapperDbContex)
    {
        this.dbContext = dbContext;
        this.dapperDbContext = dapperDbContex;

        CategoryRepository = new GenericRepository<Category>(dbContext);
    }

    public IGenericRepository<Entity> Repository<Entity>() where Entity : BaseModel
    {
        return new GenericRepository<Entity>(dbContext);
    }
    public void Complete()
    {
        dbContext.SaveChanges();
    }

    public void CompleteWithTransaction()
    {
        using (var dbDcontextTransaction = dbContext.Database.BeginTransaction())
        {
            try
            {
                dbContext.SaveChanges();               
                dbDcontextTransaction.Commit();
            }
            catch (Exception ex)
            {
                // logging
                dbDcontextTransaction.Rollback();
            }         
        }
    }


    private void Clean(bool disposing)
    {
        if (!disposed)
        {
            if (disposing && dbContext is not null)
            {
                dbContext.Dispose();
            }
        }

        disposed = true;
        GC.SuppressFinalize(this);
    }
    public void Dispose()
    {
        Clean(true);
    }
}
