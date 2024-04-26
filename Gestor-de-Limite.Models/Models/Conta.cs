using Amazon.DynamoDBv2.DataModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gestor_de_Limite.Models.Models;

[DynamoDBTable("GestorDeLimites")]
public class Conta
{
    [Required(ErrorMessage = "Campo obrigatório.")]
    [DynamoDBHashKey("pk")]
    public string Agencia { get; set; } = default!;

    [DisplayName("Número Conta")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [DynamoDBRangeKey("sk")]
    public string Numero { get; set; } = default!;

    [Required(ErrorMessage = "Campo obrigatório.")]
    [DynamoDBProperty("Documento")]
    public string Documento { get; set; } = default!;

    [Required(ErrorMessage = "Campo obrigatório.")]
    [DynamoDBProperty("Limite")]
    public decimal Limite { get; set; }
}
