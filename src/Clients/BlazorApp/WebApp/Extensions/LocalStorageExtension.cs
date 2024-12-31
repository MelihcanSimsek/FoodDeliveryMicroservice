using Blazored.LocalStorage;

namespace WebApp.Extensions
{
    public static class LocalStorageExtension
    {
        public static async Task<string> GetTokenAsync(this ILocalStorageService localStorage)
        {
            return await localStorage.GetItemAsync<string>("token");
        }

        public static async Task DeleteTokenAsync(this ILocalStorageService localStorage)
        {
            await localStorage.RemoveItemAsync("token");
        }

        public static async Task SetTokenAsync(this ILocalStorageService localStorage, string token)
        {
            await localStorage.SetItemAsync("token", token);
        }
    }
}
