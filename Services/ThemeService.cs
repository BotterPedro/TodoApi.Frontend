using Microsoft.JSInterop;

namespace TodoApi.Frontend.Services;

public class ThemeService
{
    private const string StorageKey = "theme";

    private readonly IJSRuntime _js;

    public event Action? OnChange;

    public bool IsDark { get; private set; }

    public ThemeService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task InitializeAsync()
    {
        var saved = await _js.InvokeAsync<string?>("todoApiStorage.get", StorageKey);
        IsDark = saved == "dark";
    }

    public async Task ToggleAsync()
    {
        IsDark = !IsDark;

        await _js.InvokeVoidAsync("todoApiStorage.set", StorageKey, IsDark ? "dark" : "light");
        await _js.InvokeVoidAsync("todoApiTheme.apply", IsDark);

        OnChange?.Invoke();
    }
}