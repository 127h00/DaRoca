using Microsoft.Identity.Client;
using Microsoft.Net.Http.Headers;

public class SalesOrder 
{
    public int OrderId { get; set; }
    public int CustomerId { get; set;}
    public required DateTime OrderDate { get; set; }
    public DateOnly EstimatedDeliveryDate { get; set; }
    public required string Status { get; set; }
    public List<SalesOrderItem> Pedidos { get; set; }

    public SalesOrder()
    {
        Pedidos = new List<SalesOrderItem>();
    }

    public void MakeOrder (int OrderId, int ProductId, int Quantity, decimal UnitPrice)
    {
       var salesOrdemItem = new SalesOrderItem()
       {
            OrderId = OrderId,
            ProductId = ProductId,
            Quantity = Quantity,
            UnitPrice = UnitPrice
       };
       Pedidos.Add(salesOrdemItem);
    }

    public string OrderTotalPrice(int OId)
    {
        var report = new System.Text.StringBuilder();
        report.AppendLine("Order ID\tProduct ID\tQuantity\tUnit Price");

        decimal balance = 0;

        foreach (var item in this.Pedidos)
        {
            if (OId == item.OrderId) {
                balance += item.UnitPrice * item.Quantity;
                report.AppendLine($"{item.OrderId}\t\t{item.ProductId}\t\t{item.Quantity}\t\t{item.UnitPrice}");
            }
        }
        report.AppendLine($"Total price: R${balance}");

        return report.ToString();
    }
}