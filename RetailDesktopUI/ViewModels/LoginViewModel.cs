using Caliburn.Micro;
using RetailDesktopUI.Helpers;
using RMDesktopUI.Library.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
		private string _userName;
		private string _password;
		private IAPIHelper _apiHelper;
		public LoginViewModel(IAPIHelper apiHelper)
		{
			_apiHelper = apiHelper;
		}
		public string UserName
		{
			get { return _userName; }
			set 
			{ 
				_userName = value;
				NotifyOfPropertyChange(() => UserName);
			}
		}
		public string Password
		{
			get { return _password; }
			set
			{ 
				_password = value;
				NotifyOfPropertyChange(() => Password);
			}
		}
		//private bool _isErrorVisible;

		public bool IsErrorVisible
		{
			get
			{
				bool output = false;
				if(ErrorMessage?.Length > 0)
				{
					output = true;
				}
				
				return output;
			}
			
		}
		private string _errorMessage;

		public string ErrorMessage
		{
			get { return _errorMessage; }
			set 
			{
				_errorMessage = value;
				NotifyOfPropertyChange(() => IsErrorVisible);
				NotifyOfPropertyChange(() => ErrorMessage);
			}
		}

		public bool CanLogIn(string userName, string password)
		{
			bool output = false;
			if(UserName?.Length > 0 )
			{
				output = true;
			}
			return output;
		}
		public async Task  LogIn(string userName, string password)
		{
			try
			{
				ErrorMessage = "";
				var result = await _apiHelper.Authenticate(UserName, Password);
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
			}
		}
	}
}
