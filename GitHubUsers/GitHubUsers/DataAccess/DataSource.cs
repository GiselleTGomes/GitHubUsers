using GitHubUsers.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace GitHubUsers.DataAccess
{
    public static class DataSource
    {
        static HttpClient client = new HttpClient();

        public static User GetAdministrator() 
        {
            return new User { Login = "Admin", Password = "1234" };
        }

        public static async Task<IList<GitUser>> GetGitUsersAsync()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://api.github.com/users"),
                };

                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize<List<GitUser>>(jsonString);
                    }
                }
            }

            return null;
        }
    }
}
