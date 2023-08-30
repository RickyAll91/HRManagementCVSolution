using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("Mansione")]
public partial class Mansione : IAnagraficaModel
{
    [Key]
    [Column("MansioneId")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Descrizione { get; set; } = null!;

    public bool Attivo { get; set; }

    [InverseProperty("MansioneNavigation")]
    public virtual ICollection<Dipendente> Dipendenti { get; set; } = new List<Dipendente>();
    [InverseProperty("MansioneNavigation")]
    public virtual ICollection<EsperienzaLavorativa> EsperienzeLavorative { get; set; } = new List<EsperienzaLavorativa>();
}
