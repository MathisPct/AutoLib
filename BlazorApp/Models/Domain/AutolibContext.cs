using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Models.Domain;

public partial class AutolibContext : IdentityDbContext
{
    public AutolibContext()
    {
    }

    public AutolibContext(DbContextOptions<AutolibContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Borne> Bornes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<TypeVehicule> TypeVehicules { get; set; }

    public virtual DbSet<UtilisationVehicule> Utilises { get; set; }

    public virtual DbSet<Vehicule> Vehicules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;port=3306;user=autolibUser;password=Gy6d!8Jejt3o-/3M;database=autolib");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Borne>(entity =>
        {
            entity.HasKey(e => e.IdBorne).HasName("PRIMARY");

            entity.ToTable("borne");

            entity.HasIndex(e => e.Station, "fk_Borne_Station1_idx");

            entity.HasIndex(e => e.IdVehicule, "fk_Borne_Vehicule1_idx");

            entity.Property(e => e.IdBorne)
                .HasColumnType("int(11)")
                .HasColumnName("idBorne");
            entity.Property(e => e.IsFree).HasColumnName("etatBorne");
            entity.Property(e => e.IdVehicule)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("idVehicule");
            entity.Property(e => e.Station)
                .HasColumnType("int(11)")
                .HasColumnName("station");

            entity.HasOne(d => d.Vehicule).WithMany(p => p.Bornes)
                .HasForeignKey(d => d.IdVehicule)
                .HasConstraintName("fk_Borne_Vehicule1");

            entity.HasOne(d => d.StationNavigation).WithMany(p => p.Bornes)
                .HasForeignKey(d => d.Station)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Borne_Station1");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PRIMARY");

            entity.ToTable("client");

            entity.Property(e => e.IdClient)
                .HasColumnType("int(11)")
                .HasColumnName("idClient");
            entity.Property(e => e.DateNaissance)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("date")
                .HasColumnName("date_naissance");
            entity.Property(e => e.Nom)
                .HasMaxLength(45)
                .HasColumnName("nom");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Prenom)
                .HasMaxLength(45)
                .HasColumnName("prenom");
            entity.Property(e => e.Salt)
                .HasMaxLength(100)
                .HasColumnName("salt");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => new { e.Vehicule, e.Client, e.DateReservation }).HasName("PRIMARY");

            entity.ToTable("reservation");

            entity.HasIndex(e => e.Client, "fk_Reservation_Client1_idx");

            entity.HasIndex(e => e.Vehicule, "fk_Reservation_Vehicule1_idx");

            entity.Property(e => e.Vehicule)
                .HasColumnType("int(11)")
                .HasColumnName("vehicule");
            entity.Property(e => e.Client)
                .HasColumnType("int(11)")
                .HasColumnName("client");
            entity.Property(e => e.DateReservation)
                .HasColumnType("datetime")
                .HasColumnName("date_reservation");
            entity.Property(e => e.DateEcheance)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime")
                .HasColumnName("date_echeance");

            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.Client)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reservation_Client1");

            entity.HasOne(d => d.VehiculeNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.Vehicule)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reservation_Vehicule1");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.IdStation).HasName("PRIMARY");

            entity.ToTable("station");

            entity.Property(e => e.IdStation)
                .HasColumnType("int(11)")
                .HasColumnName("idStation");
            entity.Property(e => e.Adresse)
                .HasMaxLength(200)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("adresse");
            entity.Property(e => e.CodePostal)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("code_postal");
            entity.Property(e => e.Latitude)
                .HasPrecision(9, 6)
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasPrecision(9, 6)
                .HasColumnName("longitude");
            entity.Property(e => e.Numero)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("numero");
            entity.Property(e => e.Ville)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("ville");
        });

        modelBuilder.Entity<TypeVehicule>(entity =>
        {
            entity.HasKey(e => e.IdTypeVehicule).HasName("PRIMARY");

            entity.ToTable("type_vehicule");

            entity.Property(e => e.IdTypeVehicule)
                .HasColumnType("int(11)")
                .HasColumnName("idType_vehicule");
            entity.Property(e => e.Categorie)
                .HasMaxLength(45)
                .HasColumnName("categorie");
            entity.Property(e => e.TypeVehicule1)
                .HasMaxLength(45)
                .HasColumnName("type_vehicule");
        });

        modelBuilder.Entity<UtilisationVehicule>(entity =>
        {
            entity.HasKey(e => new { e.Vehicule, e.Client, e.Date }).HasName("PRIMARY");

            entity.ToTable("utilise");

            entity.HasIndex(e => e.Client, "fk_table1_Client1_idx");

            entity.HasIndex(e => e.BorneDepart, "fk_utilise_Borne1_idx");

            entity.HasIndex(e => e.BorneArrivee, "fk_utilise_Borne2_idx");

            entity.Property(e => e.Vehicule).HasColumnType("int(11)");
            entity.Property(e => e.Client).HasColumnType("int(11)");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.BorneArrivee)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("borne_arrivee");
            entity.Property(e => e.BorneDepart)
                .HasColumnType("int(11)")
                .HasColumnName("borne_depart");

            entity.HasOne(d => d.BorneArriveeNavigation).WithMany(p => p.UtiliseBorneArriveeNavigations)
                .HasForeignKey(d => d.BorneArrivee)
                .HasConstraintName("fk_utilise_Borne2");

            entity.HasOne(d => d.BorneDepartNavigation).WithMany(p => p.UtiliseBorneDepartNavigations)
                .HasForeignKey(d => d.BorneDepart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_utilise_Borne1");

            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.Utilises)
                .HasForeignKey(d => d.Client)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_table1_Client1");

            entity.HasOne(d => d.VehiculeNavigation).WithMany(p => p.Utilises)
                .HasForeignKey(d => d.Vehicule)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_table1_Vehicule1");
        });

        modelBuilder.Entity<Vehicule>(entity =>
        {
            entity.HasKey(e => e.IdVehicule).HasName("PRIMARY");

            entity.ToTable("vehicule");

            entity.HasIndex(e => e.Rfid, "RFID_UNIQUE").IsUnique();

            entity.HasIndex(e => e.TypeVehicule, "fk_Vehicule_Type_vehicule1_idx");

            entity.Property(e => e.IdVehicule)
                .HasColumnType("int(11)")
                .HasColumnName("idVehicule");
            entity.Property(e => e.Disponibilite).HasMaxLength(45);
            entity.Property(e => e.EtatBatterie)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("etatBatterie");
            entity.Property(e => e.Latitude)
                .HasPrecision(9, 6)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasPrecision(9, 6)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("longitude");
            entity.Property(e => e.Rfid)
                .HasColumnType("int(11)")
                .HasColumnName("RFID");
            entity.Property(e => e.TypeVehicule)
                .HasColumnType("int(11)")
                .HasColumnName("type_vehicule");

            entity.HasOne(d => d.TypeVehiculeNavigation).WithMany(p => p.Vehicules)
                .HasForeignKey(d => d.TypeVehicule)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Vehicule_Type_vehicule1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
