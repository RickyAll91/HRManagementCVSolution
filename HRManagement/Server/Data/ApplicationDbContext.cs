using Duende.IdentityServer.EntityFramework.Options;
using HRManagement.Shared.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HRManagement.Server.Data
{
    public partial class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions) { }

        public virtual DbSet<Benefit> Benefits { get; set; }

        public virtual DbSet<BenefitContratto> BenefitsContratti { get; set; }

        public virtual DbSet<Candidato> Candidati { get; set; }

        public virtual DbSet<Colloquio> Colloqui { get; set; }

        public virtual DbSet<Comune> Comuni { get; set; }

        public virtual DbSet<Contratto> Contratti { get; set; }

        public virtual DbSet<Dipendente> Dipendenti { get; set; }

        public virtual DbSet<HardSkill> HardSkills { get; set; }

        public virtual DbSet<HardSkillCandidato> HardSkillsCandidati { get; set; }

        public virtual DbSet<HardSkillDipendente> HardSkillsDipendenti { get; set; }

        public virtual DbSet<LivelloContrattuale> LivelliContrattuali { get; set; }

        public virtual DbSet<Mansione> Mansioni { get; set; }

        public virtual DbSet<Provincia> Provincie { get; set; }

        public virtual DbSet<Sede> Sedi { get; set; }

        public virtual DbSet<SoftSkill> SoftSkills { get; set; }

        public virtual DbSet<SoftSkillCandidato> SoftSkillsCandidati { get; set; }

        public virtual DbSet<SoftSkillDipendente> SoftSkillsDipendenti { get; set; }

        public virtual DbSet<TipologiaColloquio> TipologieColloqui { get; set; }

        public virtual DbSet<TipologiaContratto> TipologieContratti { get; set; }

        public virtual DbSet<TipologiaDocumento> TipologieDocumenti { get; set; }

        public virtual DbSet<TitoloStudio> TitoliStudio { get; set; }

        public virtual DbSet<TitoloStudioCandidato> TitoliStudioCandidati { get; set; }

        public virtual DbSet<TitoloStudioDipendente> TitoliStudioDipendenti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BenefitContratto>(entity =>
            {
                entity.HasKey(e => e.BenefitContrattoId).HasName("PK_Benefit_Contratti");

                entity.HasOne(d => d.BenefitNavigation).WithMany(p => p.BenefitsContratti).HasConstraintName("FK_Benefits_Contratti_Benefit");

                entity.HasOne(d => d.ContrattoNavigation).WithMany(p => p.BenefitsContratti)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Benefits_Contratti_Contratto");
            });

            modelBuilder.Entity<Candidato>(entity =>
            {
                entity.HasOne(d => d.ResidenzaNavigation).WithMany(p => p.Candidati)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Candidato_Comune");

                entity.HasOne(d => d.TipoContrattoNavigation).WithMany(p => p.Candidati).HasConstraintName("FK_Candidato_TipologiaContratto");
            });

            modelBuilder.Entity<Colloquio>(entity =>
            {
                entity.HasOne(d => d.HRNavigation).WithMany(p => p.ColloquiHr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Colloquio_DipendenteHR");

                entity.HasOne(d => d.ReferenteTecnicoNavigation).WithMany(p => p.ColloquiReferenteTecnico).HasConstraintName("FK_Colloquio_DipendenteTecnico");

                entity.HasOne(d => d.SedeColloquioNavigation).WithMany(p => p.Colloqui)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Colloquio_Sede");

                entity.HasOne(d => d.TipologiaColloquioNavigation).WithMany(p => p.Colloqui)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Colloquio_TipologiaColloquio");
            });

            modelBuilder.Entity<Comune>(entity =>
            {
                entity.HasOne(d => d.ProvinciaNavigation).WithMany(p => p.Comuni)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comune_Provincia");
            });

            modelBuilder.Entity<Contratto>(entity =>
            {
                entity.HasOne(d => d.LivelloContrattualeNavigation).WithMany(p => p.Contratti)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contratto_LivelloContrattuale");

                entity.HasOne(d => d.TipoDocumentoNavigation).WithMany(p => p.Contratti)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contratto_TipologiaDocumento");

                entity.HasOne(d => d.TipologiaContrattoNavigation).WithMany(p => p.Contratti)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contratto_TipologiaContratto");
            });

            modelBuilder.Entity<Dipendente>(entity =>
            {
                entity.HasOne(d => d.ContrattoNavigation).WithMany(p => p.Dipendenti)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dipendente_Contratto");

                entity.HasOne(d => d.MansioneNavigation).WithMany(p => p.Dipendenti)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mansione_Dipendente");

                entity.HasOne(d => d.SedeNavigation).WithMany(p => p.Dipendenti)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dipendente_Sede");

                entity.HasOne(d => d.UtenteNavigation).WithMany(p => p.Dipendenti).HasConstraintName("FK_Dipendente_AspNetUsers");
            });

            modelBuilder.Entity<HardSkillCandidato>(entity =>
            {
                entity.HasOne(d => d.CandidatoNavigation).WithMany(p => p.HardSkillsCandidati)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HardSkill_Candidato_Candidato");

                entity.HasOne(d => d.HardSkillNavigation).WithMany(p => p.HardSkillsCandidati)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HardSkill_Candidato_HardSkill");
            });

            modelBuilder.Entity<HardSkillDipendente>(entity =>
            {
                entity.HasOne(d => d.DipendenteNavigation).WithMany(p => p.HardSkillsDipendenti)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HardSkill_Dipendente_Dipendente");

                entity.HasOne(d => d.HardSkillNavigation).WithMany(p => p.HardSkillsDipendenti)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HardSkill_Dipendente_HardSkill");
            });

            modelBuilder.Entity<Sede>(entity =>
            {
                entity.Property(e => e.SedeId).ValueGeneratedNever();

                entity.HasOne(d => d.ReferenteNavigation).WithMany(p => p.Sedi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sede_Dipendente");
            });

            modelBuilder.Entity<SoftSkillCandidato>(entity =>
            {
                entity.HasOne(d => d.CandidatoNavigation).WithMany(p => p.SoftSkillCandidati)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SoftSkill_Candidato_Candidato");

                entity.HasOne(d => d.SoftSkillNavigation).WithMany(p => p.SoftSkillsCandidati)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SoftSkill_Candidato_SoftSkill");
            });

            modelBuilder.Entity<SoftSkillDipendente>(entity =>
            {
                entity.HasOne(d => d.DipendenteNavigation).WithMany(p => p.SoftSkillsDipendenti)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SoftSkill_Dipendente_Dipendente");

                entity.HasOne(d => d.SoftSkillNavigation).WithMany(p => p.SoftSkillsDipendenti)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SoftSkill_Dipendente_SoftSkill");
            });

            modelBuilder.Entity<TitoloStudioCandidato>(entity =>
            {
                entity.HasOne(d => d.CandidatoNavigation).WithMany(p => p.TitoliStudioCandidati)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TitoloStudio_Candidato_Candidato");

                entity.HasOne(d => d.TitoloStudioNavigation).WithMany(p => p.TitoliStudioCandidati)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TitoloStudio_Candidato_TitoloStudio");
            });

            modelBuilder.Entity<TitoloStudioDipendente>(entity =>
            {
                entity.HasOne(d => d.DipendenteNavigation).WithMany(p => p.TitoliStudioDipendenti)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TitoloStudio_Dipendente_Dipendente");

                entity.HasOne(d => d.TitoloStudioNavigation).WithMany(p => p.TitoliStudioDipendenti)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TitoloStudio_Dipendente_TitoloStudio");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}