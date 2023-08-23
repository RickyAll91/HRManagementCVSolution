using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("TitoloStudio_Candidato")]
public partial class TitoloStudioCandidato
{
    [Key]
    public int TitoloStudioCandidatoId { get; set; }

    public int CandidatoId { get; set; }

    public int TitoloStudioId { get; set; }

    [ForeignKey("CandidatoId")]
    [InverseProperty("TitoliStudioCandidati")]
    public virtual Candidato CandidatoNavigation { get; set; } = null!;

    [ForeignKey("TitoloStudioId")]
    [InverseProperty("TitoliStudioCandidati")]
    public virtual TitoloStudio TitoloStudioNavigation { get; set; } = null!;
}
