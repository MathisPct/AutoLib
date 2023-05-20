﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BlazorApp.Models.Domain;

public partial class Client
{
    public int IdClient { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public DateTime? DateNaissance { get; set; }

    public string Password { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<UtilisationVehicule> Utilises { get; set; } = new List<UtilisationVehicule>();
}