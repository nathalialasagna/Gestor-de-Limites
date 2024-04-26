using Amazon.DynamoDBv2.DataModel;
using System.ComponentModel.DataAnnotations;

namespace Gestor_de_Limite.Models.Models;

[DynamoDBTable("GestorDeLimites")]
public class Transacao
{
    [DynamoDBRangeKey("sk")]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    [DynamoDBHashKey("pk")]
    public string NumeroConta { get; set; } = default!;
    [Required]
    [DynamoDBProperty("NumeroAgencia")]
    public string NumeroAgencia { get; set; } = default!;
    [Required]
    [DynamoDBProperty("ContaDestinatario")]
    public string ContaDestinatario { get; set; } = default!;
    [Required]
    [DynamoDBProperty("AgenciaDestinatario")]
    public string AgenciaDestinatario { get; set; } = default!;
    [Required]
    [DynamoDBProperty("Valor")]
    public decimal Valor { get; set; }
    [DynamoDBProperty("Tipo")]
    public string? Tipo { get; set; }
}
