using BlazorApp.Dto;
using BlazorApp.Models.Domain;
using BlazorApp.Utils;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services;

public class AuthentificationService
{
    private readonly AutolibContext _autolibContext;
    private readonly string _pepper;
    private readonly int _iteration = 3;

    public AuthentificationService(AutolibContext autolibContext)
    {
        _autolibContext = autolibContext;
        _pepper = Environment.GetEnvironmentVariable("PasswordHashExamplePepper") ?? throw new Exception("Impossible de récupèrer le pepper");
        _iteration = 3;
    }
    
    
    public async Task<ConnectedUser> Login(LoginData loginData, CancellationToken cancellationToken)
    {
        var user = await _autolibContext.Clients
            .FirstOrDefaultAsync(x => x.Prenom.Equals(loginData.Email, StringComparison.OrdinalIgnoreCase), cancellationToken);

        if (user == null)
            throw new Exception("Username or password did not match.");

        var passwordHash = PasswordHasher.ComputeHash(loginData.Password, user.Salt, _pepper, _iteration);
        if (user.Password != passwordHash)
            throw new Exception("Username or password did not match.");
        
        return new ConnectedUser(user.IdClient, user.Prenom);
    }
    
    public async Task<ConnectedUser> Register(UserRegistration registrationData, CancellationToken cancellationToken)
    {
        var user = new Client()
        {
            Prenom = registrationData.Prenom,
            Nom = registrationData.Nom,
            DateNaissance = registrationData.DateNaissance,
            Salt = PasswordHasher.GenerateSalt()
        };
        user.Password = PasswordHasher.ComputeHash(registrationData.Password, user.Salt, _pepper, _iteration);
        await _autolibContext.Clients.AddAsync(user, cancellationToken);
        await _autolibContext.SaveChangesAsync(cancellationToken);

        return new ConnectedUser(user.IdClient, user.Prenom);
    }
}