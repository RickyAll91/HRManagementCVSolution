using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("TipologiaColloquio")]
public partial class TipologiaColloquio : IAnagraficaModel
{
    [Key]
    [Column("TipoColloquioId")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Descrizione { get; set; } = null!;
    
    public bool Attivo { get; set; }

    [InverseProperty("TipologiaColloquioNavigation")]
    public virtual ICollection<Colloquio> Colloqui { get; set; } = new List<Colloquio>();
}
