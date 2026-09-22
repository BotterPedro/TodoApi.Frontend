using Microsoft.JSInterop;

namespace TodoApi.Frontend.Services;

public class TokenStorage : ITokenStorage
{
    private const string TokenKey = "authToken";
    private const string NomeKey = "nomeUsuario";
    private const string EmailKey = "emailUsuario";

    private readonly IJSRuntime _js;

    public TokenStorage(IJSRuntime js)
    {
        _js = js;
    }

    public Task<string?> GetTokenAsync()
        => _js.InvokeAsync<string?>("todoApiStorage.get", TokenKey).AsTask();

    public Task<string?> GetNomeAsync()
        => _js.InvokeAsync<string?>("todoApiStorage.get", NomeKey).AsTask();

    public Task<string?> GetEmailAsync()
        => _js.InvokeAsync<string?>("todoApiStorage.get", EmailKey).AsTask();

    public async Task SalvarSessaoAsync(string token, string nome, string email)
    {
        await _js.InvokeVoidAsync("todoApiStorage.set", TokenKey, token);
        await _js.InvokeVoidAsync("todoApiStorage.set", NomeKey, nome);
        await _js.InvokeVoidAsync("todoApiStorage.set", EmailKey, email);
    }

    public async Task LimparSessaoAsync()
    {
        await _js.InvokeVoidAsync("todoApiStorage.remove", TokenKey);
        await _js.InvokeVoidAsync("todoApiStorage.remove", NomeKey);
        await _js.InvokeVoidAsync("todoApiStorage.remove", EmailKey);
    }
}