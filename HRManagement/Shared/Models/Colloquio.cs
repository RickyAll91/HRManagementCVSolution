using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Shared.Models;

[Table("Colloquio")]
public partial class Colloquio
{
    [Key]
    public int ColloquioId { get; set; }

    public int HR { get; set; }

    public int TipologiaColloquio { get; set; }

    public int? ReferenteTecnico { get; set; }

    public int SedeColloquio { get; set; }

    public int Candidato { get; set; }

    public string? Valutazione { get; set; } = null!;

    public string? Note { get; set; } = null!;

    public DateTime DataColloquio { get; set; } = DateTime.Now;

    [ForeignKey("HR")]
    [InverseProperty("ColloquiHr")]
    public virtual Dipendente? HRNavigation { get; set; } = null!;

    [ForeignKey("Candidato")]
    [InverseProperty("ColloquioCandidato")]
    public virtual Candidato? CandidatoNavigation { get; set; } = null!;

    [ForeignKey("ReferenteTecnico")]
    [InverseProperty("ColloquiReferenteTecnico")]
    public virtual Dipendente? ReferenteTecnicoNavigation { get; set; }

    [ForeignKey("SedeColloquio")]
    [InverseProperty("Colloqui")]
    public virtual Sede? SedeColloquioNavigation { get; set; } = null!;

    [ForeignKey("TipologiaColloquio")]
    [InverseProperty("Colloqui")]
    public virtual TipologiaColloquio? TipologiaColloquioNavigation { get; set; } = null!;
}
