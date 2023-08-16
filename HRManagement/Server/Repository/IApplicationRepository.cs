using HRManagement.Server.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HRManagement.Server.Repository;

public interface IApplicationRepository<T> where T: class
{
    ApplicationDbContext Context { get; }
    Task<T> CreaAsync(T entity);
    Task<List<T>> RecuperaTuttoAsync();
    Task<T?> RecuperaByIdAsync(int id);
    Task AggiornaAsync(T entity);
    Task EliminaAsync(T entity);
}