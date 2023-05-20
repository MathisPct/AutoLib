using BlazorApp.Models.Domain;
using BlazorApp.Repository;

namespace BlazorApp.Services;

public class StationService
{
    private readonly StationRepository _stationRepository;

    public StationService(StationRepository stationRepository)
    {
        _stationRepository = stationRepository;
    }

    public List<Station> Stations()
    {
        return _stationRepository.GetAll();
    }
}