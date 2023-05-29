using BlazorApp.Dto;
using BlazorApp.Models.Domain;
using BlazorApp.Models.Exception;
using BlazorApp.Repository;

namespace BlazorApp.Services;

public class ReservationService
{
    private readonly VehiculeRepository _vehiculeRepository;
    private readonly ReservationRepository _reservationRepository;

    public ReservationService(VehiculeRepository vehiculeRepository, ReservationRepository reservationRepository)
    {
        _vehiculeRepository = vehiculeRepository;
        _reservationRepository = reservationRepository;
    }

    public void Reserver(Vehicule vehicule, Client client, PlageReservation plageReservation)
    {
        vehicule.Reserver(client, plageReservation);
        _vehiculeRepository.Update();
    }
    
    /// <summary>
    /// Récupère les réservations d'un client
    /// </summary>
    /// <param name="client">Le client à chercher dans les réservations à son nom</param>
    /// <returns></returns>
    /// <exception cref="ReservationOfClientNotFound">Si le client n'a aucunes réservations</exception>
    public List<Reservation> Reservations(Client client)
    {
        var reservations = _reservationRepository.Reservations(client);
        if (reservations.Count == 0)
        {
            throw new ReservationOfClientNotFound();
        }

        return reservations;
    }
}