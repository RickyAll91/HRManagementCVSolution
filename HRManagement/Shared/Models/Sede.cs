using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("Sede")]
public partial class Sede
{
    [Key]
    public int SedeId { get; set; }

    [StringLength(50)]
    public string Descrizione { get; set; } = null!;

    [StringLength(50)]
    public string Indirizzo { get; set; } = null!;

    [StringLength(50)]
    public string RecapitoTelefonico { get; set; } = null!;

    [StringLength(50)]
    public string EmailSede { get; set; } = null!;

    public int Referente { get; set; }

    [InverseProperty("SedeColloquioNavigation")]
    public virtual ICollection<Colloquio> Colloqui { get; set; } = new List<Colloquio>();

    [InverseProperty("SedeNavigation")]
    public virtual ICollection<Dipendente> Dipendenti { get; set; } = new List<Dipendente>();

    [ForeignKey("Referente")]
    [InverseProperty("Sedi")]
    public virtual Dipendente ReferenteNavigation { get; set; } = null!;
}
