using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALevelSample.Repositories.Abstractions;

namespace ALevelSample.Models;

public class Pagination<T, TEntity>
    where T : class
    where TEntity : class
{
    private readonly IPaginationRepository<TEntity> _paginationRepository;

    public Pagination(IPaginationRepository<TEntity> paginationRepository)
    {
        _paginationRepository = paginationRepository;

        CurrentPage = _paginationRepository.CurrentPage;
        TotalPages = _paginationRepository.TotalPages;
        TotalItems = _paginationRepository.TotalItems;
    }

    /*public delegate Task NextHandler(object sender, EventArgs e);
    public event NextHandler? OnNext;*/
    public delegate void Mapper(Action<Func<TEntity, T>> callback);

    public event Mapper? OnInit;
    public event Mapper? OnNext;
    public event Mapper? OnPrev;

    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }

    public List<T> Items { get; private set; } = new List<T>();

    public void Init()
    {
        OnInit?.Invoke(MapEntityToModel);
    }

    public async Task Next()
    {
        await _paginationRepository.Next();

        CurrentPage = _paginationRepository.CurrentPage;

        OnNext?.Invoke(MapEntityToModel);
    }

    public async Task Prev()
    {
        await _paginationRepository.Prev();

        CurrentPage = _paginationRepository.CurrentPage;

        OnPrev?.Invoke(MapEntityToModel);
    }

    public void MapEntityToModel(Func<TEntity, T> callback)
    {
        Items = _paginationRepository.Items.Select(callback).ToList();
    }
}