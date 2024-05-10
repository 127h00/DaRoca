using System.ComponentModel.DataAnnotations; // essa classe vai "interpretar" essa classe para criar o banco de dados dela
// usa conceito de anotation [] 

// Entity permite que usemos o banco de dados sem de fato criar as tabelas e bla bla bla, faremos isso pelo c#
// ele vai ver se a tablea existe e se ela existir ele vai lá e cria

public class Customer
{
    [Key] // isso significa que o Id vai ser a minha PK 
    // por padrão a PK é not null, então não precisamos colocar [Required]
    public int Id {get; set; } // estilo property

    [Required] // not null
    [MaxLength(50)] // varchar(50)
    public string Name {get; set; }

    [Required]
    [MaxLength(50)]
    public string Email { get; set; }

    public double Latitude { get; set; }
    
    public double Longitude { get; set; }
}