using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models.Domain;

[Table("TypeVehicule")]
public partial class TypeVehicule
{
    [Key]
    public int IdTypeVehicule { get; set; }

    public string Categorie { get; set; } = null!;

    public string TypeVehicule1 { get; set; } = null!;

    public virtual ICollection<Vehicule> Vehicules { get; set; } = new List<Vehicule>();
}