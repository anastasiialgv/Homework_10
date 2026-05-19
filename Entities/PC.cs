using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirst.Entities;

public class PC
{
    [Key] 
    public int Id { get; set; }

    [Required]
    [MaxLength(50)] 
    public string Name { get; set; } = null!;

    [Required]
    public double Weight { get; set; } 

    [Required]
    public int Warranty { get; set; } 

    [Required]
    public DateTime CreatedAt { get; set; } 

    [Required]
    public int Stock { get; set; } 
    
    public virtual ICollection<PCComponent> PCComponents { get; set; } = new List<PCComponent>();
}