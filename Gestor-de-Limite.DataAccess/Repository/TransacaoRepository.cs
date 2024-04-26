using Amazon.DynamoDBv2.DataModel;
using Gestor_de_Limite.DataAccess.Repository.IRepository;
using Gestor_de_Limite.Models.Models;

namespace Gestor_de_Limite.DataAccess.Repository;

public class TransacaoRepository : ITransacaoRepository
{
    private readonly IDynamoDBContext _context;

    public TransacaoRepository(IDynamoDBContext context)
    {
        _context = context;
    }

    public async Task Add(Transacao transacao)
    {
        await _context.SaveAsync(transacao);
    }
}
