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

    [InverseProperty("Candidato")]
    public virtual ICollection<HardSkill_Candidato> HardSkill_Candidatos { get; set; } = new List<HardSkill_Candidato>();

    [ForeignKey("Residenza")]
    [InverseProperty("Candidatos")]
    public virtual Comune ResidenzaNavigation { get; set; } = null!;

    [InverseProperty("Candidato")]
    public virtual ICollection<SoftSkill_Candidato> SoftSkill_Candidatos { get; set; } = new List<SoftSkill_Candidato>();

    [ForeignKey("TipoContratto")]
    [InverseProperty("Candidatos")]
    public virtual TipologiaContratto? TipoContrattoNavigation { get; set; }

    [InverseProperty("Candidato")]
    public virtual ICollection<TitoloStudio_Candidato> TitoloStudio_Candidatos { get; set; } = new List<TitoloStudio_Candidato>();
}
