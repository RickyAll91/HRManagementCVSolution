using HRManagement.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Server.Repository;

public class ApplicationRepository<T> : IApplicationRepository<T> where T : class
{
    public ApplicationDbContext Context { get; }

    public ApplicationRepository(ApplicationDbContext context)
    {
        Context = context;
    }

    public async Task<T> CreaAsync(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<T?> RecuperaByIdAsync(int id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> RecuperaTuttoAsync()
    {
        return await Context.Set<T>().ToListAsync();
    }

    public async Task AggiornaAsync(T entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }

    public async Task EliminaAsync(T entity)
    {
        Context.Set<T>().Remove(entity);
        await Context.SaveChangesAsync();
    }

}