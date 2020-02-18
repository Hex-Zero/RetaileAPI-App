using Caliburn.Micro;
using RetailDesktopUI.EventModels;
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
       public ShellViewModel( IEventAggregator events, SalesViewModel salesVM )
        {
            _events = events;
            _salesVM = salesVM;

            _events.Subscribe(this);

            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public void Handle(LogOnEventModel message)
        {
            ActivateItem(_salesVM);
        }
    }
}
