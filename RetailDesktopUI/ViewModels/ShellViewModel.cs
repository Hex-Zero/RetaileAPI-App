using Caliburn.Micro;
using RetailDesktopUI.EventModels;
using RMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailDesktopUI.ViewModels
{
  
    public class ShellViewModel : Conductor<object> , IHandle<LogOnEventModel>
    {
       private IEventAggregator _events;
       private SalesViewModel _salesVM;
       private ILoggedInUserModel _user;
       public ShellViewModel( IEventAggregator events, SalesViewModel salesVM , ILoggedInUserModel user )
        {
            _events = events;
            _salesVM = salesVM;
            _user = user;

            _events.Subscribe(this);

            ActivateItem(IoC.Get<LoginViewModel>());
        }
        public void LogOut()
        {
            _user.LogOffUser();
            ActivateItem(IoC.Get<LoginViewModel>());
             NotifyOfPropertyChange(() => IsLoggedIn);
        }
        public bool IsLoggedIn
        {
            get
            {
                bool output = false;
                if (string.IsNullOrWhiteSpace(_user.Token) == false)
                {
                    output = true;
                }
                return output;
            }
        }
        public void ExitApplication()
        {
            TryClose();
        }
        public void Handle(LogOnEventModel message)
        {
            ActivateItem(_salesVM);
            NotifyOfPropertyChange(() => IsLoggedIn);
        }
    }
}
