using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using WebApp.Authentication;
using WebApp.Models.Login;
using WebApp.Models.Register;
using WebApp.Services.Abstracts;

namespace WebApp.Services.Concretes
{
    public class IdentityService : IIdentityService
    {
        private readonly ApiClient apiClient;
        private readonly ILocalStorageService localStorageService;
        private readonly AuthenticationStateProvider authenticationStateProvider;
        private const string BasePath = "/Auth/";

        public IdentityService(ApiClient apiClient, ILocalStorageService localStorageService, AuthenticationStateProvider authenticationStateProvider)
        {
            this.apiClient = apiClient;
            this.localStorageService = localStorageService;
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            string path = BasePath + "Login";
            var response = await apiClient.PostAsync<LoginResponse, LoginRequest>(path, loginRequest);
            if (response is not null)
            {
                await ((CustomAuthStateProvider)authenticationStateProvider).MarkUserAsAuthenticated(response.AccessToken);
            }

            return response;
        }

        public async Task<RegisterResponse> Register(RegisterRequest registerRequest)
        {
            string path = BasePath + "Register";
            var response = await apiClient.PostAsync<RegisterResponse, RegisterRequest>(path, registerRequest);
            return response;
        }

        public async Task Logout()
        {
            await ((CustomAuthStateProvider)authenticationStateProvider).MarkUserAsLogout();
        }
    }
}
