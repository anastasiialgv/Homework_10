using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirst.Entities;

[PrimaryKey(nameof(PCId), nameof(ComponentCode))]
public class PCComponent
{
    public int PCId { get; set; }
    
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; } = string.Empty;

    [Required]
    public int Amount { get; set; }

    [ForeignKey(nameof(PCId))]
    public PC PC { get; set; } = null!;

    [ForeignKey(nameof(ComponentCode))]
    public Component Component { get; set; } = null!;
}