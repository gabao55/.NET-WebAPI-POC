using System.Text.Json.Serialization;

namespace Teste___Webapi.Models;

public class Product
{
  public int Id { get; set; }
  public string Sku { get; set; } = String.Empty;
  public string Name { get; set; } = String.Empty;
  public string Description { get; set; } = String.Empty;
  public decimal Price { get; set; }
  public bool IsAvailable { get; set; }
  public int CategoryId { get; set; }
  [JsonIgnore]
  public virtual Category Category { get; set; }
}