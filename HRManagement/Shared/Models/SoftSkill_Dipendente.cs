using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("SoftSkill_Dipendente")]
public partial class SoftSkill_Dipendente
{
    [Key]
    public int SoftSkillDipendenteId { get; set; }

    public int DipendenteId { get; set; }

    public int SoftSkillId { get; set; }

    [ForeignKey("DipendenteId")]
    [InverseProperty("SoftSkill_Dipendentes")]
    public virtual Dipendente Dipendente { get; set; } = null!;

    [ForeignKey("SoftSkillId")]
    [InverseProperty("SoftSkill_Dipendentes")]
    public virtual SoftSkill SoftSkill { get; set; } = null!;
}
