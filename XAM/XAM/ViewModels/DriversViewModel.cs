using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace XAM.ViewModels
{
    public class DriversViewModel : ViewModelBase, INavigationAware
    {
        private string _welcomeMsg;
        public string WelcomeMsg
        {
            get { return _welcomeMsg; }
            set { SetProperty(ref _welcomeMsg, value); }
        }
        public DriversViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "Drivers Page";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var wishedSeason = parameters.GetValue<string>("year");
            // TODO → Make api call and display a collection view of drivers
        }
    }
}
