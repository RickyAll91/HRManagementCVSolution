using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("TitoloStudio_Dipendente")]
public partial class TitoloStudio_Dipendente
{
    [Key]
    public int TitoloStudioDipendenteId { get; set; }

    public int DipendenteId { get; set; }

    public int TitoloStudioId { get; set; }

    [ForeignKey("DipendenteId")]
    [InverseProperty("TitoloStudio_Dipendentes")]
    public virtual Dipendente Dipendente { get; set; } = null!;

    [ForeignKey("TitoloStudioId")]
    [InverseProperty("TitoloStudio_Dipendentes")]
    public virtual TitoloStudio TitoloStudio { get; set; } = null!;
}
