using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("HardSkill_Dipendente")]
public partial class HardSkill_Dipendente
{
    [Key]
    public int HardSkillDipendenteId { get; set; }

    public int DipendenteId { get; set; }

    public int HardSkillId { get; set; }

    [ForeignKey("DipendenteId")]
    [InverseProperty("HardSkill_Dipendentes")]
    public virtual Dipendente Dipendente { get; set; } = null!;

    [ForeignKey("HardSkillId")]
    [InverseProperty("HardSkill_Dipendentes")]
    public virtual HardSkill HardSkill { get; set; } = null!;
}
