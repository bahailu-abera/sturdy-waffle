using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain;
namespace App.Application.Contracts.Persistence;

public interface ITaskRepository: IGenericRepository<TaskEntity>
{
    Task<List<TaskEntity>> GetTaskByUserId(int UserId);
}