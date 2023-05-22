using App.Domain;

namespace App.Application.Contracts.Persistence;

public interface IChecklistRepository: IGenericRepository<Checklist>
{
    public Task<List<Checklist>> GetChecklistByTaskId(int TaskId);
}