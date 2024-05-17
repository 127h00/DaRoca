/* intermediario entre a linguagem de programação e o bd
 partial -> começa no arquivo a.cs e termina no b.cs; meio q faz o codigo picado, parte em um arquivo
 e outra parte em outra */

using Microsoft.EntityFrameworkCore;

public partial class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DbContext> options) : base(options)
    {

    }

    public virtual DbSet<Customer> Customer { get; set; }

// entidade pode ser tabvela, view, função, storage procedured

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity => {entity.HasKey(k => k.Id);});
        /* ta criando a entidade cliente; pra cada linha (cada registro/entidade)
         to falando que a chave primaira vai ser o Id (k (key) é o Id), faço isso pq pode existir chaves compostas */
        
        OnModelCreating(modelBuilder);
    }
}

