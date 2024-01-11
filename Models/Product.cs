namespace controle_estoque.Models;

public class Product 
{
    public Guid Id { get; set; }
    public int Code { get; set; }
    public String Name { get; set; }
    public bool Ingredient { get; set; }
    public int ValidityTime { get; set; }
    public DateTime FabricationDate { get; set; }

    public Product(Guid id, int code, string name, bool ingredient, int validityTime, DateTime fabricationDate)
    {
        Id = id;
        Code = code;
        Name = name;
        Ingredient = ingredient;
        ValidityTime = validityTime;
        FabricationDate = fabricationDate;
    }
}