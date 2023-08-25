using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("LivelloContrattuale")]
public partial class LivelloContrattuale : IAnagraficaModel
{
    [Key]
    [Column("LivelloContrattoId")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Descrizione { get; set; } = null!;

    public bool Attivo { get; set; }

    [InverseProperty("LivelloContrattualeNavigation")]
    public virtual ICollection<Contratto> Contratti { get; set; } = new List<Contratto>();
}
