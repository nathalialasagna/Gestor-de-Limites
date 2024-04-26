using Gestor_de_Limite.Models.Models;

namespace Gestor_de_Limite.DataAccess.Repository.IRepository;

public interface IContaRepository
{
    Task Add(Conta conta);
    Task Update(Conta conta);
    Task<Conta?> Get(string agencia, string conta);
    Task Remove(string agencia, string conta);
}
