using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

[Route("/[controller]")] // ou seja, quando colocar /customer (porque é o nome desse controller) ele vai usar os endpoints daqui
// isso aq de cima faz o controller assumir o nome da classe
[ApiController]
public class ProductController : ControllerBase
{
    private readonly DataBaseContext context; // meu user e senha

    public ProductController(DataBaseContext context)
    {
        this.context = context;
    }

    [HttpGet] // sempre q eu acessar esse recurso com o verbo GET ele vai chamar o método abaixo
    public ActionResult<IEnumerable<Product>> GetProduct()
    {
        return this.context.Product.ToList();
        // peguei o usuario e senha . tabela do bd . transformo em lista pq ele nos traz em objeto
    }

    [HttpGet("{id}")] // toda vez q no postman ele usarem esse endpoint / id ele vai chamar esse método
// ActionResult -> """converte""" o return de objeto pra JSON
    public ActionResult<Product> GetProduct(int id)
    {
        var product = this.context.Product.Find(id);

        if (product == null)
        {
            return NotFound(); // erro 404
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
        this.context.Product.Add(product); // criaaaaaa
        this.context.SaveChanges(); // se n salvar ele n vai jogar no banco de dados
        return CreatedAtAction(nameof(GetProduct), new {id = product.ProductId}, product);
        /* CreatedAtAction -> adiciona um novo registro no BD e já retorna pro cliente oq foi criado
        oq significa que foi inserido com sucessp */
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