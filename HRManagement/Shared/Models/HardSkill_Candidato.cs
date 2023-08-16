using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("HardSkill_Candidato")]
public partial class HardSkill_Candidato
{
    [Key]
    public int HardSkillCandidatoId { get; set; }

    public int CandidatoId { get; set; }

    public int HardSkillId { get; set; }

    [ForeignKey("CandidatoId")]
    [InverseProperty("HardSkill_Candidatos")]
    public virtual Candidato Candidato { get; set; } = null!;

    [ForeignKey("HardSkillId")]
    [InverseProperty("HardSkill_Candidatos")]
    public virtual HardSkill HardSkill { get; set; } = null!;
}
