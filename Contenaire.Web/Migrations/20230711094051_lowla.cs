using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contenaire.Web.Migrations
{
    /// <inheritdoc />
    public partial class lowla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__MigrationHistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContextKey = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Model = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ProductVersion = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.__MigrationHistory", x => new { x.MigrationId, x.ContextKey });
                });

            migrationBuilder.CreateTable(
                name: "AccessView",
                columns: table => new
                {
                    IdAccessView = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescriptionAccessView = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessTable", x => x.IdAccessView);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BinLocaux",
                columns: table => new
                {
                    IdBinLocaux = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BinStart = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BinEnd = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PrefixCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CardLengthType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CardLengthMin = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CardLengthMax = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PinFlag = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ServiceCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CodeLongue = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    GCodePin = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PlafondCarte = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinLocaux", x => x.IdBinLocaux);
                });

            migrationBuilder.CreateTable(
                name: "EmvAid",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RidAid = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PixAid = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LongeurPix = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NumVersionAppTpe = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NiveauPriorite = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Indicateur = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EmvAid__98EA3A08A71DA42B", x => new { x.Version, x.RidAid, x.PixAid });
                });

            migrationBuilder.CreateTable(
                name: "EmvDdol",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RidEmv = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PixEmv = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LongeurPix = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LongeurDdol = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DefaultDdol = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmvDdol", x => new { x.Version, x.RidEmv, x.PixEmv });
                });

            migrationBuilder.CreateTable(
                name: "EmvKeys",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RidEmv = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IndexCle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LongeurExpCle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ExpCle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LongeurNca = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ModuloCle = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmvKeys", x => new { x.Version, x.RidEmv, x.IndexCle });
                });

            migrationBuilder.CreateTable(
                name: "EmvRandCall",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RidEmv = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PixEmv = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LongeurPix = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CodeMonnaie = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SeuilAppelEmv = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NbrTransInfPlafond = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NbrMaxTrans = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmvRandCall", x => new { x.Version, x.RidEmv, x.PixEmv });
                });

            migrationBuilder.CreateTable(
                name: "EmvTac",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RidEmv = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PixEmv = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LongeurPid = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TacRejetTrans = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TacTraitOnline = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TacRejetApresRejet = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmvTac", x => new { x.Version, x.RidEmv, x.PixEmv });
                });

            migrationBuilder.CreateTable(
                name: "EmvTcc",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RidEmv = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PixEmv = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LongeurPix = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TccAutorise = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmvTcc", x => new { x.Version, x.RidEmv, x.PixEmv });
                });

            migrationBuilder.CreateTable(
                name: "EmvTdol",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RidEmv = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LongeurTdol = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DefaultTdol = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmvTdol", x => new { x.Version, x.RidEmv });
                });

            migrationBuilder.CreateTable(
                name: "Fuseau",
                columns: table => new
                {
                    countrycode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    nom = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    diffhorraire = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuseau", x => x.countrycode);
                });

            migrationBuilder.CreateTable(
                name: "GroupPrefix",
                columns: table => new
                {
                    PrefixGroup = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IdPrefixGroup = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrefixCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Institution = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPrefix", x => x.PrefixGroup);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    MatchFieldName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MatchDescripion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchTable", x => x.MatchFieldName);
                });

            migrationBuilder.CreateTable(
                name: "NPREFIX",
                columns: table => new
                {
                    ID_PREFIX = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PREFIX_INDEX = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    INSTITUTION_LABEL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PREFIX_GROUP_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BIN_START = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BIN_END = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    INDEX_ISSUER_BITMAP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CARD_LENGTH_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CARD_LENGTH_MIN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CARD_LENGTH_MAX = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PIN_FLAG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RESEAU = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MESSAGE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LIMIT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPREFIX", x => x.ID_PREFIX);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    IdOrganization = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    NameOrganization = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LogoOrganization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConventionOrganization = table.Column<int>(type: "int", nullable: false),
                    IdBk = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.IdOrganization);
                });

            migrationBuilder.CreateTable(
                name: "PosIdentification",
                columns: table => new
                {
                    IdTerminal = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IdMerchant = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Outlet = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Mcc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CountryCodeNum = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CountryCodeAlpha = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Port = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosIdentification", x => x.IdTerminal);
                });

            migrationBuilder.CreateTable(
                name: "PosParameters",
                columns: table => new
                {
                    P1_IdTerminal = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    P2_TypeTerminal = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P3_TypeApplication = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P4_NomApplication = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P5_EnseignePointVente = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P6_Adresse = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P7_MCC = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P8_Ville = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P9_MotDePasse = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P10_MasqueReseauAcceptation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P11_NumSerieTerminal = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P12_NumRegistrCommerce = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P13_HeureFinJournee = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P14_AffichageTerminalEtTicket = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P15_SeuilTransactionOffline = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P16_1_NombreTransactionAvisMax = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P16_2_CaptureDate = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P17_IndicateurPinPad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P18_SaisieManuelle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P19_IndicateurTimeOut = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P20_AnnulationTimeOutValidation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P21_AcceptationCartePuce = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P22_IndicateurImpression = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P23_IndicateurAnnulation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P24_Forcage = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P25_ChangementDomiciliation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P26_SupportPreAutorisation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P27_TypeAppel = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P28_CommerceOffshore = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P29_IndicateurRefund = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P30_IndicateurCashBack = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P31_IndicateurTIP = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P32_IndicateurInstalment = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P33_IndicataurOffline = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P34_TypeApplication = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P35_Reserve = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P36_NumAppelServeurAutorisation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P37_AdresseX25ServeurAutorisation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P38_NumAppelServeurTelecollecte = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P39_AdresseX25ServeurTelecollecte = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P40_NumServeurApplication = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P41_AdresseX25ServeurApplication = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P42_Secours_NumAppelServeurAutorisation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P43_Secours_AdresseX25ServeurAutorisation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P44_Secours_NumAppelServeurTelecollecte = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P45_Secours_AdresseX25ServeurTelecollecte = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P46_Secours_NumServeurApplication = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P47_Secours_AdresseX25ServeurApplication = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P48_MonnaiAcceptationAlpha_1_Numerique = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P49_MonnaiAcceptation_1_Alpha = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P50_MonnaiAcceptation_1_Exposant = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P51_MontantMinimum_Monnaie_1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P52_MonnaiAcceptationAlpha_2_Numerique = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P53_MonnaiAcceptation_2_Alpha = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P54_MonnaiAcceptation_2_Exposant = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P55_MontantMinimum_Monnaie_2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P56_MonnaiAcceptationAlpha_3_Numerique = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P57_MonnaiAcceptation_3_Alpha = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P58_MonnaiAcceptation_3_Exposant = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P59_MontantMinimum_Monnaie_3 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P60_MonnaiAcceptationAlpha_4_Numerique = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P61_MonnaiAcceptation_4_Alpha = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P62_MonnaiAcceptation_4_Exposant = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P63_MontantMinimum_Monnaie_4 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P64_MonnaiAcceptationAlpha_5_Numerique = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P65_MonnaiAcceptation_5_Alpha = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P66_MonnaiAcceptation_5_Exposant = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P67_MontantMinimum_Monnaie_5 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P68_MonnaiAcceptationAlpha_6_Numerique = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P69_MonnaiAcceptation_6_Alpha = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P70_MonnaiAcceptation_6_Exposant = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P71_MontantMinimum_Monnaie_6 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P72_Monnai_Reglement_1_Numerique = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P73_Monnai_Reglement_1_Alpha = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P74_Monnai_Reglement_1_Exposant = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P75_Monnai_Reglement_2_Numerique = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P76_Monnai_Reglement_2_Alpha = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P77_Monnai_Reglement_2_Exposant = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P78_Monnai_Reglement_3_Numerique = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P79_Monnai_Reglement_3_Alpha = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P80_Monnai_Reglement_3_Exposant = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P81_Monnai_Reglement_4_Numerique = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P82_Monnai_Reglement_4_Alpha = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P83_Monnai_Reglement_4_Exposant = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P84_Monnai_Reglement_5_Numerique = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P85_Monnai_Reglement_5_Alpha = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P86_Monnai_Reglement_5_Exposant = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P87_Reserve = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P88_Langue = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P89_ValeurTimeOut = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P90_ValeurNombreEssaieMaximum = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P91_ValeurIntervalleEntreLesConnexion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P92_IndicateurSaisie4Digit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P93_CodePaysTerminalnumeric = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P94_CodePaysTerminalAplha = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P95_Reserve = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    P96_Port = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosParameters", x => x.P1_IdTerminal);
                });

            migrationBuilder.CreateTable(
                name: "Prefix",
                columns: table => new
                {
                    IdPrefix = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrefixGroup = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LibelleInstitution = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PointVente = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BinStart = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BinEnd = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PrefixCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CardLengthType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CardLengthMin = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CardLengthMax = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PinFlag = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ServiceCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CodeLongue = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    GCodePin = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Message1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Message2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    PlafondCarte = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prefix_1", x => x.IdPrefix);
                });

            migrationBuilder.CreateTable(
                name: "UserLogs",
                columns: table => new
                {
                    IdLog = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FieldId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListFieldName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogs", x => x.IdLog);
                });

            migrationBuilder.CreateTable(
                name: "UserAccess",
                columns: table => new
                {
                    IdUserAccess = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IdAccessView = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ValueUserAccess = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccess", x => x.IdUserAccess);
                    table.ForeignKey(
                        name: "FK_UserAccess_AccessView",
                        column: x => x.IdAccessView,
                        principalTable: "AccessView",
                        principalColumn: "IdAccessView");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEndDateUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IdOrganization = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    IsFirstConnection = table.Column<int>(type: "int", nullable: false),
                    LastConnection = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Organization",
                        column: x => x.IdOrganization,
                        principalTable: "Organization",
                        principalColumn: "IdOrganization");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey, x.UserId });
                    table.ForeignKey(
                        name: "FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdOrganization",
                table: "AspNetUsers",
                column: "IdOrganization");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccess_IdAccessView",
                table: "UserAccess",
                column: "IdAccessView");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__MigrationHistory");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "BinLocaux");

            migrationBuilder.DropTable(
                name: "EmvAid");

            migrationBuilder.DropTable(
                name: "EmvDdol");

            migrationBuilder.DropTable(
                name: "EmvKeys");

            migrationBuilder.DropTable(
                name: "EmvRandCall");

            migrationBuilder.DropTable(
                name: "EmvTac");

            migrationBuilder.DropTable(
                name: "EmvTcc");

            migrationBuilder.DropTable(
                name: "EmvTdol");

            migrationBuilder.DropTable(
                name: "Fuseau");

            migrationBuilder.DropTable(
                name: "GroupPrefix");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "NPREFIX");

            migrationBuilder.DropTable(
                name: "PosIdentification");

            migrationBuilder.DropTable(
                name: "PosParameters");

            migrationBuilder.DropTable(
                name: "Prefix");

            migrationBuilder.DropTable(
                name: "UserAccess");

            migrationBuilder.DropTable(
                name: "UserLogs");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AccessView");

            migrationBuilder.DropTable(
                name: "Organization");
        }
    }
}
