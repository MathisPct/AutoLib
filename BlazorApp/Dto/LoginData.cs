namespace BlazorApp.Dto;

public sealed record LoginData()
{
    public string Email
    {
        get;
        set;
    }

    public string Password
    {
        get;
        set;
    }
}