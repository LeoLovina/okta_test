using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebClient.Models;

namespace WebClient.Services
{
    public class OktaTokenService : ITokenService
    {
        private OktaToken token = new OktaToken();
        private readonly IOptions<OktaSettings> _oktaSettings;
        private HttpClient _httpClient;

        public OktaTokenService(IOptions<OktaSettings> oktaSettings, HttpClient httpClient)
        {
            _oktaSettings = oktaSettings;
            _httpClient = httpClient;
        }

        public async Task<string> GetToken()
        {
            if (!this.token.IsValidAndNotExpiring)
            {
                this.token = await this.GetNewAccessToken();
            }

            return token.AccessToken;
        }

        public async Task<OktaToken> GetNewAccessToken()
        {
            OktaToken token;
            var client_id = _oktaSettings.Value.ClientId;
            var client_secret = _oktaSettings.Value.ClientSecret;
            var clientCreds = System.Text.Encoding.UTF8.GetBytes($"{client_id}:{client_secret}");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(clientCreds));
            var postMessage = new Dictionary<string, string>();
            postMessage.Add("grant_type", "client_credentials");
            postMessage.Add("scope", "access_token");
            var request = new HttpRequestMessage(HttpMethod.Post, _oktaSettings.Value.TokenUrl)
            {
                Content = new FormUrlEncodedContent(postMessage)
            };
            try
            {
                var response = await _httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    token = JsonConvert.DeserializeObject<OktaToken>(json);
                    token.ExpiresAt = DateTime.UtcNow.AddSeconds(this.token.ExpiresIn);
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new ApplicationException("Unable to retrieve access token from Okta");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return token;
        }
    }

    public class OktaToken
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }

        public DateTime ExpiresAt { get; set; }

        public string Scope { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        public bool IsValidAndNotExpiring
        {
            get
            {
                return !String.IsNullOrEmpty(this.AccessToken) &&
                       this.ExpiresAt > DateTime.UtcNow.AddSeconds(30);
            }
        }
    }
}
