using BlazorApp.Models.Domain;

namespace BlazorApp.Repository;

public class ReservationRepository
{
    private readonly AutolibContext _autolibContext;

    public ReservationRepository(AutolibContext autolibContext)
    {
        _autolibContext = autolibContext;
    }

    public void Save(Reservation reservation)
    {
        _autolibContext.Reservations.Add(reservation);
    }

    public List<Reservation> Reservations(Client client)
    {
        return _autolibContext.Reservations.Where(r => r.ClientId == client.Id).ToList();
    }
}