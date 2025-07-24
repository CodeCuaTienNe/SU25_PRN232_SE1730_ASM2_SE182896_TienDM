using System.Security.Claims;
using System.Text.Json;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace DNATestingSystem.BlazorWAS.GraphQLClients.TienDM.Services
{
    public class AuthService
    {
        private readonly IJSRuntime _jsRuntime;
        public AuthService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<UserInfo?> GetCurrentUserAsync()
        {
            var userJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "user");
            if (string.IsNullOrEmpty(userJson)) return null;
            return JsonSerializer.Deserialize<UserInfo>(userJson);
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            var user = await GetCurrentUserAsync();
            return user != null;
        }

        public async Task<int?> GetUserRoleAsync()
        {
            var user = await GetCurrentUserAsync();
            return user?.Role;
        }

        public async Task LogoutAsync()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "user");
        }
    }

    public class UserInfo
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public int Role { get; set; }
        public int RoleId { get { return Role; } set { Role = value; } }
    }
}
