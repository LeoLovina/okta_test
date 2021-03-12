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
    public class SimpleApiService : IApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ITokenService _tokenService;
        public SimpleApiService(ITokenService tokenService, IHttpClientFactory clientFactory)
        {
            _tokenService = tokenService;
            _clientFactory = clientFactory;
        }

        public async Task<IList<string>> GetValues()
        {
            var client = _clientFactory.CreateClient("ApiHttpClient");
            List<string> values = new List<string>();
            var token = await _tokenService.GetToken();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var res = await client.GetAsync($"api/values");
            if(res.IsSuccessStatusCode)
            {
                var json = res.Content.ReadAsStringAsync().Result;
                values = JsonConvert.DeserializeObject<List<string>>(json);
            }
            else
            {
                values = new List<string> { res.StatusCode.ToString(), res.ReasonPhrase };
            }
            return values;
        }
    }
}
