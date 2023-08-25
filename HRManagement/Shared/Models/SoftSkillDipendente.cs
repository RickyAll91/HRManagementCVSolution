using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("SoftSkill_Dipendente")]
public partial class SoftSkillDipendente
{
    [Key]
    public int SoftSkillDipendenteId { get; set; }

    public int DipendenteId { get; set; }

    public int SoftSkillId { get; set; }

    [ForeignKey("DipendenteId")]
    [InverseProperty("SoftSkillsDipendenti")]
    public virtual Dipendente DipendenteNavigation { get; set; } = null!;

    [ForeignKey("Id")]
    [InverseProperty("SoftSkillsDipendenti")]
    public virtual SoftSkill SoftSkillNavigation { get; set; } = null!;
}
