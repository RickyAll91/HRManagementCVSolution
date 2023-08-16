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

    [InverseProperty("SoftSkill")]
    public virtual ICollection<SoftSkill_Candidato> SoftSkill_Candidatos { get; set; } = new List<SoftSkill_Candidato>();

    [InverseProperty("SoftSkill")]
    public virtual ICollection<SoftSkill_Dipendente> SoftSkill_Dipendentes { get; set; } = new List<SoftSkill_Dipendente>();
}
