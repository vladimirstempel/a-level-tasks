using System.Collections.Generic;
using System.Threading.Tasks;

namespace ALevelSample.Repositories.Abstractions;

public interface IPaginationRepository<T>
    where T : class
{
    int CurrentPage { get; set; }
    int TotalPages { get; set; }
    int TotalItems { get; set; }

    List<T> Items { get; set; }

    Task Next();
    Task Prev();
}