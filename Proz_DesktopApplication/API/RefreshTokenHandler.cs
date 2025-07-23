using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Proz_DesktopApplication;
using Proz_DesktopApplication.API;
using Proz_DesktopApplication.Sub_Sub_Usercontrols;

public class RefreshTokenHandler : DelegatingHandler
{

    private readonly IAuthAPI _authAPI;
    private readonly IServiceProvider _services;
    public RefreshTokenHandler(IAuthAPI authAPI, IServiceProvider services)
    {

        _authAPI = authAPI;
        _services = services;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {




        var originalRequest = await base.SendAsync(request, cancellationToken); //this actually will take the HttpRequestMessage object and will go to the other element in the pipline which is TokenAuthHandler 

        if (originalRequest.StatusCode == System.Net.HttpStatusCode.Unauthorized) //this will execute only when the request when from this object to TokenAuthHandler object and then to the the interent and then when response will come back from the server to the base object (DelegatingHandler) to the TokenAuthHandler and finally to the RefreshTokenHandler then this line will begin to execute.
        {

            var refreshSuccess = await TryRefreshToken(); //because of the previous request return the Unauthorized we are planning here to send another request without the knowing of the user because our access token is expired or removed

            if (refreshSuccess) //if we were able to get brand new tokens (our refresh token was still valid to create the access token then execute the follwoing :
            {
                var newTokens = TokenStorage.LoadTokens();
                if (newTokens != null && newTokens.Value.accessToken != null)
                {
                    // Retry original request

                    return await base.SendAsync(CloneRequest(request), cancellationToken); //now after inserting our new tokens again to the disk inside this computer we will now send another request to the server but notices that we didn't send the same HttpRequestMessage object that we sent previously but we are getting help from a method called CloneRequest which will try to copy everything from the old HttpRequestMessage object that was already used to create a brand new copy so we can send it to the server again (this is the rule, if we send a HttpRequestMessage object before then we can't send the exact object again anymore. Now the requset will go from this object (RefreshTokenHandler) to TokenAuthHandler object and then to the base DelegatingHandler object (which by default if we didn't make the TokenAuthHandler and the RefreshTokenHandler then normally the base DelegatingHandler object will send the request and recieve the response alone) and then to the internet and then to the server, after this the response will come in reverse to the application (user will see it then)
                }
            }
            else
            {
                var signin = App.Services.GetRequiredService<SigninWindow>();
                Application.Current.MainWindow = signin;
               
              
                Application.Current.Windows
                .OfType<Window>()
                .Where(w => w != signin)
                .ToList()
                .ForEach(w => w.Close());
                signin.Show();
                throw new UnauthorizedAccessException("Token refresh failed. Redirected to Signin.");
           
            }
        }

        return originalRequest;
    }

    private async Task<bool> TryRefreshToken()
    {
        try
        {
            var tokens = TokenStorage.LoadTokens();
            var request = new RefreshRequest
            {
                AccessToken = tokens.Value.accessToken,
                RefreshToken = tokens.Value.refreshToken

            };

            var response = await _authAPI.RefreshMyAccessToken(request);

            if (response.IsSuccessStatusCode &&
                !string.IsNullOrWhiteSpace(response.Content?.Token) &&
                !string.IsNullOrWhiteSpace(response.Content?.RefreshToken))
            {
                // Save new tokens
                TokenStorage.DeleteTokens();
                TokenStorage.SaveTokens(response.Content.Token, response.Content.RefreshToken);
                return true;
                // Launch dashboard directly


            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
    }

    private static HttpRequestMessage CloneRequest(HttpRequestMessage request)
    {
        var clone = new HttpRequestMessage(request.Method, request.RequestUri)
        {
            Content = request.Content,
            Version = request.Version
        };

        foreach (var header in request.Headers)
        {
            clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }

        return clone;
    }
}
