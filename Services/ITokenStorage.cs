namespace TodoApi.Frontend.Services;

public interface ITokenStorage
{
    Task<string?> GetTokenAsync();
    Task<string?> GetNomeAsync();
    Task<string?> GetEmailAsync();
    Task SalvarSessaoAsync(string token, string nome, string email);
    Task LimparSessaoAsync();
}