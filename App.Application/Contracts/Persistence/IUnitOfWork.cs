namespace App.Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    ITaskRepository TaskRepository { get; }
    IChecklistRepository ChecklistRepository { get; }

    Task<int> Save();
}
