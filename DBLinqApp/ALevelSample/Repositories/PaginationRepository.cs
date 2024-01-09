using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALevelSample.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample.Repositories;

public class PaginationRepository<T> : IPaginationRepository<T>
    where T : class
{
    private readonly DbSet<T> _dbSet;

    public PaginationRepository(DbSet<T> dbSet)
    {
        _dbSet = dbSet;
    }

    public int CurrentPage { get; set; } = 0;

    public int TotalPages
    {
        get => (TotalItems / PerPage) + 1;
        set => TotalPages = value;
    }

    public int TotalItems { get; set; }
    public int PerPage { get; set; } = 20;

    public List<T> Items { get; set; } = new List<T>();

    public async Task<IPaginationRepository<T>> Paginate()
    {
        await InitPaginationMeta();

        await FetchItems();

        return this;
    }

    public async Task<IPaginationRepository<T>> Paginate(int? perPage)
    {
        if (perPage != null)
        {
            PerPage = (int)perPage;
        }

        await InitPaginationMeta();

        await FetchItems();

        return this;
    }

    public async Task Next()
    {
        if (CurrentPage < TotalPages - 1)
        {
            CurrentPage += 1;
        }

        await FetchItems();
    }

    public async Task Prev()
    {
        if (CurrentPage > 0)
        {
            CurrentPage -= 1;
        }

        await FetchItems();
    }

    private async Task FetchItems()
    {
        Items = await _dbSet
            .Skip(CurrentPage * PerPage)
            .Take(PerPage)
            .AsNoTracking()
            .ToListAsync();
    }

    private async Task InitPaginationMeta()
    {
        TotalItems = await _dbSet.CountAsync();
        Console.WriteLine("Current Page: {0}, Total Items: {1}, Total Pages: {2}", CurrentPage, TotalItems, TotalPages);
    }
}