using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GitHubUsers.Models
{
    public class User : ObservableObject
    {
        Guid id;
        string login;
        string password;

        [Key]
        public Guid Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string Login
        {
            get => login;
            set => SetProperty(ref login, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public User()
        {
            Id = Guid.NewGuid();
        }
    }

}
