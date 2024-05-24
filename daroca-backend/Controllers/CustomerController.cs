using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

[Route("/[controller]")] // ou seja, quando colocar /customer (porque é o nome desse controller) ele vai usar os endpoints daqui
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly DataBaseContext context; // meu user e senha

    public CustomerController(DataBaseContext context)
    {
        this.context = context;
    }

    [HttpGet] // sempre q eu acessar esse recurso com o verbo GET ele vai chamar o método abaixo
    public ActionResult<IEnumerable<Customer>> GetCustomers()
    {
        return this.context.Customer.ToList();
        // peguei o usuario e senha . tabela do bd . transformo em lista pq ele nos traz em objeto
    }

    [HttpGet("{id}")] // toda vez q no postman ele usarem esse endpoint / id ele vai chamar esse método
// ActionResult -> """converte""" o return de objeto pra JSON
    public ActionResult<Customer> GetCustomer(int id)
    {
        var customer = this.context.Customer.Find(id);

        if (customer == null)
        {
            return NotFound(); // erro 404
        }
        return customer;
    }

    [HttpPost]
    public ActionResult<Customer> CreateCustomer(Customer customer)
    {
        if (customer == null)
        {
            return BadRequest();
        }
        this.context.Customer.Add(customer); // criaaaaaa
        this.context.SaveChanges(); // se n salvar ele n vai jogar no banco de dados
        return CreatedAtAction(nameof(GetCustomer), new {id = customer.CustomerId}, customer);
        /* CreatedAtAction -> adiciona um novo registro no BD e já retorna pro cliente oq foi criado
        oq significa que foi inserido com sucessp */
    }

    [HttpDelete]
    public ActionResult<Customer> DeleteCustomer (int id)
    {
        var customer = this.context.Customer.Find(id);

        if (customer == null)
        {
            return NotFound();
        }
        this.context.Customer.Remove(customer);
        this.context.SaveChanges(); 
        return NoContent();
    }
}