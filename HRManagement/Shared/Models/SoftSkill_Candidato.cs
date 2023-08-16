using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("SoftSkill_Candidato")]
public partial class SoftSkill_Candidato
{
    [Key]
    public int SofSkillCandidatoId { get; set; }

    public int CandidatoId { get; set; }

    public int SoftSkillId { get; set; }

    [ForeignKey("CandidatoId")]
    [InverseProperty("SoftSkill_Candidatos")]
    public virtual Candidato Candidato { get; set; } = null!;

    [ForeignKey("SoftSkillId")]
    [InverseProperty("SoftSkill_Candidatos")]
    public virtual SoftSkill SoftSkill { get; set; } = null!;
}
