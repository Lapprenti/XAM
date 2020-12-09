using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAM.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public INavigationService _navigationService { get; set; }
        public DelegateCommand GoToPage1 { get; private set; }

        public string Nom { get; set; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            _navigationService = navigationService;
            GoToPage1 = new DelegateCommand(GoToPage1Method);
        }

        void GoToPage1Method()
        {
            var navigationParams = new NavigationParameters
            {
                { "nom", Nom }
            };
            _navigationService.NavigateAsync("Page1", navigationParams);
        }
    }
}
