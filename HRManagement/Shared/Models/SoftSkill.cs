using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("SoftSkill")]
public partial class SoftSkill
{
    [Key]
    public int SoftSkillId { get; set; }

    [StringLength(50)]
    public string Descrizione { get; set; } = null!;

    public bool Attivo { get; set; }

    [InverseProperty("SoftSkillNavigation")]
    public virtual ICollection<SoftSkillCandidato> SoftSkillsCandidati { get; set; } = new List<SoftSkillCandidato>();

    [InverseProperty("SoftSkillNavigation")]
    public virtual ICollection<SoftSkillDipendente> SoftSkillsDipendenti { get; set; } = new List<SoftSkillDipendente>();
}
