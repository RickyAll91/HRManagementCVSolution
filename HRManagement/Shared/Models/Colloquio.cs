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

    public string Valutazione { get; set; } = null!;

    public string Note { get; set; } = null!;

    [ForeignKey("HR")]
    [InverseProperty("ColloquioHRNavigations")]
    public virtual Dipendente HRNavigation { get; set; } = null!;

    [ForeignKey("ReferenteTecnico")]
    [InverseProperty("ColloquioReferenteTecnicoNavigations")]
    public virtual Dipendente? ReferenteTecnicoNavigation { get; set; }

    [ForeignKey("SedeColloquio")]
    [InverseProperty("Colloquios")]
    public virtual Sede SedeColloquioNavigation { get; set; } = null!;

    [ForeignKey("TipologiaColloquio")]
    [InverseProperty("Colloquios")]
    public virtual TipologiaColloquio TipologiaColloquioNavigation { get; set; } = null!;
}
