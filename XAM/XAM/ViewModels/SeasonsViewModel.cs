using Business.contracts;
using Entities;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace XAM.ViewModels
{
    public class SeasonsViewModel : ViewModelBase
    {
        public INavigationService _navigationService { get; set; }
        public DelegateCommand GoToDrivers { get; private set; }

        public Year SelectedYear { get; set; }

        private List<Year> _seasons;
        public List<Year> Seasons
        {
            get { return _seasons; }
            set { SetProperty(ref _seasons, value); }
        }

        private IBLL _BLL { get; set; }
        public SeasonsViewModel(INavigationService navigationService, IBLL bLL)
            : base(navigationService)
        {
            Title = "Choose a season";
            _navigationService = navigationService;
            GoToDrivers = new DelegateCommand(GoToDriversMethod);
            _BLL = bLL;
            this.GetAllSeasons();
        }

        async void GetAllSeasons()
        {
            Seasons = await _BLL.GetAllSeasons();
        }

        void GoToDriversMethod()
        {
            //SelectedYear = 2020;
            var navigationParams = new NavigationParameters
            {
                { "year", SelectedYear.Season }
            };
            _navigationService.NavigateAsync("DriversPage", navigationParams);
        }
    }
}
