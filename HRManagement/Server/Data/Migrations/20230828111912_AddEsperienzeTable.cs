using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEsperienzeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Benefit",
            //    columns: table => new
            //    {
            //        BenefitId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Descrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Attivo = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Benefit", x => x.BenefitId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "HardSkill",
            //    columns: table => new
            //    {
            //        HardSkillID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Descrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Attivo = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HardSkill", x => x.HardSkillID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LivelloContrattuale",
            //    columns: table => new
            //    {
            //        LivelloContrattoId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Descrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Attivo = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LivelloContrattuale", x => x.LivelloContrattoId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Mansione",
            //    columns: table => new
            //    {
            //        MansioneId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Descrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Attivo = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Mansione", x => x.MansioneId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Provincie",
            //    columns: table => new
            //    {
            //        ProvinciaId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Provincie", x => x.ProvinciaId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SoftSkill",
            //    columns: table => new
            //    {
            //        SoftSkillId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Descrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Attivo = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SoftSkill", x => x.SoftSkillId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TipologiaColloquio",
            //    columns: table => new
            //    {
            //        TipoColloquioId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Descrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Attivo = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TipologiaColloquio", x => x.TipoColloquioId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TipologiaContratto",
            //    columns: table => new
            //    {
            //        TipoContrattoId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Descrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Attivo = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TipologiaContratto", x => x.TipoContrattoId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TipologiaDocumento",
            //    columns: table => new
            //    {
            //        TipoDocumentoId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Descrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Attivo = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TipologiaDocumento", x => x.TipoDocumentoId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TitoloStudio",
            //    columns: table => new
            //    {
            //        TitoloStudioId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Descrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Attivo = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TitoloStudio", x => x.TitoloStudioId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Comune",
            //    columns: table => new
            //    {
            //        ComuneId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Provincia = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Comune", x => x.ComuneId);
            //        table.ForeignKey(
            //            name: "FK_Comune_Provincia",
            //            column: x => x.Provincia,
            //            principalTable: "Provincie",
            //            principalColumn: "ProvinciaId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Contratto",
            //    columns: table => new
            //    {
            //        ContrattoId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        TipoDocumento = table.Column<int>(type: "int", nullable: false),
            //        NumeroDocumento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        LivelloContrattuale = table.Column<int>(type: "int", nullable: false),
            //        TipologiaContratto = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Contratto", x => x.ContrattoId);
            //        table.ForeignKey(
            //            name: "FK_Contratto_LivelloContrattuale",
            //            column: x => x.LivelloContrattuale,
            //            principalTable: "LivelloContrattuale",
            //            principalColumn: "LivelloContrattoId");
            //        table.ForeignKey(
            //            name: "FK_Contratto_TipologiaContratto",
            //            column: x => x.TipologiaContratto,
            //            principalTable: "TipologiaContratto",
            //            principalColumn: "TipoContrattoId");
            //        table.ForeignKey(
            //            name: "FK_Contratto_TipologiaDocumento",
            //            column: x => x.TipoDocumento,
            //            principalTable: "TipologiaDocumento",
            //            principalColumn: "TipoDocumentoId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Candidato",
            //    columns: table => new
            //    {
            //        CandidatoId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Cognome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        CF = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
            //        RecapitoTelefonico = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        StatoNascita = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        ProvinciaNascita = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        ComuneNascita = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Residenza = table.Column<int>(type: "int", nullable: false),
            //        TipoContratto = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Candidato", x => x.CandidatoId);
            //        table.ForeignKey(
            //            name: "FK_Candidato_Comune",
            //            column: x => x.Residenza,
            //            principalTable: "Comune",
            //            principalColumn: "ComuneId");
            //        table.ForeignKey(
            //            name: "FK_Candidato_TipologiaContratto",
            //            column: x => x.TipoContratto,
            //            principalTable: "TipologiaContratto",
            //            principalColumn: "TipoContrattoId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Benefits_Contratti",
            //    columns: table => new
            //    {
            //        BenefitContrattoId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ContrattoId = table.Column<int>(type: "int", nullable: false),
            //        BenefitId = table.Column<int>(type: "int", nullable: true),
            //        Id = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Benefit_Contratti", x => x.BenefitContrattoId);
            //        table.ForeignKey(
            //            name: "FK_Benefits_Contratti_Benefit",
            //            column: x => x.Id,
            //            principalTable: "Benefit",
            //            principalColumn: "BenefitId");
            //        table.ForeignKey(
            //            name: "FK_Benefits_Contratti_Contratto",
            //            column: x => x.ContrattoId,
            //            principalTable: "Contratto",
            //            principalColumn: "ContrattoId");
            //    });

            migrationBuilder.CreateTable(
                name: "Esperienze",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Candidato = table.Column<int>(type: "int", nullable: false),
                    Inizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mansione = table.Column<int>(type: "int", nullable: false),
                    Azienda = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Esperienze", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Esperienze_Candidato_Candidato",
                        column: x => x.Candidato,
                        principalTable: "Candidato",
                        principalColumn: "CandidatoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Esperienze_Mansione_Mansione",
                        column: x => x.Mansione,
                        principalTable: "Mansione",
                        principalColumn: "MansioneId",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "HardSkill_Candidato",
            //    columns: table => new
            //    {
            //        HardSkillCandidatoId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CandidatoId = table.Column<int>(type: "int", nullable: false),
            //        HardSkillId = table.Column<int>(type: "int", nullable: false),
            //        Id = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HardSkill_Candidato", x => x.HardSkillCandidatoId);
            //        table.ForeignKey(
            //            name: "FK_HardSkill_Candidato_Candidato",
            //            column: x => x.CandidatoId,
            //            principalTable: "Candidato",
            //            principalColumn: "CandidatoId");
            //        table.ForeignKey(
            //            name: "FK_HardSkill_Candidato_HardSkill",
            //            column: x => x.Id,
            //            principalTable: "HardSkill",
            //            principalColumn: "HardSkillID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SoftSkill_Candidato",
            //    columns: table => new
            //    {
            //        SofSkillCandidatoId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CandidatoId = table.Column<int>(type: "int", nullable: false),
            //        SoftSkillId = table.Column<int>(type: "int", nullable: false),
            //        Id = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SoftSkill_Candidato", x => x.SofSkillCandidatoId);
            //        table.ForeignKey(
            //            name: "FK_SoftSkill_Candidato_Candidato",
            //            column: x => x.CandidatoId,
            //            principalTable: "Candidato",
            //            principalColumn: "CandidatoId");
            //        table.ForeignKey(
            //            name: "FK_SoftSkill_Candidato_SoftSkill",
            //            column: x => x.Id,
            //            principalTable: "SoftSkill",
            //            principalColumn: "SoftSkillId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TitoloStudio_Candidato",
            //    columns: table => new
            //    {
            //        TitoloStudioCandidatoId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CandidatoId = table.Column<int>(type: "int", nullable: false),
            //        TitoloStudioId = table.Column<int>(type: "int", nullable: false),
            //        Id = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TitoloStudio_Candidato", x => x.TitoloStudioCandidatoId);
            //        table.ForeignKey(
            //            name: "FK_TitoloStudio_Candidato_Candidato",
            //            column: x => x.CandidatoId,
            //            principalTable: "Candidato",
            //            principalColumn: "CandidatoId");
            //        table.ForeignKey(
            //            name: "FK_TitoloStudio_Candidato_TitoloStudio",
            //            column: x => x.Id,
            //            principalTable: "TitoloStudio",
            //            principalColumn: "TitoloStudioId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Colloquio",
            //    columns: table => new
            //    {
            //        ColloquioId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        HR = table.Column<int>(type: "int", nullable: false),
            //        TipologiaColloquio = table.Column<int>(type: "int", nullable: false),
            //        ReferenteTecnico = table.Column<int>(type: "int", nullable: true),
            //        SedeColloquio = table.Column<int>(type: "int", nullable: false),
            //        Candidato = table.Column<int>(type: "int", nullable: false),
            //        Valutazione = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        DataColloquio = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Colloquio", x => x.ColloquioId);
            //        table.ForeignKey(
            //            name: "FK_Colloquio_Candidato_Candidato",
            //            column: x => x.Candidato,
            //            principalTable: "Candidato",
            //            principalColumn: "CandidatoId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Colloquio_TipologiaColloquio",
            //            column: x => x.TipologiaColloquio,
            //            principalTable: "TipologiaColloquio",
            //            principalColumn: "TipoColloquioId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Dipendente",
            //    columns: table => new
            //    {
            //        DipendenteId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Cognome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        CF = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
            //        Sede = table.Column<int>(type: "int", nullable: false),
            //        Mansione = table.Column<int>(type: "int", nullable: false),
            //        Contratto = table.Column<int>(type: "int", nullable: false),
            //        Utente = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Dipendente", x => x.DipendenteId);
            //        table.ForeignKey(
            //            name: "FK_Dipendente_AspNetUsers",
            //            column: x => x.Utente,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Dipendente_Contratto",
            //            column: x => x.Contratto,
            //            principalTable: "Contratto",
            //            principalColumn: "ContrattoId");
            //        table.ForeignKey(
            //            name: "FK_Mansione_Dipendente",
            //            column: x => x.Mansione,
            //            principalTable: "Mansione",
            //            principalColumn: "MansioneId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "HardSkill_Dipendente",
            //    columns: table => new
            //    {
            //        HardSkillDipendenteId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DipendenteId = table.Column<int>(type: "int", nullable: false),
            //        HardSkillId = table.Column<int>(type: "int", nullable: false),
            //        Id = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HardSkill_Dipendente", x => x.HardSkillDipendenteId);
            //        table.ForeignKey(
            //            name: "FK_HardSkill_Dipendente_Dipendente",
            //            column: x => x.DipendenteId,
            //            principalTable: "Dipendente",
            //            principalColumn: "DipendenteId");
            //        table.ForeignKey(
            //            name: "FK_HardSkill_Dipendente_HardSkill",
            //            column: x => x.Id,
            //            principalTable: "HardSkill",
            //            principalColumn: "HardSkillID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Sede",
            //    columns: table => new
            //    {
            //        SedeId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Descrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Indirizzo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        RecapitoTelefonico = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        EmailSede = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Referente = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Sede", x => x.SedeId);
            //        table.ForeignKey(
            //            name: "FK_Sede_Dipendente",
            //            column: x => x.Referente,
            //            principalTable: "Dipendente",
            //            principalColumn: "DipendenteId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SoftSkill_Dipendente",
            //    columns: table => new
            //    {
            //        SoftSkillDipendenteId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DipendenteId = table.Column<int>(type: "int", nullable: false),
            //        SoftSkillId = table.Column<int>(type: "int", nullable: false),
            //        Id = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SoftSkill_Dipendente", x => x.SoftSkillDipendenteId);
            //        table.ForeignKey(
            //            name: "FK_SoftSkill_Dipendente_Dipendente",
            //            column: x => x.DipendenteId,
            //            principalTable: "Dipendente",
            //            principalColumn: "DipendenteId");
            //        table.ForeignKey(
            //            name: "FK_SoftSkill_Dipendente_SoftSkill",
            //            column: x => x.Id,
            //            principalTable: "SoftSkill",
            //            principalColumn: "SoftSkillId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TitoloStudio_Dipendente",
            //    columns: table => new
            //    {
            //        TitoloStudioDipendenteId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DipendenteId = table.Column<int>(type: "int", nullable: false),
            //        TitoloStudioId = table.Column<int>(type: "int", nullable: false),
            //        Id = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TitoloStudio_Dipendente", x => x.TitoloStudioDipendenteId);
            //        table.ForeignKey(
            //            name: "FK_TitoloStudio_Dipendente_Dipendente",
            //            column: x => x.DipendenteId,
            //            principalTable: "Dipendente",
            //            principalColumn: "DipendenteId");
            //        table.ForeignKey(
            //            name: "FK_TitoloStudio_Dipendente_TitoloStudio",
            //            column: x => x.Id,
            //            principalTable: "TitoloStudio",
            //            principalColumn: "TitoloStudioId");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Benefits_Contratti_ContrattoId",
            //    table: "Benefits_Contratti",
            //    column: "ContrattoId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Benefits_Contratti_Id",
            //    table: "Benefits_Contratti",
            //    column: "Id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Candidato_Residenza",
            //    table: "Candidato",
            //    column: "Residenza");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Candidato_TipoContratto",
            //    table: "Candidato",
            //    column: "TipoContratto");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Colloquio_Candidato",
            //    table: "Colloquio",
            //    column: "Candidato");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Colloquio_HR",
            //    table: "Colloquio",
            //    column: "HR");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Colloquio_ReferenteTecnico",
            //    table: "Colloquio",
            //    column: "ReferenteTecnico");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Colloquio_SedeColloquio",
            //    table: "Colloquio",
            //    column: "SedeColloquio");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Colloquio_TipologiaColloquio",
            //    table: "Colloquio",
            //    column: "TipologiaColloquio");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Comune_Provincia",
            //    table: "Comune",
            //    column: "Provincia");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Contratto_LivelloContrattuale",
            //    table: "Contratto",
            //    column: "LivelloContrattuale");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Contratto_TipoDocumento",
            //    table: "Contratto",
            //    column: "TipoDocumento");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Contratto_TipologiaContratto",
            //    table: "Contratto",
            //    column: "TipologiaContratto");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Dipendente_Contratto",
            //    table: "Dipendente",
            //    column: "Contratto");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Dipendente_Mansione",
            //    table: "Dipendente",
            //    column: "Mansione");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Dipendente_Sede",
            //    table: "Dipendente",
            //    column: "Sede");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Dipendente_Utente",
            //    table: "Dipendente",
            //    column: "Utente");

            migrationBuilder.CreateIndex(
                name: "IX_Esperienze_Candidato",
                table: "Esperienze",
                column: "Candidato");

            migrationBuilder.CreateIndex(
                name: "IX_Esperienze_Mansione",
                table: "Esperienze",
                column: "Mansione");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HardSkill_Candidato_CandidatoId",
            //    table: "HardSkill_Candidato",
            //    column: "CandidatoId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HardSkill_Candidato_Id",
            //    table: "HardSkill_Candidato",
            //    column: "Id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HardSkill_Dipendente_DipendenteId",
            //    table: "HardSkill_Dipendente",
            //    column: "DipendenteId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HardSkill_Dipendente_Id",
            //    table: "HardSkill_Dipendente",
            //    column: "Id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Sede_Referente",
            //    table: "Sede",
            //    column: "Referente");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SoftSkill_Candidato_CandidatoId",
            //    table: "SoftSkill_Candidato",
            //    column: "CandidatoId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SoftSkill_Candidato_Id",
            //    table: "SoftSkill_Candidato",
            //    column: "Id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SoftSkill_Dipendente_DipendenteId",
            //    table: "SoftSkill_Dipendente",
            //    column: "DipendenteId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SoftSkill_Dipendente_Id",
            //    table: "SoftSkill_Dipendente",
            //    column: "Id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TitoloStudio_Candidato_CandidatoId",
            //    table: "TitoloStudio_Candidato",
            //    column: "CandidatoId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TitoloStudio_Candidato_Id",
            //    table: "TitoloStudio_Candidato",
            //    column: "Id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TitoloStudio_Dipendente_DipendenteId",
            //    table: "TitoloStudio_Dipendente",
            //    column: "DipendenteId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TitoloStudio_Dipendente_Id",
            //    table: "TitoloStudio_Dipendente",
            //    column: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Colloquio_DipendenteHR",
            //    table: "Colloquio",
            //    column: "HR",
            //    principalTable: "Dipendente",
            //    principalColumn: "DipendenteId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Colloquio_DipendenteTecnico",
            //    table: "Colloquio",
            //    column: "ReferenteTecnico",
            //    principalTable: "Dipendente",
            //    principalColumn: "DipendenteId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Colloquio_Sede",
            //    table: "Colloquio",
            //    column: "SedeColloquio",
            //    principalTable: "Sede",
            //    principalColumn: "SedeId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Dipendente_Sede",
            //    table: "Dipendente",
            //    column: "Sede",
            //    principalTable: "Sede",
            //    principalColumn: "SedeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Dipendente_Contratto",
            //    table: "Dipendente");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Sede_Dipendente",
            //    table: "Sede");

            //migrationBuilder.DropTable(
            //    name: "Benefits_Contratti");

            //migrationBuilder.DropTable(
            //    name: "Colloquio");

            migrationBuilder.DropTable(
                name: "Esperienze");

            //migrationBuilder.DropTable(
            //    name: "HardSkill_Candidato");

            //migrationBuilder.DropTable(
            //    name: "HardSkill_Dipendente");

            //migrationBuilder.DropTable(
            //    name: "SoftSkill_Candidato");

            //migrationBuilder.DropTable(
            //    name: "SoftSkill_Dipendente");

            //migrationBuilder.DropTable(
            //    name: "TitoloStudio_Candidato");

            //migrationBuilder.DropTable(
            //    name: "TitoloStudio_Dipendente");

            //migrationBuilder.DropTable(
            //    name: "Benefit");

            //migrationBuilder.DropTable(
            //    name: "TipologiaColloquio");

            //migrationBuilder.DropTable(
            //    name: "HardSkill");

            //migrationBuilder.DropTable(
            //    name: "SoftSkill");

            //migrationBuilder.DropTable(
            //    name: "Candidato");

            //migrationBuilder.DropTable(
            //    name: "TitoloStudio");

            //migrationBuilder.DropTable(
            //    name: "Comune");

            //migrationBuilder.DropTable(
            //    name: "Provincie");

            //migrationBuilder.DropTable(
            //    name: "Contratto");

            //migrationBuilder.DropTable(
            //    name: "LivelloContrattuale");

            //migrationBuilder.DropTable(
            //    name: "TipologiaContratto");

            //migrationBuilder.DropTable(
            //    name: "TipologiaDocumento");

            //migrationBuilder.DropTable(
            //    name: "Dipendente");

            //migrationBuilder.DropTable(
            //    name: "Sede");

            //migrationBuilder.DropTable(
            //    name: "Mansione");
        }
    }
}
