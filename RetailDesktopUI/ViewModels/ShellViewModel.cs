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
       private SimpleContainer _container;
       public ShellViewModel( IEventAggregator events, SalesViewModel salesVM , SimpleContainer container)
        {
            _events = events;
            _salesVM = salesVM;
            _container = container;

            _events.Subscribe(this);

            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        public void Handle(LogOnEventModel message)
        {
            ActivateItem(_salesVM);
        }
    }
}
