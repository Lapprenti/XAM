using Business.contracts;
using Entities;
using Prism.Navigation;
using System;
using System.Collections.Generic;

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
            Title = "Liste des pilotes";
            _BLL = bLL;
            //MessagingCenter.Subscribe<SeasonsViewModel, DriversViewModel>(this, "IsDark", // essai implementation messaging center
            //    (ViewModelBase, IsDark) =>
            //    {
            //        Console.WriteLine(IsDark); 
            //    });
            Console.WriteLine(IsDark); // Ouput false but switch is true on parent page binded with two way to view model base property
        }
        public DriversViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "Drivers Page";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            IsDark = parameters.GetValue<bool>("isDark");
            int wishedSeason = int.Parse(parameters.GetValue<string>("year"));
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
