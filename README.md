# Github Users
Xamarin Forms Application, consuming API https://api.github.com/users with design pattern MVVM. Available on Android, iOS and Windows platforms.

![screenshots](https://user-images.githubusercontent.com/68792259/128646150-78898aba-9660-448b-99f0-42a3ac18868a.png)

<h2>Library</h2>

* Refractored.MvvmHelpers : used for data binding and synchronous and asynchronous commands
  
 <h2>Data Access</h2>
 Get local user adminstrator and git users from Github API
 <p></p>
 
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

<h2>Conclusion</h2>
This is an example application that validates a user's login and displays a list of Github users. 
