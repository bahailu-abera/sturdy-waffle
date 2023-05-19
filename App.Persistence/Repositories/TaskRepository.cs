using App.Application.Contracts.Persistence;
using App.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Persistence.Repositories;

public class TaskRepository : GenericRepository<TaskEntity>, ITaskRepository
{
    public TaskRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<TaskEntity>> GetTaskByUserId(int userId)
    {
        return await _dbContext.Tasks
            .Where(t => t.UserId == userId)
            .ToListAsync();
    }
}