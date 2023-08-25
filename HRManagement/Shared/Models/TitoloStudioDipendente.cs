using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("TitoloStudio_Dipendente")]
public partial class TitoloStudioDipendente
{
    [Key]
    public int TitoloStudioDipendenteId { get; set; }

    public int DipendenteId { get; set; }

    public int TitoloStudioId { get; set; }

    [ForeignKey("DipendenteId")]
    [InverseProperty("TitoliStudioDipendenti")]
    public virtual Dipendente DipendenteNavigation { get; set; } = null!;

    [ForeignKey("Id")]
    [InverseProperty("TitoliStudioDipendenti")]
    public virtual TitoloStudio TitoloStudioNavigation { get; set; } = null!;
}
