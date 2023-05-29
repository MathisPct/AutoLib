using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models.Domain;

[Table("Reservation")]
public class Reservation
{
    public int Vehicule { get; set; }

    public DateTime DateReservation { get; set; }

    public DateTime? DateEcheance { get; set; }
    
    [ForeignKey("Id")]
    public virtual Client ClientNavigation { get; set; } = null!;
    
    [ForeignKey("IdVehicule")]
    public virtual Vehicule VehiculeNavigation { get; set; } = null!;
}