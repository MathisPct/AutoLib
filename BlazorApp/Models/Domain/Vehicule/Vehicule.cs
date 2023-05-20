using System;
using System.Collections.Generic;
using BlazorApp.Dto;
using BlazorApp.Models.Exception;

namespace BlazorApp.Models.Domain;

public partial class Vehicule
{
    public int IdVehicule { get; set; }

    public int Rfid { get; set; }

    public int? EtatBatterie { get; set; }

    public string Disponibilite { get; set; } = null!;

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public int TypeVehicule { get; set; }

    public virtual ICollection<Borne> Bornes { get; set; } = new List<Borne>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual TypeVehicule TypeVehiculeNavigation { get; set; } = null!;

    public virtual ICollection<UtilisationVehicule> Utilises { get; set; } = new List<UtilisationVehicule>();

    public void Reserver(Client client, PlageReservation plageReservation)
    {
        if (plageReservation.start >= plageReservation.end || plageReservation.end <= DateTime.Now)
        {
            throw new ReservationException("Les plages horaires pour la réservation sont incorrectes");
        }

        if (!Disponibilite.Equals("LIBRE"))
        {
            throw new ReservationException("La réservation n'est possible que pour un véhicule libre");
        }
        
        Reservation reservation = new Reservation()
        {
            Client = client.IdClient,
            Vehicule = this.IdVehicule,
            DateReservation = plageReservation.start,
            DateEcheance = plageReservation.end
        };
        this.Disponibilite = "RESERVE";
        this.Reservations.Add(reservation);
    }
}