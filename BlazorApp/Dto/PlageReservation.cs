namespace BlazorApp.Dto;

public record PlageReservation
{
    public DateTime start { get; set; } = DateTime.Now;
    public DateTime end { get; set; } = DateTime.Now + TimeSpan.FromDays(1); 
}