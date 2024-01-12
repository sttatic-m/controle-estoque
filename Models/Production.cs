namespace controle_estoque.Models;

public class Production
{
    public Guid Id { get; set; }
    public required Product Product { get; set; }
    public double Amount { get; set; }
    public double AmountRecipes { get; set; }
    public required Recipe Recipe {get; set; }
    public DateTime ProductionDate { get; set; } 

    public Production(double amount, double amountRecipes, DateTime productionDate)
    {
        Amount = amount;
        AmountRecipes = amountRecipes;
        ProductionDate = productionDate;
    }
}