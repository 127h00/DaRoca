using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Route("/[controller]")] // ou seja, quando colocar /customer (porque é o nome desse controller) ele vai usar os endpoints daqui
[ApiController]
public class CustomerController : ControllerBase
{

}