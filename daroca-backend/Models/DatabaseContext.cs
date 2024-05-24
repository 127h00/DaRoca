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

    public virtual DbSet<Customer> Customer { get; set; }

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}