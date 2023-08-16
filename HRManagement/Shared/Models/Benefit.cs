using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("Benefit")]
public partial class Benefit
{
    [Key]
    public int BenefitId { get; set; }

    [StringLength(50)]
    public string Descrizione { get; set; } = null!;

    public bool Attivo { get; set; }

    [InverseProperty("Benefit")]
    public virtual ICollection<Benefits_Contratti> Benefits_Contrattis { get; set; } = new List<Benefits_Contratti>();
}
