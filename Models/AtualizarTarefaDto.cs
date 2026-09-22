namespace TodoApi.Frontend.Models;

public class AtualizarTarefaDto
{
    public string Titulo { get; set; } = string.Empty;
    public string? Descricao { get; set; }
}