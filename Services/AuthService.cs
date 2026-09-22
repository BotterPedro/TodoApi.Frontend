using System.Net;
using System.Net.Http.Json;
using TodoApi.Frontend.Models;

namespace TodoApi.Frontend.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _http;
    private readonly ITokenStorage _storage;
    private readonly AuthState _authState;

    public AuthService(HttpClient http, ITokenStorage storage, AuthState authState)
    {
        _http = http;
        _storage = storage;
        _authState = authState;
    }

    public async Task<TokenDto?> RegistrarAsync(RegistrarUsuarioDto dto)
    {
        var response = await _http.PostAsJsonAsync("api/auth/registrar", dto);

        if (!response.IsSuccessStatusCode)
            return null;

        var token = await response.Content.ReadFromJsonAsync<TokenDto>();
        if (token is not null)
        {
            await _storage.SalvarSessaoAsync(token.Token, token.Nome, token.Email);
            _authState.NotificarMudanca();
        }

        return token;
    }

    public async Task<TokenDto?> LoginAsync(LoginDto dto)
    {
        var response = await _http.PostAsJsonAsync("api/auth/login", dto);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
            return null;

        response.EnsureSuccessStatusCode();

        var token = await response.Content.ReadFromJsonAsync<TokenDto>();
        if (token is not null)
        {
            await _storage.SalvarSessaoAsync(token.Token, token.Nome, token.Email);
            _authState.NotificarMudanca();
        }

        return token;
    }

    public async Task LogoutAsync()
    {
        await _storage.LimparSessaoAsync();
        _authState.NotificarMudanca();
    }

    public async Task<bool> EstaLogadoAsync()
    {
        var token = await _storage.GetTokenAsync();
        return !string.IsNullOrWhiteSpace(token);
    }

    public async Task<string?> ObterNomeAsync()
    {
        return await _storage.GetNomeAsync();
    }
}