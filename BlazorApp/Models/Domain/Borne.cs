namespace BlazorApp.Models.Domain;

public class Borne
{
    public int IdBorne { get; set; }

    /// <summary>
    /// True si la station est libre
    /// </summary>
    public bool IsFree { get; set; }

    public int Station { get; set; }

    public int? IdVehicule { get; set; }

    public virtual Vehicule? Vehicule { get; set; }

    public virtual Station StationNavigation { get; set; } = null!;

    public virtual ICollection<UtilisationVehicule> UtiliseBorneArriveeNavigations { get; set; } = new List<UtilisationVehicule>();

    public virtual ICollection<UtilisationVehicule> UtiliseBorneDepartNavigations { get; set; } = new List<UtilisationVehicule>();
}
