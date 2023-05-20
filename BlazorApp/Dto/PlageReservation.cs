namespace BlazorApp.Dto;

public record PlageReservation
{
    public DateTime start { get; init; }
    public DateTime end { get; init; }
}