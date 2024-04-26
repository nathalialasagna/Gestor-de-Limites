using Gestor_de_Limite.DataAccess.Repository.IRepository;
using Gestor_de_Limite.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_de_Limites.Areas.Admin.Controllers;

[Area("Admin")]
public class ContaController : Controller
{
    private readonly IContaRepository _contaRepository;

    public ContaController(IContaRepository contaRepository)
    {
        _contaRepository = contaRepository;
    }

    public async Task<IActionResult> Index()
    {
        var contas = await _contaRepository.GetAll();

        return View(contas);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Conta conta)
    {
        var contaExistente = await _contaRepository.Get(conta.Agencia, conta.Numero);

        if (contaExistente != null) ModelState.AddModelError("", "Conta já existe");

        if (!ModelState.IsValid) return View();

        await _contaRepository.Add(conta);
        
        TempData["success"] = "Conta criada com sucesso.";

        return RedirectToAction("Index");
    }

}
