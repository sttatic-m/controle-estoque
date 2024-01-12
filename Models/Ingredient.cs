namespace controle_estoque.Models;

public class Ingredient
{
    public Guid Id { get; set; }
    public required Product Product { get; set; }
    public int Quantity { get; set; }
}