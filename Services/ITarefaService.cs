using TodoApi.Frontend.Models;

namespace TodoApi.Frontend.Services;

public interface ITarefaService
{
    Task<List<TarefaDto>> ListarAsync();
    Task<TarefaDto?> ObterPorIdAsync(Guid id);
    Task<TarefaDto?> CriarAsync(CriarTarefaDto dto);
    Task<TarefaDto?> AtualizarAsync(Guid id, AtualizarTarefaDto dto);
    Task<bool> DeletarAsync(Guid id);
    Task<TarefaDto?> ConcluirAsync(Guid id);
    Task<TarefaDto?> ReabrirAsync(Guid id);
}