using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirst.Entities;

public class Component
{
    [Key]
    [Column(TypeName = "char(10)")] 
    public string Code { get; set; } = null!;

    [Required]
    [MaxLength(300)]
    public string Name { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!; 

    [Required]
    public int ComponentManufacturersId { get; set; }

    [Required]
    public int ComponentTypesId { get; set; }

    [ForeignKey(nameof(ComponentManufacturersId))]
    public virtual ComponentManufacturer Manufacturer { get; set; } = null!;

    [ForeignKey(nameof(ComponentTypesId))]
    public virtual ComponentType Type { get; set; } = null!;
    
    public virtual ICollection<PCComponent> PCComponents { get; set; } = new List<PCComponent>();
}