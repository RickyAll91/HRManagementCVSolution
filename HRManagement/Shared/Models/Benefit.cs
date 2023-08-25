using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("Benefit")]
public partial class Benefit : IAnagraficaModel
{
    [Key]
    [Column("BenefitId")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Descrizione { get; set; } = null!;

    public bool Attivo { get; set; }

    [InverseProperty("BenefitNavigation")]
    public virtual ICollection<BenefitContratto> BenefitsContratti { get; set; } = new List<BenefitContratto>();
}
