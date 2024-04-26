using Gestor_de_Limite.Models.Models;

namespace Gestor_de_Limite.DataAccess.Repository.IRepository;

public interface ITransacaoRepository
{
    Task Add(Transacao transacao);
}

