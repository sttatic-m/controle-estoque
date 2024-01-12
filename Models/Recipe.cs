namespace controle_estoque.Models;

public class Recipe
{
    public Guid Id { get; set; }
    public required List<Ingredient> Ingredients { get; set; }
}