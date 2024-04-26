using Microsoft.AspNetCore.Mvc;

namespace Gestor_de_Limites.Areas.Client.Controllers;

[Area("Client")]
public class TransacaoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
