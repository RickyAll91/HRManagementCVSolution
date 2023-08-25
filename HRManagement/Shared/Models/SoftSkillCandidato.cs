using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("SoftSkill_Candidato")]
public partial class SoftSkillCandidato
{
    [Key]
    public int SofSkillCandidatoId { get; set; }

    public int CandidatoId { get; set; }

    public int SoftSkillId { get; set; }

    [ForeignKey("CandidatoId")]
    [InverseProperty("SoftSkillCandidati")]
    public virtual Candidato CandidatoNavigation { get; set; } = null!;

    [ForeignKey("Id")]
    [InverseProperty("SoftSkillsCandidati")]
    public virtual SoftSkill SoftSkillNavigation { get; set; } = null!;
}
