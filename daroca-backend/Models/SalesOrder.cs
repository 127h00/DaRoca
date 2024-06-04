using Microsoft.Identity.Client;
using Microsoft.Net.Http.Headers;

public class SalesOrder 
{
    public int OrderId { get; set; }
    public int CustomerId { get; set;}
    public required DateTime OrderDate { get; set; }
    public DateOnly EstimatedDeliveryDate { get; set; }
    public required string Status { get; set; }

}