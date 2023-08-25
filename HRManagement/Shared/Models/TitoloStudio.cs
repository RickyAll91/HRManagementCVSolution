using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("TitoloStudio")]
public partial class TitoloStudio : IAnagraficaModel
{
    [Key]
    [Column("TitoloStudioId")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Descrizione { get; set; } = null!;

    public bool Attivo { get; set; }

    [InverseProperty("TitoloStudioNavigation")]
    public virtual ICollection<TitoloStudioCandidato> TitoliStudioCandidati { get; set; } = new List<TitoloStudioCandidato>();

    [InverseProperty("TitoloStudioNavigation")]
    public virtual ICollection<TitoloStudioDipendente> TitoliStudioDipendenti { get; set; } = new List<TitoloStudioDipendente>();
}
