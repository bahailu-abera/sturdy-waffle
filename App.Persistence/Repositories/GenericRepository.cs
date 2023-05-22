using App.Application.Contracts.Persistence;
using App.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : Base
{
    protected readonly ApplicationDbContext _dbContext;

    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> Get(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> Add(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        return entity;
    }

    public async Task<bool> Exists(int id)
    {
        return await _dbContext.Set<T>().AnyAsync(e => e.Id == id);
    }

    public async Task Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public async Task Delete(T entity)
    {
         _dbContext.Set<T>().Remove(entity);
    }
}