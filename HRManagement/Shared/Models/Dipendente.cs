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
    public virtual ICollection<Colloquio> ColloquiHr { get; set; } = new List<Colloquio>();

    [InverseProperty("ReferenteTecnicoNavigation")]
    public virtual ICollection<Colloquio> ColloquiReferenteTecnico { get; set; } = new List<Colloquio>();

    [ForeignKey("Contratto")]
    [InverseProperty("Dipendenti")]
    public virtual Contratto? ContrattoNavigation { get; set; } = null!;

    [InverseProperty("DipendenteNavigation")]
    public virtual ICollection<HardSkillDipendente> HardSkillsDipendenti { get; set; } = new List<HardSkillDipendente>();

    [ForeignKey("Mansione")]
    [InverseProperty("Dipendenti")]
    public virtual Mansione? MansioneNavigation { get; set; } = null!;

    [ForeignKey("Sede")]
    [InverseProperty("Dipendenti")]
    public virtual Sede? SedeNavigation { get; set; } = null!;

    [InverseProperty("ReferenteNavigation")]
    public virtual ICollection<Sede> Sedi { get; set; } = new List<Sede>();

    [InverseProperty("DipendenteNavigation")]
    public virtual ICollection<SoftSkillDipendente> SoftSkillsDipendenti { get; set; } = new List<SoftSkillDipendente>();

    [InverseProperty("DipendenteNavigation")]
    public virtual ICollection<TitoloStudioDipendente> TitoliStudioDipendenti { get; set; } = new List<TitoloStudioDipendente>();

    [ForeignKey("Utente")]
    [InverseProperty("Dipendenti")]
    public virtual ApplicationUser? UtenteNavigation { get; set; }
}
