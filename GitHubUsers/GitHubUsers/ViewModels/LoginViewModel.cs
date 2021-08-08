using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GitHubUsers.DataAccess;
using GitHubUsers.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace GitHubUsers.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        string login;
        string password;
        bool isInvalid;
        User administrator;
        
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

        public bool IsInvalid 
        {
            get => isInvalid;
            set => SetProperty(ref isInvalid, value);
        }
        public User Administrator 
        {
            get => administrator;
            set => SetProperty(ref administrator, value);
        }   
        
        public ICommand EnterCommand { get; }
        public ICommand GoToGitUsers { get; set; }


        public LoginViewModel()
        {
            EnterCommand = new Command(OnEnter);
            Administrator = DataSource.GetAdministrator();
        }

        private void OnEnter()    
        {

            if (Administrator.Login.ToLower() == Login?.ToLower() && Administrator.Password == Password)
            {
                IsInvalid = false;
                Login = null;
                Password = null;
                // go to git users page
                GoToGitUsers?.Execute(null);
            }
            else
                IsInvalid = true;

        }
    }
}
