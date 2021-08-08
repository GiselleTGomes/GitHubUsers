using GitHubUsers.ViewModels;
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
    public partial class GitUsersPage : ContentPage
    {
        public GitUsersViewModel ViewModel { get; }
        public GitUsersPage()
        {
            ViewModel = new GitUsersViewModel();
            BindingContext = ViewModel;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnLoad();
        }
    }
}