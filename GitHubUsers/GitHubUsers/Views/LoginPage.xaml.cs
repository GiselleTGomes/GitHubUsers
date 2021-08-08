using GitHubUsers.ViewModels;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GitHubUsers.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel ViewModel { get; }
        public LoginPage()
        {
            ViewModel = new LoginViewModel();
            ViewModel.GoToGitUsers = new AsyncCommand(OnGoToGitUsers); 
            BindingContext = ViewModel;
            InitializeComponent();
        }

        private async Task OnGoToGitUsers()
        {
           await Navigation.PushAsync(new GitUsersPage());
        }
    }
}