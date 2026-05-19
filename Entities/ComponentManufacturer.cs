using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirst.Entities;

public class ComponentManufacturer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string Abbreviation { get; set; } = null!;

    [Required]
    [MaxLength(300)]
    public string FullName { get; set; } = null!;

    [Required]
    public DateTime FoundationDate { get; set; }
    
    public virtual ICollection<Component> Components { get; set; } = new List<Component>();
}