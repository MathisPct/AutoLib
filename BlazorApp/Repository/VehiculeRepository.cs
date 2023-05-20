using BlazorApp.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Repository;

public class VehiculeRepository
{
    private readonly AutolibContext _autolibContext;

    public VehiculeRepository(AutolibContext autolibContext)
    {
        _autolibContext = autolibContext;
    }

    public List<Vehicule> GetAll()
    {
        return this._autolibContext.Vehicules.Include(v => v.TypeVehiculeNavigation).ToList();
    }

    public void Update()
    {
        _autolibContext.SaveChanges();
    }
}