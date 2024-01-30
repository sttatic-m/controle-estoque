using controle_estoque.Models.Enum;

namespace controle_estoque.Models;

public class Production
{
    public Guid Id { get; set; }
    public int Code { get; set; }
    public int Product { get; set; }
    public double Amount { get; set; }
    public double AmountRecipes { get; set; }
    public int RecipeCode {get; set; }
    public DateTime ProductionDate { get; set; } 
    public string StepProducts { get; set; }
    public ProductionType Type { get; set; }

    public Production(Guid id, int code, int product, double amount, double amountRecipes, DateTime productionDate, int recipeCode, string stepProducts, ProductionType type)
    {
        Id = id;
        Code = code;
        Product = product;
        Amount = amount;
        AmountRecipes = amountRecipes;
        ProductionDate = productionDate;
        RecipeCode = recipeCode;
        StepProducts = stepProducts;
        Type = type;
    }
}