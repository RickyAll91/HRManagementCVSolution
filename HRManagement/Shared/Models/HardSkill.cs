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

    [InverseProperty("HardSkill")]
    public virtual ICollection<HardSkill_Candidato> HardSkill_Candidatos { get; set; } = new List<HardSkill_Candidato>();

    [InverseProperty("HardSkill")]
    public virtual ICollection<HardSkill_Dipendente> HardSkill_Dipendentes { get; set; } = new List<HardSkill_Dipendente>();
}
