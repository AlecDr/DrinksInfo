
using System.Net;
using System.Text;

namespace Tests.Helpers;

internal class StaticDrinksJsonHttpMessageHandler(string json) : HttpMessageHandler
{
    private readonly string Json = json;

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(Json, Encoding.UTF8, "application/json"),
        };

        return Task.FromResult(response);
    }
}
