using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models.Domain;

public class UtilisationVehicule
{
    public int Vehicule { get; set; }

    public int Client { get; set; }

    public DateTime Date { get; set; }

    public int BorneDepart { get; set; }

    public int? BorneArrivee { get; set; }
    
    [ForeignKey("BorneArrivee")]
    public virtual Borne? BorneArriveeNavigation { get; set; }

    [ForeignKey("BorneDepart")]
    public virtual Borne BorneDepartNavigation { get; set; } = null!;
    
    [ForeignKey("Id")]
    public virtual Client ClientNavigation { get; set; } = null!;
    
    [ForeignKey("IdVehicule")]
    public virtual Vehicule VehiculeNavigation { get; set; } = null!;
}
