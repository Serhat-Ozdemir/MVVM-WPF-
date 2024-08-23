using DenemeMVVM.Commands;
using DenemeMVVM.Models;
using DenemeMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DenemeMVVM.ViewModels
{
    internal class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; }

        public LoginViewModel(Restaurant restaurant, NavigationStore navigationStore) 
        {
            LoginCommand = new LoginCommand(this, restaurant, navigationStore);
        }

		private string userId;
		public string UserId
		{
			get
			{
				return userId;
			}
			set
			{
				userId = value;
				OnPropertyChanged(nameof(UserId));
			}
		}

		private string password;
		public string Password
		{
			get
			{
				return password;
			}
			set
			{
				password = value;
				OnPropertyChanged(nameof(Password));
			}
		}
	}
}
