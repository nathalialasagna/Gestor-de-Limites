using Amazon.DynamoDBv2.DataModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gestor_de_Limite.Models.Models;

[DynamoDBTable("GestorDeLimites")]
public class Transacao
{
    [DynamoDBRangeKey("sk")]
    public string Id { get; set; } = string.Concat("Transacao#",Guid.NewGuid().ToString());

    [DisplayName("Número Conta")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [DynamoDBHashKey("pk")]
    public string NumeroConta { get; set; } = default!;

    [DisplayName("Número Agencia")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [DynamoDBProperty("NumeroAgencia")]
    public string NumeroAgencia { get; set; } = default!;

    [DisplayName("ChavePix")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [DynamoDBProperty("ChavePix")]
    public string ChavePix { get; set; } = default!;

    [Required(ErrorMessage = "Campo obrigatório.")]
    [DynamoDBProperty("Valor")]
    public decimal Valor { get; set; }

    [DynamoDBProperty("Tipo")]
    public string? Tipo { get; set; }
}
