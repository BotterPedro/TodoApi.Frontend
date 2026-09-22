namespace TodoApi.Frontend.Services;

public class AuthState
{
    public event Action? OnChange;

    public void NotificarMudanca() => OnChange?.Invoke();
}