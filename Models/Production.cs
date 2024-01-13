namespace controle_estoque.Models;

public class Production
{
    public Guid Id { get; set; }
    public int Code { get; set; }
    public int ProductCode { get; set; }
    public double Amount { get; set; }
    public double AmountRecipes { get; set; }
    public int RecipeCode {get; set; }
    public DateTime ProductionDate { get; set; } 

    public Production(Guid id, int code, double amount, double amountRecipes, DateTime productionDate, int productCode, int recipeCode)
    {
        Id = id;
        Code = code;
        Amount = amount;
        AmountRecipes = amountRecipes;
        ProductionDate = productionDate;
        ProductCode = productCode;
        RecipeCode = recipeCode;
    }
}