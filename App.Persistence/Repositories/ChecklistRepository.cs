
using App.Application.Contracts.Persistence;
using App.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Persistence.Repositories;

public class ChecklistRepository : GenericRepository<Checklist>, IChecklistRepository
{
    public ChecklistRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Checklist>> GetChecklistByTaskId(int taskId)
    {
        return await _dbContext.Checklists
            .Where(c => c.TaskId == taskId)
            .ToListAsync();
    }
}