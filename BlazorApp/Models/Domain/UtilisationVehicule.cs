namespace BlazorApp.Models.Domain;

public class UtilisationVehicule
{
    public int Vehicule { get; set; }

    public int Client { get; set; }

    public DateTime Date { get; set; }

    public int BorneDepart { get; set; }

    public int? BorneArrivee { get; set; }

    public virtual Borne? BorneArriveeNavigation { get; set; }

    public virtual Borne BorneDepartNavigation { get; set; } = null!;

    public virtual Client ClientNavigation { get; set; } = null!;

    public virtual Vehicule VehiculeNavigation { get; set; } = null!;
}
