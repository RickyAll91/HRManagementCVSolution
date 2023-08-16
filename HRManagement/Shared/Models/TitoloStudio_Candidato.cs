using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("TitoloStudio_Candidato")]
public partial class TitoloStudio_Candidato
{
    [Key]
    public int TitoloStudioCandidatoId { get; set; }

    public int CandidatoId { get; set; }

    public int TitoloStudioId { get; set; }

    [ForeignKey("CandidatoId")]
    [InverseProperty("TitoloStudio_Candidatos")]
    public virtual Candidato Candidato { get; set; } = null!;

    [ForeignKey("TitoloStudioId")]
    [InverseProperty("TitoloStudio_Candidatos")]
    public virtual TitoloStudio TitoloStudio { get; set; } = null!;
}
