using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebApp.Extensions;

namespace WebApp
{
    public class ApiClient
    {
        private readonly HttpClient httpClient;
        private readonly NavigationManager navigationManager;
        private readonly AuthenticationStateProvider authenticationStateProvider;
        private readonly ILocalStorageService localStorageService;

        public ApiClient(HttpClient httpClient, NavigationManager navigationManager, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            this.navigationManager = navigationManager;
            this.authenticationStateProvider = authenticationStateProvider;
            this.localStorageService = localStorageService;
        }

        public async Task SetAuthorizeHeader()
        {
            string token = await localStorageService.GetTokenAsync();
            if (token is not null && string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<TResponse> GetFromJsonAsync<TResponse>(string path)
        {
            await SetAuthorizeHeader();
            return await httpClient.GetFromJsonAsync<TResponse>(path);
        }

        public async Task<TResponse> PostAsync<TResponse, TRequest>(string path, TRequest requestData)
        {
            await SetAuthorizeHeader();
            var response = await httpClient.PostAsJsonAsync(path, requestData);
            if (response is not null && response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync());
            }

            return default;
        }

        public async Task<TResponse> PutAsync<TResponse, TRequest>(string path, TRequest requestData)
        {
            await SetAuthorizeHeader();
            var response = await httpClient.PutAsJsonAsync(path, requestData);
            if (response is not null && response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync());
            }
            return default;
        }

        public async Task<TResponse> DeleteAsync<TResponse>(string path)
        {
            await SetAuthorizeHeader();
            return await httpClient.DeleteFromJsonAsync<TResponse>(path);
        }
    }
}
