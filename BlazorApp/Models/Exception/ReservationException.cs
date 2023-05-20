namespace BlazorApp.Models.Exception;

public class ReservationException : System.Exception
{
    public ReservationException() : base("La réservation pour ce véhicule est impossible") {}
    
    public ReservationException(string? message) : base(message)
    {
    }
}