using controle_estoque.Models.Enum;

namespace controle_estoque.Models;

public class Product 
{
    public Guid Id { get; set; }
    public int Code { get; set; }
    public string Name { get; set; }
    public double Quantity { get; set; }
    public int ValidityTime { get; set; }
    public DateTime FabricationDate { get; set; }
    public MeasureType MeasureType { get; set; }

    public Product(Guid id, int code, string name, int validityTime, DateTime fabricationDate)
    {
        Id = id;
        Code = code;
        Name = name;
        ValidityTime = validityTime;
        FabricationDate = fabricationDate;
    }
}