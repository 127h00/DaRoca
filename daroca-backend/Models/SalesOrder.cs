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

    public string OrderTotalPrice()
    {
        var report = new System.Text.StringBuilder();
        report.AppendLine("Amount\tDate\t\tBalance\t\tNote");

        decimal balance = 0;

        foreach (var item in this.Pedidos)
        {
            balance += item.UnitPrice * item.Quantity;
            report.AppendLine($"{item.OrderId}\t{item.ProductId}\t{item.Quantity}\t{item.Quantity}");
        }
        report.AppendLine($"Total price: R${balance}");

        return report.ToString();
    }
}