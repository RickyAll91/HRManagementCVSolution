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

    [InverseProperty("Contratto")]
    public virtual ICollection<Benefits_Contratti> Benefits_Contrattis { get; set; } = new List<Benefits_Contratti>();

    [InverseProperty("ContrattoNavigation")]
    public virtual ICollection<Dipendente> Dipendentes { get; set; } = new List<Dipendente>();

    [ForeignKey("LivelloContrattuale")]
    [InverseProperty("Contrattos")]
    public virtual LivelloContrattuale LivelloContrattualeNavigation { get; set; } = null!;

    [ForeignKey("TipoDocumento")]
    [InverseProperty("Contrattos")]
    public virtual TipologiaDocumento TipoDocumentoNavigation { get; set; } = null!;

    [ForeignKey("TipologiaContratto")]
    [InverseProperty("Contrattos")]
    public virtual TipologiaContratto TipologiaContrattoNavigation { get; set; } = null!;
}
