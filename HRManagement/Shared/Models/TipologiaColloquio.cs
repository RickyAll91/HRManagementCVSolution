using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("TipologiaColloquio")]
public partial class TipologiaColloquio
{
    [Key]
    public int TipoColloquioId { get; set; }

    [StringLength(50)]
    public string Descrizione { get; set; } = null!;

    [InverseProperty("TipologiaColloquioNavigation")]
    public virtual ICollection<Colloquio> Colloqui { get; set; } = new List<Colloquio>();
}
