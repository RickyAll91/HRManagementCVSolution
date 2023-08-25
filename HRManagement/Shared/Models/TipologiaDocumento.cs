using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("TipologiaDocumento")]
public partial class TipologiaDocumento : IAnagraficaModel
{
    [Key]
    [Column("TipoDocumentoId")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Descrizione { get; set; } = null!;

    public bool Attivo { get; set; }

    [InverseProperty("TipoDocumentoNavigation")]
    public virtual ICollection<Contratto> Contratti { get; set; } = new List<Contratto>();
}
