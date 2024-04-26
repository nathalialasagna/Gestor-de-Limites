using Amazon.DynamoDBv2.DataModel;
using System.ComponentModel.DataAnnotations;

namespace Gestor_de_Limite.Models.Models;

[DynamoDBTable("GestorDeLimites")]
public class Conta
{
    [Required]
    [DynamoDBHashKey("pk")]
    public string Agencia { get; set; } = default!;
    [Required]
    [DynamoDBRangeKey("sk")]
    public string Numero { get; set; } = default!;
    [Required]
    [DynamoDBProperty("Documento")]
    public string Documento { get; set; } = default!;
    [Required]
    [DynamoDBProperty("Limite")]
    public decimal Limite { get; set; }
}
