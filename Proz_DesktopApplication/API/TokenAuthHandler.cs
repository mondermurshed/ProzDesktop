using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

public class TokenAuthHandler : DelegatingHandler //think of DelegatingHandler as the type that will intercepts every HTTP request and modifiy before it's sent to the internet.
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) //SendAsync is the main function of any DelegatingHandler. It runs automatically whenever your app makes an API call using Refit or HttpClient. Think of it like: “Hey, before we send this request to the server, let's run SendAsync and maybe modify it.”
    {
        var tokens = TokenStorage.LoadTokens();
        if (tokens != null && tokens.Value.accessToken != null)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.Value.accessToken);
        }

        return await base.SendAsync(request, cancellationToken); //What does "base" mean?  “Call the method from the parent class (also called the base class) that I inherited from.” That means: your class is inheriting from a built-in class called DelegatingHandler. And DelegatingHandler has its own method called SendAsync.  So base.SendAsync(...) means: “Run the original SendAsync method from the DelegatingHandler class.” You’re just adding custom logic before that — like adding the Authorization header — but the actual job of sending the request still happens in the base method. Also the the "base.SendAsync(request, cancellationToken)" is the final point before sending the request over the internet, just think of it like we call an API by executing this "base.SendAsync(request, cancellationToken)" after we have modifiy the header of the request message using our class TokenAuthHandler. So currently what is happening is that this SendAsync is executed first (not the the SendAsync of the base class DelegatingHandler but the SendAsync of TokenAuthHandler) and finally we the base.SendAsync(request, cancellationToken) is executed which is the final point before sending the request over the internet.
    }
}
