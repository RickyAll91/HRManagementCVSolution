using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("Mansione")]
public partial class Mansione
{
    [Key]
    public int MansioneId { get; set; }

    [StringLength(50)]
    public string Descrizione { get; set; } = null!;

    public bool Attivo { get; set; }

    [InverseProperty("MansioneNavigation")]
    public virtual ICollection<Dipendente> Dipendentes { get; set; } = new List<Dipendente>();
}
