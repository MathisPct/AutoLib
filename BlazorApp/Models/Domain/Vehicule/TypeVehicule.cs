namespace BlazorApp.Models.Domain;

public partial class TypeVehicule
{
    public int IdTypeVehicule { get; set; }

    public string Categorie { get; set; } = null!;

    public string TypeVehicule1 { get; set; } = null!;

    public virtual ICollection<Vehicule> Vehicules { get; set; } = new List<Vehicule>();
}