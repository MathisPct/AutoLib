using BlazorApp.Dto;
using BlazorApp.Models.Domain;
using BlazorApp.Repository;

namespace BlazorApp.Services;

public class ReservationService
{
    private readonly VehiculeRepository _vehiculeRepository;

    public ReservationService(VehiculeRepository vehiculeRepository)
    {
        _vehiculeRepository = vehiculeRepository;
    }

    public void Reserver(Vehicule vehicule, Client client, PlageReservation plageReservation)
    {
        // TODO: gérer l'authent
        vehicule.Reserver(client, plageReservation);
        _vehiculeRepository.Update();
    }
}