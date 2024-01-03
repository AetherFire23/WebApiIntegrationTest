using System.ComponentModel.DataAnnotations;

namespace WebApplication1;

public class MyEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FunName { get; set; } = "Lolzida";
}
