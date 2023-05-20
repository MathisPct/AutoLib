using System;
using System.Collections.Generic;

namespace BlazorApp.Models.Domain;

public partial class Station
{
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