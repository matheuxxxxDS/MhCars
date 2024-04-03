using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MhCars.Models;
using System.Text.Json;

namespace MhCars.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
       List<Carros> carros = [];
       using (StreamReader leitor = new("Data\\carros.json"))
       {
            string dados = leitor.ReadToEnd();
            carros = JsonSerializer.Deserialize<List<Carros>>(dados);
       }
       List<Tipo> tipos = [];
       using (StreamReader leitor = new("Data\\tipos.json"))
       {
            string dados = leitor.ReadToEnd();
            tipos = JsonSerializer.Deserialize<List<Tipo>>(dados);
       }
       ViewData["Tipos"] = tipos;
        return View(carros);
    }
    public IActionResult Details(int id)
    {
        List<Carros> carros = [];
        using (StreamReader leitor = new("Data\\carros.json"))
        {
            string dados = leitor.ReadToEnd();
            carros = JsonSerializer.Deserialize<List<Carros>>(dados);
        }
        List<Tipo> tipos = [];
        using (StreamReader leitor = new("Data\\tipos.json"))
        {
            string dados = leitor.ReadToEnd();
            tipos = JsonSerializer.Deserialize<List<Tipo>>(dados);
        }
        DetailsVM details = new() {
            Tipos = tipos,
            Atual = carros.FirstOrDefault(p => p.Numero == id),
            Anterior = carros.OrderByDescending(p => p.Numero).FirstOrDefault(p => p.Numero < id),
            Proximo = carros.OrderBy(p => p.Numero).FirstOrDefault(p => p.Numero > id),
        };
        return View(details);
        
        ViewData["Tipos"] = tipos;
        var carro = carros
            .Where(p => p.Numero == id)
            .FirstOrDefault();
        return View(carro);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
