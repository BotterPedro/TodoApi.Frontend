namespace TodoApi.Frontend.Models;

public class CriarTarefaDto
{
    public string Titulo { get; set; } = string.Empty;
    public string? Descricao { get; set; }
}