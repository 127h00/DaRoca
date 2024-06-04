/* intermediario entre a linguagem de programação e o bd
 partial -> começa no arquivo a.cs e termina no b.cs; meio q faz o codigo picado, parte em um arquivo
 e outra parte em outra */

using Microsoft.EntityFrameworkCore;

// FLUENT API 
public partial class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {

    }

    public virtual DbSet<Customer> Customer { get; set; } // lista com todos os registros que tem no BD
    public virtual DbSet<Product> Product { get; set; }
    public virtual DbSet<ProductCategory> ProductCategory { get; set; }
    public virtual DbSet<SalesOrder> SalesOrder { get; set; }
    public virtual DbSet<SalesOrderItem> SalesOrderItem { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // isso é fluent API, nao usamos anotations

        modelBuilder.Entity<Customer>().HasKey(e => e.CustomerId); // defini a minha primary key da tabela
        // agora vou de atributo a atributo para definir as coisas
        modelBuilder.Entity<Customer>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.City).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.State).HasMaxLength(30).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.Latitude).HasPrecision(11, 3).IsRequired();
        // HasPrecision(quantidade de numeros antes do ponto, quantidade de numeros depois do ponto)
        modelBuilder.Entity<Customer>().Property(p => p.Longitude).HasPrecision(11, 3).IsRequired();
        modelBuilder.Entity<Customer>().HasMany<SalesOrder>().WithOne().HasForeignKey(e => e.CustomerId); // !!!!!!!!!!!!!!!!

        modelBuilder.Entity<ProductCategory>().HasKey(e => e.ProductCategoryId);
        modelBuilder.Entity<ProductCategory>().Property(p => p.Name).HasMaxLength(50).IsRequired(); 
        modelBuilder.Entity<ProductCategory>().HasMany<Product>().WithOne().HasForeignKey(e => e.ProductCategoryId); // !!!!!!!!!!!!!!!!
        // estamos olhando para o ProductCategory* O ProductCategory TEM MUITOS <PRODUTOS> já olhando o Product ele tem APENAS UMA categoria, e temos uma FK que é a PRODUCTCATEGORYID

        modelBuilder.Entity<Product>().HasKey(e => e.ProductId);
        modelBuilder.Entity<Product>().Property(p => p.ProductCategoryId).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasPrecision(11, 5).IsRequired();
        modelBuilder.Entity<Product>().HasMany<SalesOrderItem>().WithOne().HasForeignKey(e => e.ProductId);

        modelBuilder.Entity<SalesOrder>().HasKey(e => e.OrderId);
        modelBuilder.Entity<SalesOrder>().Property(p => p.CustomerId).IsRequired();
        modelBuilder.Entity<SalesOrder>().Property(p => p.OrderDate).IsRequired();
        modelBuilder.Entity<SalesOrder>().Property(p => p.EstimatedDeliveryDate);
        modelBuilder.Entity<SalesOrder>().Property(p => p.Status).HasMaxLength(20).IsRequired();
        modelBuilder.Entity<SalesOrder>().HasMany<SalesOrderItem>().WithOne().HasForeignKey(e => e.ProductId);

        modelBuilder.Entity<SalesOrderItem>().HasKey(e => new {e.OrderId, e.ProductId}); // PK COMPOSTAAAAAAAA e faz o relacionamento 
        modelBuilder.Entity<SalesOrderItem>().Property(p => p.Quantity).IsRequired();
        modelBuilder.Entity<SalesOrderItem>().Property(p => p.UnitPrice).HasPrecision(11, 5).IsRequired();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

      //  modelBuilder.Entity<SalesOrder>().HasOne<Customer>().WithMany().HasForeignKey(e => e.CustomerId); // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!