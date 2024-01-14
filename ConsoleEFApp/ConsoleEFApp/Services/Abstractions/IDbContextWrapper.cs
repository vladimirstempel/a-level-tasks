using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ConsoleEFApp.Services.Abstractions;

public interface IDbContextWrapper<T>
    where T : DbContext
{
    T DbContext { get; }
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
}