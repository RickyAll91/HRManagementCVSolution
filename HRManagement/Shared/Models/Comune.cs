using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("Comune")]
public partial class Comune
{
    [Key]
    public int ComuneId { get; set; }

    [StringLength(50)]
    public string Nome { get; set; } = null!;

    public int Provincia { get; set; }

    [InverseProperty("ResidenzaNavigation")]
    public virtual ICollection<Candidato> Candidatos { get; set; } = new List<Candidato>();

    [ForeignKey("Provincia")]
    [InverseProperty("Comunes")]
    public virtual Provincium ProvinciaNavigation { get; set; } = null!;
}
