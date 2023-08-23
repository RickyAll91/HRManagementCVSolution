using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("HardSkill_Candidato")]
public partial class HardSkillCandidato
{
    [Key]
    public int HardSkillCandidatoId { get; set; }

    public int CandidatoId { get; set; }

    public int HardSkillId { get; set; }

    [ForeignKey("CandidatoId")]
    [InverseProperty("HardSkillsCandidati")]
    public virtual Candidato CandidatoNavigation { get; set; } = null!;

    [ForeignKey("HardSkillId")]
    [InverseProperty("HardSkillsCandidati")]
    public virtual HardSkill HardSkillNavigation { get; set; } = null!;
}
