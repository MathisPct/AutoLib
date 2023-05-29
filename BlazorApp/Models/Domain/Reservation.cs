using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models.Domain;

[Table("Reservation")]
public class Reservation
{
    public DateTime DateReservation { get; set; }

    public DateTime? DateEcheance { get; set; }
    
    public string ClientId { get; set; }

    [ForeignKey("ClientId")]
    public virtual Client Client { get; set; }
    
    public int VehiculeId { get; set; }

    [ForeignKey("VehiculeId")]
    public virtual Vehicule Vehicule { get; set; }
}