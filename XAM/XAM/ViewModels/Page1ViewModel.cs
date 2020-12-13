using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace XAM.ViewModels
{
    public class Page1ViewModel : ViewModelBase, INavigationAware
    {
        private string _welcomeMsg;
        public string WelcomeMsg
        {
            get { return _welcomeMsg; }
            set { SetProperty(ref _welcomeMsg, value); }
        }
        public Page1ViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "Page 1";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var nom = parameters.GetValue<string>("nom");
            WelcomeMsg = $"Bienvenue {nom} !";
        }
    }
}
