using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models;

[Table("Dipendente")]
public partial class Dipendente
{
    [Key]
    public int DipendenteId { get; set; }

    [StringLength(50)]
    public string Nome { get; set; } = null!;

    [StringLength(50)]
    public string Cognome { get; set; } = null!;

    [StringLength(16)]
    public string CF { get; set; } = null!;

    public int Sede { get; set; }

    public int Mansione { get; set; }

    public int Contratto { get; set; }

    [StringLength(450)]
    public string? Utente { get; set; }

    [InverseProperty("HRNavigation")]
    public virtual ICollection<Colloquio> ColloquioHRNavigations { get; set; } = new List<Colloquio>();

    [InverseProperty("ReferenteTecnicoNavigation")]
    public virtual ICollection<Colloquio> ColloquioReferenteTecnicoNavigations { get; set; } = new List<Colloquio>();

    [ForeignKey("Contratto")]
    [InverseProperty("Dipendentes")]
    public virtual Contratto ContrattoNavigation { get; set; } = null!;

    [InverseProperty("Dipendente")]
    public virtual ICollection<HardSkill_Dipendente> HardSkill_Dipendentes { get; set; } = new List<HardSkill_Dipendente>();

    [ForeignKey("Mansione")]
    [InverseProperty("Dipendentes")]
    public virtual Mansione MansioneNavigation { get; set; } = null!;

    [ForeignKey("Sede")]
    [InverseProperty("Dipendentes")]
    public virtual Sede SedeNavigation { get; set; } = null!;

    [InverseProperty("ReferenteNavigation")]
    public virtual ICollection<Sede> Sedes { get; set; } = new List<Sede>();

    [InverseProperty("Dipendente")]
    public virtual ICollection<SoftSkill_Dipendente> SoftSkill_Dipendentes { get; set; } = new List<SoftSkill_Dipendente>();

    [InverseProperty("Dipendente")]
    public virtual ICollection<TitoloStudio_Dipendente> TitoloStudio_Dipendentes { get; set; } = new List<TitoloStudio_Dipendente>();

    [ForeignKey("Utente")]
    [InverseProperty("Dipendentes")]
    public virtual ApplicationUser? UtenteNavigation { get; set; }
}
