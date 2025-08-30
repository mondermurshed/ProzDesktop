using Microsoft.AspNetCore.SignalR.Client;
using Proz_DesktopApplication.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proz_DesktopApplication.HelperServices
{
    public class RoleChangedEvent
    {
        public string RoleName { get; set; }
    }
    public class MainHubService
    {
        public HubConnection Connection { get;  }

        public MainHubService(TokenService tokenService)
        {
            Connection = new HubConnectionBuilder()
                .WithUrl("https://api.prozsupport.xyz/hubs/Main", options =>
                {
                    options.AccessTokenProvider = async () =>
                    {
                        var token = await tokenService.GetFreshAccessTokenAsync();
                        
                        return token;
                        //return await tokenService.GetFreshAccessTokenAsync();
                    };
                })
                .WithAutomaticReconnect()
                .Build();
        }
    }

    public class TokenService
    {
      
        private string? _accessToken;
        private DateTime _expiresAt;
        private readonly IAuthAPI _authAPI;
        public TokenService(IAuthAPI authAPI)
        {
            _authAPI = authAPI;
        }

        public async Task<string> GetFreshAccessTokenAsync()
        {
            if (string.IsNullOrEmpty(_accessToken) || DateTime.UtcNow >= _expiresAt)
            {
                try
                {
                    var tokens = TokenStorage.LoadTokens();
                    string DeviceToken = TokenStorage.GetOrCreateDeviceToken();
                    var request = new RefreshRequest
                    {
                        DeviceToken = DeviceToken,
                        RefreshToken = tokens.Value.refreshToken
                    };

                    var response = await _authAPI.RefreshMyAccessToken(request);
                    Console.Write("fa");
                    if (response.IsSuccessStatusCode &&
                        !string.IsNullOrWhiteSpace(response.Content?.Token) &&
                        !string.IsNullOrWhiteSpace(response.Content?.RefreshToken))
                    {
                        // Save new tokens
                        TokenStorage.DeleteTokens();
                        TokenStorage.SaveTokens(response.Content.Token, response.Content.RefreshToken);
                        var Updatedtokens = TokenStorage.LoadTokens();
                        _accessToken = Updatedtokens.Value.accessToken;
                        _expiresAt = DateTime.UtcNow.AddSeconds(response.Content.ExpiredInSeconds - 30); 
                  
                      

                    }
                    else
                    {
                        _accessToken = "";
                    }
                }
                catch
                {
                    _accessToken = "";
                }

             
            }
      
            return _accessToken!;
        }
    }

   

}
