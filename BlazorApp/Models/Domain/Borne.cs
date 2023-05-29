using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models.Domain;

[Table("Borne")]
public class Borne
{
    [Key]
    public int IdBorne { get; set; }
    
    /// <summary>
    /// True si la station est libre
    /// </summary>
    public bool IsFree { get; set; }

    [Column(TypeName = "int")]
    public int? IdVehicule { get; set; }
    
    [ForeignKey("IdVehicule")]
    public virtual Vehicule? Vehicule { get; set; }
    
    [ForeignKey("IdStation")]
    public virtual Station StationNavigation { get; set; } = null!;
    
    [InverseProperty("BorneArriveeNavigation")]
    public virtual ICollection<UtilisationVehicule> UtiliseBorneArriveeNavigations { get; set; } = new List<UtilisationVehicule>();
    
    [InverseProperty("BorneDepartNavigation")]
    public virtual ICollection<UtilisationVehicule> UtiliseBorneDepartNavigations { get; set; } = new List<UtilisationVehicule>();
}
