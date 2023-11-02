// See https://aka.ms/new-console-template for more information

using Shop;
using Shop.Repositories;
using Shop.Services;

var app = new App(new ProductService(new ProductRepository()));

app.Start();