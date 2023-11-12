using SaladMaker.Models;
using SaladMaker.Services.Abstractions;

namespace SaladMaker.Services;

public class SaladService : ISaladService
{
    public void AddSalad()
    {
        var salad = new Salad(3);
    }
}