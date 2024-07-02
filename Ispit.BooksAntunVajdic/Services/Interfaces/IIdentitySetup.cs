namespace Ispit.BooksAntunVajdic.Services.Interfaces
{
    public interface IIdentitySetup
    {
        Task CreatePlatformAdminAsync();
        Task CreateRoleAsync(string role);
    }
}