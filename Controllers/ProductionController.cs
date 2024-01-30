using System.Globalization;
using controle_estoque.Data;
using controle_estoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace controle_estoque.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductionController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductionController(AppDbContext dbContext)
    {
        _context = dbContext;
    }

    [HttpGet(Name = "GetProductions")]
    public ActionResult GetProductions()
    {
        try
        {
            return Ok(_context.Productions.ToList());
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost(Name = "AddProduction")]
    public async Task<IActionResult> AddProduction([FromBody] Production prod)
    {
        try
        {
            var lastProduction = _context.Productions.OrderByDescending(p => p.Id).FirstOrDefault() ?? prod;
            int code = lastProduction.Code <= 0 ? 0 : lastProduction.Code;

            Production production = new (Guid.NewGuid(), ++code, prod.Product, prod.Amount, prod.AmountRecipes, prod.ProductionDate, prod.RecipeCode, prod.StepProducts, prod.Type);
            
            Product? product = _context.Products.FirstOrDefault(p => p.Code == prod.Product) ?? throw new Exception("You need choose a product to create a new production!");
            product.Quantity += prod.Amount;
            await _context.Productions.AddAsync(production);
            _context.Products.Update(product);
            _context.SaveChanges();

            return Ok(production);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("code", Name = "EditProduction")]
    public async Task<IActionResult> EditProduction(int code, [FromBody] Production body)
    {
        try
        {
            Production production = await _context.Productions.FirstOrDefaultAsync(p => p.Code == code) ?? throw new Exception("Production Missing");
            
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Code == production.Product) ?? throw new Exception("Failed to Find Product");

            product.Quantity -= production.Amount;
            product.Quantity += body.Amount;

            production.Amount = body.Amount;
            production.RecipeCode = body.RecipeCode;
            production.AmountRecipes = body.AmountRecipes;
            production.Product = body.Product;
            production.StepProducts = body.StepProducts;
            production.ProductionDate = body.ProductionDate;
            production.Type = body.Type;

            _context.Productions.Update(production);
            await _context.SaveChangesAsync();
            return Ok(production);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{code}", Name = "DeleteProduction")]
    public async Task<IActionResult> DeleteProduction(int code)
    {
        try
        {
            Production production = await _context.Productions.FirstOrDefaultAsync(p => p.Code == code) ?? throw new Exception("Failed to find this production");
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Code == production.Product) ?? throw new Exception("This Production hasn't any product");

            product.Quantity -= production.Amount;

            _context.Productions.Remove(production);
            await _context.SaveChangesAsync();

            return Ok($"The production: {production.Code} - {product.Name}");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("/FindAll/{index}", Name = "FindAllProductions")]
    public async Task<IActionResult> FindAllProductions(string index)
    {
        try
        {
            if(DateTime.TryParseExact(index, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                var productions = _context.Productions.Select(p => p.ProductionDate == date).OrderByDescending(p => p.Id).ToList();
            }
            
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    /*[HttpDelete("/DeleteAll", Name = "DeleteAll")]
    public ActionResult DeleteAll()
    {
        _context.Productions.ExecuteDelete();
        _context.Products.ExecuteDelete();
        return Ok("DB Cleaned");
    }*/
}