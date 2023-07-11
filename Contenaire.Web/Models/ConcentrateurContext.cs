using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Contenaire.Web.Models;

public partial class ConcentrateurContext : DbContext
{
    public ConcentrateurContext()
    {
    }

    public ConcentrateurContext(DbContextOptions<ConcentrateurContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccessView> AccessViews { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<BinLocaux> BinLocauxes { get; set; }

    public virtual DbSet<EmvAid> EmvAids { get; set; }

    public virtual DbSet<EmvDdol> EmvDdols { get; set; }

    public virtual DbSet<EmvKey> EmvKeys { get; set; }

    public virtual DbSet<EmvRandCall> EmvRandCalls { get; set; }

    public virtual DbSet<EmvTac> EmvTacs { get; set; }

    public virtual DbSet<EmvTcc> EmvTccs { get; set; }

    public virtual DbSet<EmvTdol> EmvTdols { get; set; }

    public virtual DbSet<Fuseau> Fuseaus { get; set; }

    public virtual DbSet<GroupPrefix> GroupPrefixes { get; set; }

    public virtual DbSet<Match> Matches { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<Nprefix> Nprefixes { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<PosIdentification> PosIdentifications { get; set; }

    public virtual DbSet<PosParameter> PosParameters { get; set; }

    public virtual DbSet<Prefix> Prefixes { get; set; }

    public virtual DbSet<UserAccess> UserAccesses { get; set; }

    public virtual DbSet<UserLog> UserLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-QOCK2OM\\SQLEXPRESS; Database=Concentrateur;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccessView>(entity =>
        {
            entity.HasKey(e => e.IdAccessView).HasName("PK_AccessTable");

            entity.ToTable("AccessView");

            entity.Property(e => e.IdAccessView).HasMaxLength(50);
            entity.Property(e => e.DescriptionAccessView).HasMaxLength(50);
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetRoles");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUsers");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.IdOrganization).HasMaxLength(128);
            entity.Property(e => e.LastConnection).HasColumnType("datetime");
            entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasOne(d => d.IdOrganizationNavigation).WithMany(p => p.AspNetUsers)
                .HasForeignKey(d => d.IdOrganization)
                .HasConstraintName("FK_AspNetUsers_Organization");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AspNetUserRoles_AspNetUsers"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK_dbo.AspNetUserRoles");
                        j.ToTable("AspNetUserRoles");
                        j.IndexerProperty<string>("UserId").HasMaxLength(128);
                        j.IndexerProperty<string>("RoleId").HasMaxLength(128);
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUserClaims");

            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId }).HasName("PK_dbo.AspNetUserLogins");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);
            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<BinLocaux>(entity =>
        {
            entity.HasKey(e => e.IdBinLocaux);

            entity.ToTable("BinLocaux");

            entity.Property(e => e.BinEnd)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BinStart)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CardLengthMax)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CardLengthMin)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CardLengthType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CodeLongue)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GcodePin)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GCodePin");
            entity.Property(e => e.PinFlag)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PlafondCarte)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrefixCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ServiceCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmvAid>(entity =>
        {
            entity.HasKey(e => new { e.Version, e.RidAid, e.PixAid }).HasName("PK__EmvAid__98EA3A08862A0BA0");

            entity.ToTable("EmvAid");

            entity.Property(e => e.Version)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RidAid)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PixAid)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Indicateur)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LongeurPix)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NiveauPriorite)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumVersionAppTpe)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmvDdol>(entity =>
        {
            entity.HasKey(e => new { e.Version, e.RidEmv, e.PixEmv });

            entity.ToTable("EmvDdol");

            entity.Property(e => e.Version)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RidEmv)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PixEmv)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DefaultDdol).IsUnicode(false);
            entity.Property(e => e.LongeurDdol)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LongeurPix)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmvKey>(entity =>
        {
            entity.HasKey(e => new { e.Version, e.RidEmv, e.IndexCle });

            entity.Property(e => e.Version)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RidEmv)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IndexCle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ExpCle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LongeurExpCle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LongeurNca)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModuloCle).IsUnicode(false);
        });

        modelBuilder.Entity<EmvRandCall>(entity =>
        {
            entity.HasKey(e => new { e.Version, e.RidEmv, e.PixEmv });

            entity.ToTable("EmvRandCall");

            entity.Property(e => e.Version)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RidEmv)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PixEmv)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CodeMonnaie)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LongeurPix)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NbrMaxTrans)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NbrTransInfPlafond)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SeuilAppelEmv)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmvTac>(entity =>
        {
            entity.HasKey(e => new { e.Version, e.RidEmv, e.PixEmv });

            entity.ToTable("EmvTac");

            entity.Property(e => e.Version)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RidEmv)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PixEmv)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LongeurPid)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TacRejetApresRejet).IsUnicode(false);
            entity.Property(e => e.TacRejetTrans)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TacTraitOnline)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmvTcc>(entity =>
        {
            entity.HasKey(e => new { e.Version, e.RidEmv, e.PixEmv });

            entity.ToTable("EmvTcc");

            entity.Property(e => e.Version)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RidEmv)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PixEmv)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LongeurPix)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TccAutorise)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmvTdol>(entity =>
        {
            entity.HasKey(e => new { e.Version, e.RidEmv });

            entity.ToTable("EmvTdol");

            entity.Property(e => e.Version)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RidEmv)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DefaultTdol).IsUnicode(false);
            entity.Property(e => e.LongeurTdol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Fuseau>(entity =>
        {
            entity.HasKey(e => e.Countrycode);

            entity.ToTable("Fuseau");

            entity.Property(e => e.Countrycode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("countrycode");
            entity.Property(e => e.Diffhorraire).HasColumnName("diffhorraire");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<GroupPrefix>(entity =>
        {
            entity.HasKey(e => e.PrefixGroup);

            entity.ToTable("GroupPrefix");

            entity.Property(e => e.PrefixGroup)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdPrefixGroup).ValueGeneratedOnAdd();
            entity.Property(e => e.Institution)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrefixCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(e => e.MatchFieldName).HasName("PK_MatchTable");

            entity.ToTable("Match");

            entity.Property(e => e.MatchFieldName).HasMaxLength(50);
            entity.Property(e => e.MatchDescripion).HasMaxLength(50);
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Nprefix>(entity =>
        {
            entity.HasKey(e => e.IdPrefix);

            entity.ToTable("NPREFIX");

            entity.Property(e => e.IdPrefix).HasColumnName("ID_PREFIX");
            entity.Property(e => e.BinEnd)
                .HasMaxLength(50)
                .HasColumnName("BIN_END");
            entity.Property(e => e.BinStart)
                .HasMaxLength(50)
                .HasColumnName("BIN_START");
            entity.Property(e => e.CardLengthMax)
                .HasMaxLength(50)
                .HasColumnName("CARD_LENGTH_MAX");
            entity.Property(e => e.CardLengthMin)
                .HasMaxLength(50)
                .HasColumnName("CARD_LENGTH_MIN");
            entity.Property(e => e.CardLengthType)
                .HasMaxLength(50)
                .HasColumnName("CARD_LENGTH_TYPE");
            entity.Property(e => e.IndexIssuerBitmap)
                .HasMaxLength(50)
                .HasColumnName("INDEX_ISSUER_BITMAP");
            entity.Property(e => e.InstitutionLabel)
                .HasMaxLength(50)
                .HasColumnName("INSTITUTION_LABEL");
            entity.Property(e => e.Limit)
                .HasMaxLength(50)
                .HasColumnName("LIMIT");
            entity.Property(e => e.Message).HasColumnName("MESSAGE");
            entity.Property(e => e.PinFlag)
                .HasMaxLength(50)
                .HasColumnName("PIN_FLAG");
            entity.Property(e => e.PrefixGroupId)
                .HasMaxLength(50)
                .HasColumnName("PREFIX_GROUP_ID");
            entity.Property(e => e.PrefixIndex)
                .HasMaxLength(50)
                .HasColumnName("PREFIX_INDEX");
            entity.Property(e => e.Reseau)
                .HasMaxLength(100)
                .HasColumnName("RESEAU");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.IdOrganization);

            entity.ToTable("Organization");

            entity.Property(e => e.IdOrganization).HasMaxLength(128);
            entity.Property(e => e.IdBk)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NameOrganization).HasMaxLength(50);
        });

        modelBuilder.Entity<PosIdentification>(entity =>
        {
            entity.HasKey(e => e.IdTerminal);

            entity.ToTable("PosIdentification");

            entity.Property(e => e.IdTerminal)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CountryCodeAlpha)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CountryCodeNum)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdMerchant)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mcc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Outlet)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Port)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PosParameter>(entity =>
        {
            entity.HasKey(e => e.P1IdTerminal);

            entity.Property(e => e.P1IdTerminal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P1_IdTerminal");
            entity.Property(e => e.P10MasqueReseauAcceptation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P10_MasqueReseauAcceptation");
            entity.Property(e => e.P11NumSerieTerminal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P11_NumSerieTerminal");
            entity.Property(e => e.P12NumRegistrCommerce)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P12_NumRegistrCommerce");
            entity.Property(e => e.P13HeureFinJournee)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P13_HeureFinJournee");
            entity.Property(e => e.P14AffichageTerminalEtTicket)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P14_AffichageTerminalEtTicket");
            entity.Property(e => e.P15SeuilTransactionOffline)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P15_SeuilTransactionOffline");
            entity.Property(e => e.P161NombreTransactionAvisMax)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P16_1_NombreTransactionAvisMax");
            entity.Property(e => e.P162CaptureDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P16_2_CaptureDate");
            entity.Property(e => e.P17IndicateurPinPad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P17_IndicateurPinPad");
            entity.Property(e => e.P18SaisieManuelle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P18_SaisieManuelle");
            entity.Property(e => e.P19IndicateurTimeOut)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P19_IndicateurTimeOut");
            entity.Property(e => e.P20AnnulationTimeOutValidation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P20_AnnulationTimeOutValidation");
            entity.Property(e => e.P21AcceptationCartePuce)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P21_AcceptationCartePuce");
            entity.Property(e => e.P22IndicateurImpression)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P22_IndicateurImpression");
            entity.Property(e => e.P23IndicateurAnnulation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P23_IndicateurAnnulation");
            entity.Property(e => e.P24Forcage)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P24_Forcage");
            entity.Property(e => e.P25ChangementDomiciliation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P25_ChangementDomiciliation");
            entity.Property(e => e.P26SupportPreAutorisation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P26_SupportPreAutorisation");
            entity.Property(e => e.P27TypeAppel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P27_TypeAppel");
            entity.Property(e => e.P28CommerceOffshore)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P28_CommerceOffshore");
            entity.Property(e => e.P29IndicateurRefund)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P29_IndicateurRefund");
            entity.Property(e => e.P2TypeTerminal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P2_TypeTerminal");
            entity.Property(e => e.P30IndicateurCashBack)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P30_IndicateurCashBack");
            entity.Property(e => e.P31IndicateurTip)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P31_IndicateurTIP");
            entity.Property(e => e.P32IndicateurInstalment)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P32_IndicateurInstalment");
            entity.Property(e => e.P33IndicataurOffline)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P33_IndicataurOffline");
            entity.Property(e => e.P34TypeApplication)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P34_TypeApplication");
            entity.Property(e => e.P35Reserve)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P35_Reserve");
            entity.Property(e => e.P36NumAppelServeurAutorisation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P36_NumAppelServeurAutorisation");
            entity.Property(e => e.P37AdresseX25serveurAutorisation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P37_AdresseX25ServeurAutorisation");
            entity.Property(e => e.P38NumAppelServeurTelecollecte)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P38_NumAppelServeurTelecollecte");
            entity.Property(e => e.P39AdresseX25serveurTelecollecte)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P39_AdresseX25ServeurTelecollecte");
            entity.Property(e => e.P3TypeApplication)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P3_TypeApplication");
            entity.Property(e => e.P40NumServeurApplication)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P40_NumServeurApplication");
            entity.Property(e => e.P41AdresseX25serveurApplication)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P41_AdresseX25ServeurApplication");
            entity.Property(e => e.P42SecoursNumAppelServeurAutorisation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P42_Secours_NumAppelServeurAutorisation");
            entity.Property(e => e.P43SecoursAdresseX25serveurAutorisation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P43_Secours_AdresseX25ServeurAutorisation");
            entity.Property(e => e.P44SecoursNumAppelServeurTelecollecte)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P44_Secours_NumAppelServeurTelecollecte");
            entity.Property(e => e.P45SecoursAdresseX25serveurTelecollecte)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P45_Secours_AdresseX25ServeurTelecollecte");
            entity.Property(e => e.P46SecoursNumServeurApplication)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P46_Secours_NumServeurApplication");
            entity.Property(e => e.P47SecoursAdresseX25serveurApplication)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P47_Secours_AdresseX25ServeurApplication");
            entity.Property(e => e.P48MonnaiAcceptationAlpha1Numerique)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P48_MonnaiAcceptationAlpha_1_Numerique");
            entity.Property(e => e.P49MonnaiAcceptation1Alpha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P49_MonnaiAcceptation_1_Alpha");
            entity.Property(e => e.P4NomApplication)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P4_NomApplication");
            entity.Property(e => e.P50MonnaiAcceptation1Exposant)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P50_MonnaiAcceptation_1_Exposant");
            entity.Property(e => e.P51MontantMinimumMonnaie1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P51_MontantMinimum_Monnaie_1");
            entity.Property(e => e.P52MonnaiAcceptationAlpha2Numerique)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P52_MonnaiAcceptationAlpha_2_Numerique");
            entity.Property(e => e.P53MonnaiAcceptation2Alpha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P53_MonnaiAcceptation_2_Alpha");
            entity.Property(e => e.P54MonnaiAcceptation2Exposant)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P54_MonnaiAcceptation_2_Exposant");
            entity.Property(e => e.P55MontantMinimumMonnaie2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P55_MontantMinimum_Monnaie_2");
            entity.Property(e => e.P56MonnaiAcceptationAlpha3Numerique)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P56_MonnaiAcceptationAlpha_3_Numerique");
            entity.Property(e => e.P57MonnaiAcceptation3Alpha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P57_MonnaiAcceptation_3_Alpha");
            entity.Property(e => e.P58MonnaiAcceptation3Exposant)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P58_MonnaiAcceptation_3_Exposant");
            entity.Property(e => e.P59MontantMinimumMonnaie3)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P59_MontantMinimum_Monnaie_3");
            entity.Property(e => e.P5EnseignePointVente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P5_EnseignePointVente");
            entity.Property(e => e.P60MonnaiAcceptationAlpha4Numerique)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P60_MonnaiAcceptationAlpha_4_Numerique");
            entity.Property(e => e.P61MonnaiAcceptation4Alpha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P61_MonnaiAcceptation_4_Alpha");
            entity.Property(e => e.P62MonnaiAcceptation4Exposant)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P62_MonnaiAcceptation_4_Exposant");
            entity.Property(e => e.P63MontantMinimumMonnaie4)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P63_MontantMinimum_Monnaie_4");
            entity.Property(e => e.P64MonnaiAcceptationAlpha5Numerique)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P64_MonnaiAcceptationAlpha_5_Numerique");
            entity.Property(e => e.P65MonnaiAcceptation5Alpha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P65_MonnaiAcceptation_5_Alpha");
            entity.Property(e => e.P66MonnaiAcceptation5Exposant)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P66_MonnaiAcceptation_5_Exposant");
            entity.Property(e => e.P67MontantMinimumMonnaie5)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P67_MontantMinimum_Monnaie_5");
            entity.Property(e => e.P68MonnaiAcceptationAlpha6Numerique)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P68_MonnaiAcceptationAlpha_6_Numerique");
            entity.Property(e => e.P69MonnaiAcceptation6Alpha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P69_MonnaiAcceptation_6_Alpha");
            entity.Property(e => e.P6Adresse)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P6_Adresse");
            entity.Property(e => e.P70MonnaiAcceptation6Exposant)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P70_MonnaiAcceptation_6_Exposant");
            entity.Property(e => e.P71MontantMinimumMonnaie6)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P71_MontantMinimum_Monnaie_6");
            entity.Property(e => e.P72MonnaiReglement1Numerique)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P72_Monnai_Reglement_1_Numerique");
            entity.Property(e => e.P73MonnaiReglement1Alpha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P73_Monnai_Reglement_1_Alpha");
            entity.Property(e => e.P74MonnaiReglement1Exposant)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P74_Monnai_Reglement_1_Exposant");
            entity.Property(e => e.P75MonnaiReglement2Numerique)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P75_Monnai_Reglement_2_Numerique");
            entity.Property(e => e.P76MonnaiReglement2Alpha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P76_Monnai_Reglement_2_Alpha");
            entity.Property(e => e.P77MonnaiReglement2Exposant)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P77_Monnai_Reglement_2_Exposant");
            entity.Property(e => e.P78MonnaiReglement3Numerique)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P78_Monnai_Reglement_3_Numerique");
            entity.Property(e => e.P79MonnaiReglement3Alpha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P79_Monnai_Reglement_3_Alpha");
            entity.Property(e => e.P7Mcc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P7_MCC");
            entity.Property(e => e.P80MonnaiReglement3Exposant)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P80_Monnai_Reglement_3_Exposant");
            entity.Property(e => e.P81MonnaiReglement4Numerique)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P81_Monnai_Reglement_4_Numerique");
            entity.Property(e => e.P82MonnaiReglement4Alpha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P82_Monnai_Reglement_4_Alpha");
            entity.Property(e => e.P83MonnaiReglement4Exposant)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P83_Monnai_Reglement_4_Exposant");
            entity.Property(e => e.P84MonnaiReglement5Numerique)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P84_Monnai_Reglement_5_Numerique");
            entity.Property(e => e.P85MonnaiReglement5Alpha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P85_Monnai_Reglement_5_Alpha");
            entity.Property(e => e.P86MonnaiReglement5Exposant)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P86_Monnai_Reglement_5_Exposant");
            entity.Property(e => e.P87Reserve)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P87_Reserve");
            entity.Property(e => e.P88Langue)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P88_Langue");
            entity.Property(e => e.P89ValeurTimeOut)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P89_ValeurTimeOut");
            entity.Property(e => e.P8Ville)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P8_Ville");
            entity.Property(e => e.P90ValeurNombreEssaieMaximum)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P90_ValeurNombreEssaieMaximum");
            entity.Property(e => e.P91ValeurIntervalleEntreLesConnexion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P91_ValeurIntervalleEntreLesConnexion");
            entity.Property(e => e.P92IndicateurSaisie4Digit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P92_IndicateurSaisie4Digit");
            entity.Property(e => e.P93CodePaysTerminalnumeric)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P93_CodePaysTerminalnumeric");
            entity.Property(e => e.P94CodePaysTerminalAplha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P94_CodePaysTerminalAplha");
            entity.Property(e => e.P95Reserve)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P95_Reserve");
            entity.Property(e => e.P96Port)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P96_Port");
            entity.Property(e => e.P9MotDePasse)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P9_MotDePasse");
        });

        modelBuilder.Entity<Prefix>(entity =>
        {
            entity.HasKey(e => e.IdPrefix).HasName("PK_Prefix_1");

            entity.ToTable("Prefix");

            entity.Property(e => e.BinEnd)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BinStart)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CardLengthMax)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CardLengthMin)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CardLengthType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CodeLongue)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GcodePin)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GCodePin");
            entity.Property(e => e.LibelleInstitution)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Message1).IsUnicode(false);
            entity.Property(e => e.Message2).IsUnicode(false);
            entity.Property(e => e.PinFlag)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PlafondCarte)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PointVente)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrefixCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrefixGroup)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ServiceCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserAccess>(entity =>
        {
            entity.HasKey(e => e.IdUserAccess);

            entity.ToTable("UserAccess");

            entity.Property(e => e.IdUserAccess).HasMaxLength(128);
            entity.Property(e => e.IdAccessView).HasMaxLength(50);
            entity.Property(e => e.IdUser).HasMaxLength(128);

            entity.HasOne(d => d.IdAccessViewNavigation).WithMany(p => p.UserAccesses)
                .HasForeignKey(d => d.IdAccessView)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAccess_AccessView");
        });

        modelBuilder.Entity<UserLog>(entity =>
        {
            entity.HasKey(e => e.IdLog);

            entity.Property(e => e.IdLog).HasMaxLength(128);
            entity.Property(e => e.Action).HasMaxLength(50);
            entity.Property(e => e.ActionDate).HasColumnType("datetime");
            entity.Property(e => e.IdUser).HasMaxLength(128);
            entity.Property(e => e.TableName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
