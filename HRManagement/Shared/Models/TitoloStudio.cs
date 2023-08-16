using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("TitoloStudio")]
public partial class TitoloStudio
{
    [Key]
    public int TitoloStudioId { get; set; }

    [StringLength(50)]
    public string Descrizione { get; set; } = null!;

    public bool Attivo { get; set; }

    [InverseProperty("TitoloStudio")]
    public virtual ICollection<TitoloStudio_Candidato> TitoloStudio_Candidatos { get; set; } = new List<TitoloStudio_Candidato>();

    [InverseProperty("TitoloStudio")]
    public virtual ICollection<TitoloStudio_Dipendente> TitoloStudio_Dipendentes { get; set; } = new List<TitoloStudio_Dipendente>();
}
