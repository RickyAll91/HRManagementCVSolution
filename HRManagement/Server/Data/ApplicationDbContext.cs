using Duende.IdentityServer.EntityFramework.Options;
using HRManagement.Shared.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HRManagement.Server.Data
{
    public partial class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions) {}

        public virtual DbSet<Benefit> Benefits { get; set; }

        public virtual DbSet<Benefits_Contratti> Benefits_Contrattis { get; set; }

        public virtual DbSet<Candidato> Candidatos { get; set; }

        public virtual DbSet<Colloquio> Colloquios { get; set; }

        public virtual DbSet<Comune> Comunes { get; set; }

        public virtual DbSet<Contratto> Contrattos { get; set; }

        public virtual DbSet<Dipendente> Dipendentes { get; set; }

        public virtual DbSet<HardSkill> HardSkills { get; set; }

        public virtual DbSet<HardSkill_Candidato> HardSkill_Candidatos { get; set; }

        public virtual DbSet<HardSkill_Dipendente> HardSkill_Dipendentes { get; set; }

        public virtual DbSet<LivelloContrattuale> LivelloContrattuales { get; set; }

        public virtual DbSet<Mansione> Mansiones { get; set; }

        public virtual DbSet<Provincium> Provincia { get; set; }

        public virtual DbSet<Sede> Sedes { get; set; }

        public virtual DbSet<SoftSkill> SoftSkills { get; set; }

        public virtual DbSet<SoftSkill_Candidato> SoftSkill_Candidatos { get; set; }

        public virtual DbSet<SoftSkill_Dipendente> SoftSkill_Dipendentes { get; set; }

        public virtual DbSet<TipologiaColloquio> TipologiaColloquios { get; set; }

        public virtual DbSet<TipologiaContratto> TipologiaContrattos { get; set; }

        public virtual DbSet<TipologiaDocumento> TipologiaDocumentos { get; set; }

        public virtual DbSet<TitoloStudio> TitoloStudios { get; set; }

        public virtual DbSet<TitoloStudio_Candidato> TitoloStudio_Candidatos { get; set; }

        public virtual DbSet<TitoloStudio_Dipendente> TitoloStudio_Dipendentes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Benefits_Contratti>(entity =>
            {
                entity.HasKey(e => e.Benefits_ContrattiId).HasName("PK_Benefit_Contratti");

                entity.HasOne(d => d.Benefit).WithMany(p => p.Benefits_Contrattis).HasConstraintName("FK_Benefits_Contratti_Benefit");

                entity.HasOne(d => d.Contratto).WithMany(p => p.Benefits_Contrattis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Benefits_Contratti_Contratto");
            });

            modelBuilder.Entity<Candidato>(entity =>
            {
                entity.HasOne(d => d.ResidenzaNavigation).WithMany(p => p.Candidatos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Candidato_Comune");

                entity.HasOne(d => d.TipoContrattoNavigation).WithMany(p => p.Candidatos).HasConstraintName("FK_Candidato_TipologiaContratto");
            });

            modelBuilder.Entity<Colloquio>(entity =>
            {
                entity.HasOne(d => d.HRNavigation).WithMany(p => p.ColloquioHRNavigations)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Colloquio_DipendenteHR");

                entity.HasOne(d => d.ReferenteTecnicoNavigation).WithMany(p => p.ColloquioReferenteTecnicoNavigations).HasConstraintName("FK_Colloquio_DipendenteTecnico");

                entity.HasOne(d => d.SedeColloquioNavigation).WithMany(p => p.Colloquios)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Colloquio_Sede");

                entity.HasOne(d => d.TipologiaColloquioNavigation).WithMany(p => p.Colloquios)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Colloquio_TipologiaColloquio");
            });

            modelBuilder.Entity<Comune>(entity =>
            {
                entity.HasOne(d => d.ProvinciaNavigation).WithMany(p => p.Comunes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comune_Provincia");
            });

            modelBuilder.Entity<Contratto>(entity =>
            {
                entity.HasOne(d => d.LivelloContrattualeNavigation).WithMany(p => p.Contrattos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contratto_LivelloContrattuale");

                entity.HasOne(d => d.TipoDocumentoNavigation).WithMany(p => p.Contrattos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contratto_TipologiaDocumento");

                entity.HasOne(d => d.TipologiaContrattoNavigation).WithMany(p => p.Contrattos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contratto_TipologiaContratto");
            });

            modelBuilder.Entity<Dipendente>(entity =>
            {
                entity.HasOne(d => d.ContrattoNavigation).WithMany(p => p.Dipendentes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dipendente_Contratto");

                entity.HasOne(d => d.MansioneNavigation).WithMany(p => p.Dipendentes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mansione_Dipendente");

                entity.HasOne(d => d.SedeNavigation).WithMany(p => p.Dipendentes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dipendente_Sede");

                entity.HasOne(d => d.UtenteNavigation).WithMany(p => p.Dipendentes).HasConstraintName("FK_Dipendente_AspNetUsers");
            });

            modelBuilder.Entity<HardSkill_Candidato>(entity =>
            {
                entity.HasOne(d => d.Candidato).WithMany(p => p.HardSkill_Candidatos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HardSkill_Candidato_Candidato");

                entity.HasOne(d => d.HardSkill).WithMany(p => p.HardSkill_Candidatos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HardSkill_Candidato_HardSkill");
            });

            modelBuilder.Entity<HardSkill_Dipendente>(entity =>
            {
                entity.HasOne(d => d.Dipendente).WithMany(p => p.HardSkill_Dipendentes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HardSkill_Dipendente_Dipendente");

                entity.HasOne(d => d.HardSkill).WithMany(p => p.HardSkill_Dipendentes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HardSkill_Dipendente_HardSkill");
            });

            modelBuilder.Entity<Sede>(entity =>
            {
                entity.Property(e => e.SedeId).ValueGeneratedNever();

                entity.HasOne(d => d.ReferenteNavigation).WithMany(p => p.Sedes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sede_Dipendente");
            });

            modelBuilder.Entity<SoftSkill_Candidato>(entity =>
            {
                entity.HasOne(d => d.Candidato).WithMany(p => p.SoftSkill_Candidatos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SoftSkill_Candidato_Candidato");

                entity.HasOne(d => d.SoftSkill).WithMany(p => p.SoftSkill_Candidatos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SoftSkill_Candidato_SoftSkill");
            });

            modelBuilder.Entity<SoftSkill_Dipendente>(entity =>
            {
                entity.HasOne(d => d.Dipendente).WithMany(p => p.SoftSkill_Dipendentes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SoftSkill_Dipendente_Dipendente");

                entity.HasOne(d => d.SoftSkill).WithMany(p => p.SoftSkill_Dipendentes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SoftSkill_Dipendente_SoftSkill");
            });

            modelBuilder.Entity<TitoloStudio_Candidato>(entity =>
            {
                entity.HasOne(d => d.Candidato).WithMany(p => p.TitoloStudio_Candidatos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TitoloStudio_Candidato_Candidato");

                entity.HasOne(d => d.TitoloStudio).WithMany(p => p.TitoloStudio_Candidatos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TitoloStudio_Candidato_TitoloStudio");
            });

            modelBuilder.Entity<TitoloStudio_Dipendente>(entity =>
            {
                entity.HasOne(d => d.Dipendente).WithMany(p => p.TitoloStudio_Dipendentes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TitoloStudio_Dipendente_Dipendente");

                entity.HasOne(d => d.TitoloStudio).WithMany(p => p.TitoloStudio_Dipendentes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TitoloStudio_Dipendente_TitoloStudio");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}