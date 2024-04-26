using Gestor_de_Limite.DataAccess.Repository.IRepository;
using Gestor_de_Limite.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_de_Limites.Areas.Client.Controllers;

[Area("Client")]
public class PixController : Controller
{
    private readonly ITransacaoRepository _transacaoRepository;
    private readonly IContaRepository _contaRepository;

    public PixController(ITransacaoRepository transacaoRepository, IContaRepository contaRepository)
    {
        _transacaoRepository = transacaoRepository;
        _contaRepository = contaRepository;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Transacao transacao)
    {
        var contaRemetente = await _contaRepository.Get(transacao.NumeroAgencia, transacao.NumeroConta);

        if (contaRemetente == null) ModelState.AddModelError("", "Sua conta não existe.");

        if (contaRemetente?.Limite < transacao.Valor) ModelState.AddModelError("", "Valor acima do limite.");

        if (!ModelState.IsValid) return RedirectToAction("Index", "Transacao");

        transacao.Tipo = "Pix";
        contaRemetente!.Limite -= transacao.Valor;

        await _transacaoRepository.Add(transacao);
        await _contaRepository.Update(contaRemetente!);

        TempData["success"] = $"Pix realizada com sucesso. Seu limite agora é: {contaRemetente!.Limite}";

        return RedirectToAction("Index", "Transacao");
    }
}
