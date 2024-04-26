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

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string? numeroAgencia, string? numeroConta)
    {
        var contaExistente = await _contaRepository.Get(numeroAgencia!, numeroConta!);

        if(contaExistente != null)
            contaExistente.Numero = contaExistente.Numero.Split('#').Last();

        return View(contaExistente);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Conta conta)
    {
        var contaExistente = await _contaRepository.Get(conta.Agencia, conta.Numero);

        if (contaExistente != null) ModelState.AddModelError("", "Conta já existe.");

        if (!ModelState.IsValid) return View();

        await _contaRepository.Add(conta);

        TempData["success"] = "Conta criada com sucesso.";

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(string? numeroAgencia, string? numeroConta)
    {
        if (numeroAgencia == null && numeroConta == null) return NotFound();

        var contaExistente = await _contaRepository.Get(numeroAgencia!, numeroConta!);

        if (contaExistente == null) return NotFound();
        
        contaExistente.Numero = contaExistente.Numero.Split('#').Last();

        return View(contaExistente);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Conta conta)
    {
        if (!ModelState.IsValid) return View();
        var contaExistente = await _contaRepository.Get(conta.Agencia, conta.Numero);

        if (contaExistente == null) ModelState.AddModelError("", "Conta não existe.");

        await _contaRepository.Update(conta);

        TempData["success"] = "Limite criada com sucesso.";

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(string? numeroAgencia, string? numeroConta)
    {
        if (numeroAgencia == null && numeroConta == null) return NotFound();

        var contaExistente = await _contaRepository.Get(numeroAgencia!, numeroConta!);

        if (contaExistente != null)
            contaExistente.Numero = contaExistente.Numero.Split('#').Last();

        if (contaExistente == null) return NotFound();

        return View(contaExistente);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePost(string? numeroAgencia, string? numeroConta)
    {
        if (numeroAgencia == null && numeroConta == null) return NotFound();

        var contaExistente = _contaRepository.Get(numeroAgencia!, numeroConta!);

        if (contaExistente == null) return NotFound();

        await _contaRepository.Remove(numeroAgencia!, numeroConta!);

        TempData["success"] = "Conta deletada com sucesso.";

        return RedirectToAction("Index");
    }
}