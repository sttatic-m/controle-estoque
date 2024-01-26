using System.Globalization;
using controle_estoque.Data;
using controle_estoque.Models;
using Microsoft.AspNetCore.Mvc;
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
            var productionList = _context.Productions.ToList();
            if (productionList != null && productionList.Any()) return Ok(productionList);
            else return NotFound("Not Found Any Production");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{index}", Name = "FindDateProductions")]
    public ActionResult FindDateProductions(string index)
    {
        try
        {
            if (DateTime.TryParseExact(index, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                var productions = _context.Productions.Where(prod => prod.ProductionDate.Date == date.Date).ToList();
                if (productions != null)
                {
                    return Ok(productions);
                }

                throw new Exception("Not Found");
            }

            var productionsByProductCode = _context.Productions.Where(prod => prod.ProductCode == int.Parse(index)).ToList();
            if(productionsByProductCode != null)
            {
                return Ok(productionsByProductCode);
            }

            throw new Exception("Not Found");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost(Name = "AddProduction")]
    public ActionResult AddProduction([FromBody] Production production)
    {
        int prodCode = 0;
        try
        {
            var lastProduction = _context.Productions.OrderByDescending(p => p.Id).FirstOrDefault();
            if (lastProduction != null) prodCode = lastProduction.Code++;

            var newProduction = new Production(Guid.NewGuid(), prodCode, production.Amount, production.AmountRecipes, DateTime.Now, production.ProductCode, production.RecipeCode);
            _context.Productions.Add(newProduction);

            var product = _context.Products.FirstOrDefault( p => p.Code == production.ProductCode);
            if(product == null)
            {
                throw new Exception("Not Found Product With THis Code");
            }

            product.Quantity += production.Amount;
            
            _context.Update(product);
            _context.SaveChanges();
            return Ok(newProduction);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{code}", Name = "EditProduction")]
    public ActionResult EditProduction(int code, [FromBody] Production newProduction)
    {
        try
        {
            var production = _context.Productions.FirstOrDefault(product => product.Code == code);
            if (production != null)
            {
                production.Amount = newProduction.Amount;
                production.RecipeCode = newProduction.RecipeCode;
                production.AmountRecipes = newProduction.AmountRecipes;
                production.ProductCode = newProduction.ProductCode;
                production.ProductionDate = newProduction.ProductionDate;

                _context.Update(production);
            }

            _context.SaveChanges();
            return Ok(production);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{code}", Name = "DeleteProduction")]
    public ActionResult DeleteProduction(int code)
    {
        try
        {
            var production = _context.Productions.FirstOrDefault(prod => prod.Code == code);
            if(production != null)
            {
                _context.Productions.Remove(production);
                _context.SaveChanges();

                return Ok($"Delete {code} Production");
            }

            throw new Exception("Failed to Find Production");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}