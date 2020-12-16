using System;
using System.Collections.Generic;
using System.Text;
using Business.contracts;
using Entities;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace XAM.ViewModels
{
    public class DriversViewModel : ViewModelBase, INavigationAware
    {
        private IBLL _BLL { get; set; }

        private List<Constructor> _constructors;

        public List<Constructor> Constructors
        {
            get { return _constructors; }
            set { SetProperty(ref _constructors, value); }
        }

        private List<Driver> _drivers;

        public List<Driver> Drivers
        {
            get { return _drivers; }
            set { SetProperty(ref _drivers, value); }
        }

        public DriversViewModel(INavigationService navigationService, IBLL bLL) : base(navigationService)
        {
            Title = "Choose a season";
            _BLL = bLL;
        }
        public DriversViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "Drivers Page";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            int wishedSeason = int.Parse(parameters.GetValue<string>("year"));
            //Console.WriteLine(wishedSeason);
            // TODO → Make api call and display a collection view of drivers
            this.GetAllDriverForSpecificYear(wishedSeason);
        }

        async void GetAllContructorsForSpecificYear(int wishedSeason)
        {
            Constructors = await this._BLL.GetAllContructorsForSpecificYear(wishedSeason);
        }

        async void GetAllDriverForSpecificYear(int wishedSeason)
        {
            Drivers = await this._BLL.GetAllDriverForSpecificYear(wishedSeason);
        }
    }
}
