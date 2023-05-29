using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Models.Domain;

public partial class AutolibContext : IdentityDbContext<Client>
{
    public AutolibContext()
    {
    }

    public AutolibContext(DbContextOptions<AutolibContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Reservation>()
            .HasKey(r => new { r.DateReservation, r.ClientId, r.VehiculeId });
    }

    public DbSet<Borne> Bornes { get; set; }

    public DbSet<Client> Clients { get; set; }

    public DbSet<Reservation> Reservations { get; set; }

    public DbSet<Station> Stations { get; set; }

    public DbSet<TypeVehicule> TypeVehicules { get; set; }

    public DbSet<UtilisationVehicule> Utilises { get; set; }

    public DbSet<Vehicule> Vehicules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=autolib2");
    }
}
