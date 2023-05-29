namespace BlazorApp.Models.Exception;

public class ReservationOfClientNotFound : System.Exception
{
    public ReservationOfClientNotFound(): base("Vos réservations n'ont pas été trouvées") { }
}