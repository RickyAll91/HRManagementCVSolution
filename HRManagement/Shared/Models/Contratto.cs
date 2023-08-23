using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("Contratto")]
public partial class Contratto
{
    [Key]
    public int ContrattoId { get; set; }

    public int TipoDocumento { get; set; }

    [StringLength(50)]
    public string NumeroDocumento { get; set; } = null!;

    public int LivelloContrattuale { get; set; }

    public int TipologiaContratto { get; set; }

    [InverseProperty("ContrattoNavigation")]
    public virtual ICollection<BenefitContratto> BenefitsContratti { get; set; } = new List<BenefitContratto>();

    [InverseProperty("ContrattoNavigation")]
    public virtual ICollection<Dipendente> Dipendenti { get; set; } = new List<Dipendente>();

    [ForeignKey("LivelloContrattuale")]
    [InverseProperty("Contratti")]
    public virtual LivelloContrattuale LivelloContrattualeNavigation { get; set; } = null!;

    [ForeignKey("TipoDocumento")]
    [InverseProperty("Contratti")]
    public virtual TipologiaDocumento TipoDocumentoNavigation { get; set; } = null!;

    [ForeignKey("TipologiaContratto")]
    [InverseProperty("Contratti")]
    public virtual TipologiaContratto TipologiaContrattoNavigation { get; set; } = null!;
}
