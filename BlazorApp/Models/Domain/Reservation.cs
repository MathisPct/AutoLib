﻿namespace BlazorApp.Models.Domain;

public class Reservation
{
    public int Vehicule { get; set; }

    public int Client { get; set; }

    public DateTime DateReservation { get; set; }

    public DateTime? DateEcheance { get; set; }

    public virtual Client ClientNavigation { get; set; } = null!;

    public virtual Vehicule VehiculeNavigation { get; set; } = null!;
}