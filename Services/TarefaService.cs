using System.Net;
using System.Net.Http.Json;
using TodoApi.Frontend.Models;

namespace TodoApi.Frontend.Services;

public class TarefaService : ITarefaService
{
    private readonly HttpClient _http;

    public TarefaService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<TarefaDto>> ListarAsync()
    {
        var resultado = await _http.GetFromJsonAsync<List<TarefaDto>>("api/tarefas");
        return resultado ?? new List<TarefaDto>();
    }

    public async Task<TarefaDto?> ObterPorIdAsync(Guid id)
    {
        var response = await _http.GetAsync($"api/tarefas/{id}");
        if (response.StatusCode == HttpStatusCode.NotFound) return null;
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TarefaDto>();
    }

    public async Task<TarefaDto?> CriarAsync(CriarTarefaDto dto)
    {
        var response = await _http.PostAsJsonAsync("api/tarefas", dto);
        if (!response.IsSuccessStatusCode) return null;
        return await response.Content.ReadFromJsonAsync<TarefaDto>();
    }

    public async Task<TarefaDto?> AtualizarAsync(Guid id, AtualizarTarefaDto dto)
    {
        var response = await _http.PutAsJsonAsync($"api/tarefas/{id}", dto);
        if (response.StatusCode == HttpStatusCode.NotFound) return null;
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TarefaDto>();
    }

    public async Task<bool> DeletarAsync(Guid id)
    {
        var response = await _http.DeleteAsync($"api/tarefas/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<TarefaDto?> ConcluirAsync(Guid id)
    {
        var response = await _http.PatchAsync($"api/tarefas/{id}/concluir", null);
        if (response.StatusCode == HttpStatusCode.NotFound) return null;
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TarefaDto>();
    }

    public async Task<TarefaDto?> ReabrirAsync(Guid id)
    {
        var response = await _http.PatchAsync($"api/tarefas/{id}/reabrir", null);
        if (response.StatusCode == HttpStatusCode.NotFound) return null;
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TarefaDto>();
    }
}