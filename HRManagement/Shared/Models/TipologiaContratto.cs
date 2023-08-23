using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("TipologiaContratto")]
public partial class TipologiaContratto
{
    [Key]
    public int TipoContrattoId { get; set; }

    [StringLength(50)]
    public string Descrizione { get; set; } = null!;

    public bool Attivo { get; set; }

    [InverseProperty("TipoContrattoNavigation")]
    public virtual ICollection<Candidato> Candidati { get; set; } = new List<Candidato>();

    [InverseProperty("TipologiaContrattoNavigation")]
    public virtual ICollection<Contratto> Contratti { get; set; } = new List<Contratto>();
}
