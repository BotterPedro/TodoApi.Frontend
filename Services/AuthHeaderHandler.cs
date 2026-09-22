using System.Net.Http.Headers;

namespace TodoApi.Frontend.Services;

public class AuthHeaderHandler : DelegatingHandler
{
    private readonly ITokenStorage _storage;

    public AuthHeaderHandler(ITokenStorage storage)
    {
        _storage = storage;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = await _storage.GetTokenAsync();

        if (!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}