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

    public virtual DbSet<Borne> Bornes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<TypeVehicule> TypeVehicules { get; set; }

    public virtual DbSet<UtilisationVehicule> Utilises { get; set; }

    public virtual DbSet<Vehicule> Vehicules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("autolib");
    }
}
