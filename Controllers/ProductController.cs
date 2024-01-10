using Microsoft.AspNetCore.Mvc;
using controle_estoque.Models;

namespace controle_estoque.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProducts")]
    public IEnumerable<Product> Get()
    {
        Product product = new(100, "Teste", false, 30);
        return Enumerable.Range(1, 1).Select(index => product).ToArray();
    }
}