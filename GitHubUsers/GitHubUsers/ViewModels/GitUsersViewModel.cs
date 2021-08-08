using GitHubUsers.DataAccess;
using GitHubUsers.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubUsers.ViewModels
{
    public class GitUsersViewModel : BaseViewModel     
    {
        public ObservableRangeCollection<GitUser> Items { get; }

        public GitUsersViewModel() 
        {
            Items = new ObservableRangeCollection<GitUser>();
        }

        public async void OnLoad() 
        {
            var gitUsers = await DataSource.GetGitUsersAsync();

            if (gitUsers?.Count > 0)
                Items.ReplaceRange(gitUsers);
            else
                Items.Clear();

        }
    }
}
