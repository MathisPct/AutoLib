using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models.Domain;

[Table("Station")]
public partial class Station
{
    [Key]
    public int IdStation { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public string? Adresse { get; set; }

    public int? Numero { get; set; }

    public string? Ville { get; set; }

    public int? CodePostal { get; set; }

    public int TotalVoitures
    {
        get
        {
            int count = 0;
            foreach (var borne in Bornes)
            {
                if (borne.IsFree == false)
                {
                    count++;
                }
            }

            return count;
        }
    }

    public int TotalPlacesParking
    {
        get
        {
            int count = 0;
            foreach (var borne in Bornes)
            {
                if (borne.IsFree) count++;
            }

            return count;
        }
    }

    public virtual ICollection<Borne> Bornes { get; set; } = new List<Borne>();
}