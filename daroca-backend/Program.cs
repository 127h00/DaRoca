using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // adiciona a camada controller
builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Configuration -> tenho metodos prontos para abrir aquele arquivo
// se eu mudar o user bd ele vai atualizar automaticamente

builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

var teste = new SalesOrder(){
    OrderId = 1,
    CustomerId = 2,
    OrderDate = DateTime.Now,
    Status = "teste"
};

teste.MakeOrder(1, 3, 1, 10);
teste.MakeOrder(1, 4, 2, 20);
Console.WriteLine(teste.OrderTotalPrice(1));

teste.MakeOrder(2, 4, 1, 70);
Console.WriteLine(teste.OrderTotalPrice(2));