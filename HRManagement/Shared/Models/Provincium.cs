using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

public partial class Provincium
{
    [Key]
    public int ProvinciaId { get; set; }

    [StringLength(50)]
    public string Nome { get; set; } = null!;

    [InverseProperty("ProvinciaNavigation")]
    public virtual ICollection<Comune> Comunes { get; set; } = new List<Comune>();
}
