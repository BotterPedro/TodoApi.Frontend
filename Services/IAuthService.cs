using TodoApi.Frontend.Models;

namespace TodoApi.Frontend.Services;

public interface IAuthService
{
    Task<TokenDto?> RegistrarAsync(RegistrarUsuarioDto dto);
    Task<TokenDto?> LoginAsync(LoginDto dto);
    Task LogoutAsync();
    Task<bool> EstaLogadoAsync();
    Task<string?> ObterNomeAsync();
}