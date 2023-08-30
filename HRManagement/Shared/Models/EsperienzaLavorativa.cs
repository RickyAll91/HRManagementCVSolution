using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HRManagement.Shared.Models
{
    [Table("Esperienze")]
    [Index("Candidato", Name = "IX_Esperienze_Candidato")]
    [Index("Mansione", Name = "IX_Esperienze_Mansione")]
    public partial class EsperienzaLavorativa
    {
        [Key]
        public int Id { get; set; }
        public int Candidato { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public int Mansione { get; set; }
        [MaxLength(50)]
        public string Azienda { get; set; } = null!;
        public string Descrizione { get; set; } = null!;
        [ForeignKey("Mansione")]
        [InverseProperty("EsperienzeLavorative")]
        public virtual Mansione? MansioneNavigation { get; set; }
        [ForeignKey("Candidato")]
        [InverseProperty("EsperienzeLavorative")]
        public virtual Candidato? CandidatoNavigation { get; set; }

    }
}
