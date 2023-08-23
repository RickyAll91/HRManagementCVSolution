using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Shared.Models

{
    [Table("AspNetUsers")]
    [Microsoft.EntityFrameworkCore.Index("NormalizedEmail", Name = "EmailIndex")]
    public class ApplicationUser : IdentityUser
    { 
        [InverseProperty("UtenteNavigation")]
        public virtual ICollection<Dipendente> Dipendenti { get; set; } = new List<Dipendente>();
    }
}