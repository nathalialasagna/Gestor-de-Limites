using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Gestor_de_Limite.DataAccess.Repository.IRepository;
using Gestor_de_Limite.Models.Models;

namespace Gestor_de_Limite.DataAccess.Repository;

public class ContaRepository : IContaRepository
{
    private readonly IDynamoDBContext _context;

    public ContaRepository(IDynamoDBContext context)
    {
        _context = context;
    }

    public async Task Add(Conta conta)
    {
        conta.Numero = RetornaConta(conta.Numero);

        await _context.SaveAsync(conta);
    }

    public async Task Update(Conta conta)
    {
        await _context.SaveAsync(conta);
    }

    public async Task<Conta?> Get(string agencia, string conta)
    {
        var contas = await _context.QueryAsync<Conta>(agencia, QueryOperator.Equal, new object[] { RetornaConta(conta) }).GetRemainingAsync();

        return contas.FirstOrDefault();
    }

    public async Task Remove(string agencia, string conta)
    {
        await _context.DeleteAsync<Conta>(agencia, RetornaConta(conta));
    }

    public static string RetornaConta(string conta) => string.Concat("Conta#", conta);
}
