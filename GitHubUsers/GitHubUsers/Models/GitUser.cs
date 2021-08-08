using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace GitHubUsers.Models
{
    public class GitUser : ObservableObject
    {
        int id;
        string login;
        string avatar;

        [Key]
        [JsonPropertyName("id")]
        public int Id 
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        [JsonPropertyName("login")]
        public string Login 
        {
            get => login;
            set => SetProperty(ref login, value);
        }

        [JsonPropertyName("avatar_url")]
        public string Avatar 
        {
            get => avatar;
            set => SetProperty(ref avatar, value);
        }

    }
}
