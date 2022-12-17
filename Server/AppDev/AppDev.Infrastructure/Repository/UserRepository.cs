using AppDev.Applications.Interface;
using AppDev.Domain;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace AppDev.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly string _baseUrl = "https://localhost:7040";

    public async Task<List<User>> AllUserAsync()
    {
        var users = new List<User>();
        try
        {
            using var client = new HttpClient();
            string url = $"{_baseUrl}/api/User";
            var apiResponse = await client.GetAsync(url);

            if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var response = await apiResponse.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<User>>(response);
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }

        return users;
    }

    public async Task<Guid> AddUserAsync(User user)
    {
        var userId = Guid.Empty;
        try
        {
            using var client = new HttpClient();
            var content = new { Id = user.Id, Email = user.Email, Name = user.Name, Password = user.Password, RoleId = 1};
            string url = $"{_baseUrl}/api/User";
            var apiResponse = await client.PostAsJsonAsync(url, content);

            if(apiResponse.IsSuccessStatusCode) 
            {
                var response = await apiResponse.Content.ReadAsStringAsync();
                userId = JsonConvert.DeserializeObject<Guid>(response);

            }

        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        
        return userId;
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {
        bool isDeleted = false;

        try
        {
            using var client = new HttpClient();
            var content = new { Id = userId };
            string url = $"{_baseUrl}/api/User";
            var apiResponse = await client.DeleteFromJsonAsync(url, content);
        }
    }
}