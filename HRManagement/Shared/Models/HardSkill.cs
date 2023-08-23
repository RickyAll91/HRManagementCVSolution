using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("HardSkill")]
public partial class HardSkill
{
    [Key]
    public int HardSkillID { get; set; }

    [StringLength(50)]
    public string Descrizione { get; set; } = null!;

    public bool Attivo { get; set; }

    [InverseProperty("HardSkillNavigation")]
    public virtual ICollection<HardSkillCandidato> HardSkillsCandidati { get; set; } = new List<HardSkillCandidato>();

    [InverseProperty("HardSkillNavigation")]
    public virtual ICollection<HardSkillDipendente> HardSkillsDipendenti { get; set; } = new List<HardSkillDipendente>();
}
