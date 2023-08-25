using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("HardSkill_Dipendente")]
public partial class HardSkillDipendente
{
    [Key]
    public int HardSkillDipendenteId { get; set; }

    public int DipendenteId { get; set; }

    public int HardSkillId { get; set; }

    [ForeignKey("DipendenteId")]
    [InverseProperty("HardSkillsDipendenti")]
    public virtual Dipendente DipendenteNavigation { get; set; } = null!;

    [ForeignKey("Id")]
    [InverseProperty("HardSkillsDipendenti")]
    public virtual HardSkill HardSkillNavigation { get; set; } = null!;
}
