using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("Benefits_Contratti")]
public partial class Benefits_Contratti
{
    [Key]
    public int Benefits_ContrattiId { get; set; }

    public int ContrattoId { get; set; }

    public int? BenefitId { get; set; }

    [ForeignKey("BenefitId")]
    [InverseProperty("Benefits_Contrattis")]
    public virtual Benefit? Benefit { get; set; }

    [ForeignKey("ContrattoId")]
    [InverseProperty("Benefits_Contrattis")]
    public virtual Contratto Contratto { get; set; } = null!;
}
