using BlazorApp.Models.Domain;
using BlazorApp.Repository;

namespace BlazorApp.Services;

public class VehiculeService
{
    private readonly VehiculeRepository _vehiculeRepository;

    public VehiculeService(VehiculeRepository vehiculeRepository)
    {
        _vehiculeRepository = vehiculeRepository;
    }

    public List<Vehicule> VehiculesAReserver()
    {
        var vehicules = _vehiculeRepository.GetAll();
        var vehiculesAReserver = from vehicule in vehicules
            where vehicule.Disponibilite.Equals("LIBRE")
            select vehicule;
        return vehiculesAReserver.ToList();
    }
}