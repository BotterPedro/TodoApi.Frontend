using System.Net;
using System.Net.Http.Json;
using TodoApi.Frontend.Models;

namespace TodoApi.Frontend.Services;

public class TarefaService : ITarefaService
{
    private readonly HttpClient _http;
    private readonly IAuthService _authService;

    public TarefaService(HttpClient http, IAuthService authService)
    {
        _http = http;
        _authService = authService;
    }

    public async Task<List<TarefaDto>> ListarAsync()
    {
        var response = await _http.GetAsync("api/tarefas");

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            await _authService.LogoutAsync();
            return new List<TarefaDto>();
        }

        response.EnsureSuccessStatusCode();
        var resultado = await response.Content.ReadFromJsonAsync<List<TarefaDto>>();
        return resultado ?? new List<TarefaDto>();
    }

    public async Task<TarefaDto?> ObterPorIdAsync(Guid id)
    {
        var response = await _http.GetAsync($"api/tarefas/{id}");
        if (response.StatusCode == HttpStatusCode.NotFound) return null;
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            await _authService.LogoutAsync();
            return null;
        }
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TarefaDto>();
    }

    public async Task<TarefaDto?> CriarAsync(CriarTarefaDto dto)
    {
        var response = await _http.PostAsJsonAsync("api/tarefas", dto);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            await _authService.LogoutAsync();
            return null;
        }

        if (!response.IsSuccessStatusCode) return null;
        return await response.Content.ReadFromJsonAsync<TarefaDto>();
    }

    public async Task<TarefaDto?> AtualizarAsync(Guid id, AtualizarTarefaDto dto)
    {
        var response = await _http.PutAsJsonAsync($"api/tarefas/{id}", dto);
        if (response.StatusCode == HttpStatusCode.NotFound) return null;
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            await _authService.LogoutAsync();
            return null;
        }
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TarefaDto>();
    }

    public async Task<bool> DeletarAsync(Guid id)
    {
        var response = await _http.DeleteAsync($"api/tarefas/{id}");
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            await _authService.LogoutAsync();
            return false;
        }
        return response.IsSuccessStatusCode;
    }

    public async Task<TarefaDto?> ConcluirAsync(Guid id)
    {
        var response = await _http.PatchAsync($"api/tarefas/{id}/concluir", null);
        if (response.StatusCode == HttpStatusCode.NotFound) return null;
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            await _authService.LogoutAsync();
            return null;
        }
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TarefaDto>();
    }

    public async Task<TarefaDto?> ReabrirAsync(Guid id)
    {
        var response = await _http.PatchAsync($"api/tarefas/{id}/reabrir", null);
        if (response.StatusCode == HttpStatusCode.NotFound) return null;
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            await _authService.LogoutAsync();
            return null;
        }
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TarefaDto>();
    }
}