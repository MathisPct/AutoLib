using BlazorApp.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Repository;

public class StationRepository
{
    private readonly AutolibContext _autolibContext;
    
    public StationRepository(AutolibContext autolibContext)
    {
        _autolibContext = autolibContext;
    }

    public List<Station> GetAll()
    {
        return _autolibContext.Stations.Include(station => station.Bornes).ToList();
    }
}