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
        return View(carros);
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
