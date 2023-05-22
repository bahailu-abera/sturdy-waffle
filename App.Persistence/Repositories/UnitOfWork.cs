using App.Application.Contracts.Persistence;
using System;
using System.Threading.Tasks;
namespace App.Persistence.Repositories;


public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext dbContext;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public ITaskRepository TaskRepository => new TaskRepository(dbContext);
    public IChecklistRepository ChecklistRepository => new ChecklistRepository(dbContext);

    public async Task<int> Save()
    {
        return await dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        dbContext.Dispose();
    }
}


