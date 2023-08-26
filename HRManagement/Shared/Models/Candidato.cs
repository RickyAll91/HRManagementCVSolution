using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Shared.Models;

[Table("Candidato")]
public partial class Candidato
{
    [Key]
    public int CandidatoId { get; set; }

    [StringLength(50)]
    public string Nome { get; set; } = null!;

    [StringLength(50)]
    public string Cognome { get; set; } = null!;

    [StringLength(16)]
    public string CF { get; set; } = null!;

    [StringLength(50)]
    public string RecapitoTelefonico { get; set; } = null!;

    [StringLength(50)]
    public string Email { get; set; } = null!;

    [StringLength(50)]
    public string StatoNascita { get; set; } = null!;

    [StringLength(50)]
    public string ProvinciaNascita { get; set; } = null!;

    [StringLength(50)]
    public string ComuneNascita { get; set; } = null!;

    public int Residenza { get; set; }

    public int? TipoContratto { get; set; }

    [InverseProperty("CandidatoNavigation")]
    public virtual ICollection<HardSkillCandidato> HardSkillsCandidati { get; set; } = new List<HardSkillCandidato>();

    [InverseProperty("CandidatoNavigation")]
    public virtual ICollection<Colloquio> ColloquioCandidato { get; set; } = new List<Colloquio>();

    [ForeignKey("Residenza")]
    [InverseProperty("Candidati")]
    public virtual Comune? ResidenzaNavigation { get; set; } = null!;

    [InverseProperty("CandidatoNavigation")]
    public virtual ICollection<SoftSkillCandidato> SoftSkillCandidati { get; set; } = new List<SoftSkillCandidato>();

    [ForeignKey("TipoContratto")]
    [InverseProperty("Candidati")]
    public virtual TipologiaContratto? TipoContrattoNavigation { get; set; }

    [InverseProperty("CandidatoNavigation")]
    public virtual ICollection<TitoloStudioCandidato> TitoliStudioCandidati { get; set; } = new List<TitoloStudioCandidato>();
}
