using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

[Route("/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly DataBaseContext context;

    public ProductController(DataBaseContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProduct()
    {
        return this.context.Product.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = this.context.Product.Find(id);

        if (product == null)
        {
            return NotFound();
        }
        return product;
    }

    [HttpPost]
    public ActionResult<Product> CreateProduct(Product product)
    {
        if (product == null)
        {
            return BadRequest();
        }
        this.context.Product.Add(product);
        this.context.SaveChanges();
        return CreatedAtAction(nameof(GetProduct), new {id = product.ProductId}, product);
    }

    [HttpDelete]
    public ActionResult<Product> DeleteProduct (int id)
    {
        var product = this.context.Product.Find(id);

        if (product == null)
        {
            return NotFound();
        }
        this.context.Product.Remove(product);
        this.context.SaveChanges(); 
        return NoContent();
    }
}