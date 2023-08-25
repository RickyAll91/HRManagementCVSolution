using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("Benefits_Contratti")]
public partial class BenefitContratto
{
    [Key]
    public int BenefitContrattoId { get; set; }

    public int ContrattoId { get; set; }

    public int? BenefitId { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("BenefitsContratti")]
    public virtual Benefit? BenefitNavigation { get; set; }

    [ForeignKey("ContrattoId")]
    [InverseProperty("BenefitsContratti")]
    public virtual Contratto ContrattoNavigation { get; set; } = null!;
}
