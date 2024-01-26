using Microsoft.AspNetCore.Mvc;
using controle_estoque.Models;
using controle_estoque.Data;

namespace controle_estoque.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly AppDbContext _context;
    public ProductController(ILogger<ProductController> logger, AppDbContext dbContext)
    {
        _logger = logger;
        _context = dbContext;
    }

    [HttpGet(Name = "GetProducts")]
    public ActionResult GetProducts()
    {
        var productList = _context.Products.ToList();
        if (productList != null && productList.Any()) return Ok(productList);
        else return BadRequest("Failed");
    }

    [HttpGet("{code}", Name = "FindOneProduct")]
    public ActionResult FindOneProduct(int code)
    {
        try
        {
            var product = _context.Products.FirstOrDefault(p => p.Code == code);

            if (product != null) return Ok(product);

            return NotFound($"Not Found Product with Code: {code}");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost(Name = "AddProduct")]
    public ActionResult AddProduct([FromBody] Product product)
    {
        int code = 0;
        try
        {
            var lastProduct = _context.Products.OrderByDescending(p => p.Id).FirstOrDefault();
            
            if (lastProduct != null) code = lastProduct.Code++;
            Product newProduct = new Product(Guid.NewGuid(), code, product.Name, product.ValidityTime, DateTime.Now);
            _context.Products.Add(newProduct);
            _context.SaveChanges();

            return CreatedAtAction("GetProducts", new { id = product.Code }, newProduct);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Erro ao adicionar o produto: {e.Message}");
        }
    }

    [HttpPut(Name = "EditProduct")]
    public ActionResult EditProduct(int code, [FromBody] Product newProduct)
    {
        try
        {
            var product = _context.Products.FirstOrDefault(product => product.Code == code);
            if (product != null)
            {
                product.Name = newProduct.Name;
                product.ValidityTime = newProduct.ValidityTime;
                
                _context.Update(product);
            }
            
            _context.SaveChanges();
            return Ok(product);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete(Name = "RemoveProduct")]
    public ActionResult RemoveProduct(int code)
    {
        try 
        {
            var product = _context.Products.FirstOrDefault(product => product.Code == code);
            if (product != null) _context.Remove(product);
            _context.SaveChanges();
            return Ok(product);
        }
        catch (Exception e)
        {
            return BadRequest("Error: " + e.Message);
        }
    }
}