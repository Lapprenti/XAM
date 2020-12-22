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
using System.Windows.Input;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using Xamarin.Forms;
using XAM.Contracts;

namespace XAM.ViewModels
{
    public class SeasonsViewModel : ViewModelBase
    {
        private IBLL _BLL { get; set; }

        public INavigationService _navigationService { get; set; }

        public ICommand GoToDriverPageCommande { get; set; }

        private IDeviceService _deviceService { get; set; }

        private string _device;
        public string Device
        {
            get { return _device; }
            set { SetProperty(ref _device, value); }
        }

        public DelegateCommand GoToDrivers { get; private set; }
        
        public Year SelectedYear { get; set; }

        private List<Year> _seasons;
        public List<Year> Seasons
        {
            get { return _seasons; }
            set { SetProperty(ref _seasons, value); }
        }

        public SeasonsViewModel(INavigationService navigationService, IBLL bLL, IDeviceService deviceService)
            : base(navigationService)
        {
            Title = "Choose a season";
            _deviceService = deviceService;
            _navigationService = navigationService;
            //GoToDrivers = new DelegateCommand(GoToDriversMethod);
            GoToDriverPageCommande = new AsyncCommand(GoToDriversMethod, o => CanExecute(o), async exception => { 
                
                // Handle exceptions if no season is selected
                Console.WriteLine(exception);
                
                // Alert the user
                await Application.Current.MainPage.DisplayAlert(
                    "Saison invalide", 
                    "Vous devez choisir une saison !", 
                    "OK");
            });
            _BLL = bLL;
            this.GetAllSeasons();
            this.GetPlatform();
        }

        void GetPlatform()
        {
            Device = $"Bienvenue cher utilisateur {_deviceService.Identify()} !";
        }

        async void GetAllSeasons()
        {
            Seasons = await _BLL.GetAllSeasons();
        }

        async Task GoToDriversMethod()
        {
            //MessagingCenter.Send<SeasonsViewModel, DriversViewModel>(this, "IsDark", IsDark); // Essai messaging center
            //SelectedYear = 2020;
            var navigationParams = new NavigationParameters
            {
                { "year", SelectedYear.Season }
            };
            try
            {
                await _navigationService.NavigateAsync("DriversPage", navigationParams);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        bool CanExecute(object o)
        {
            return true;
        }
    }
}
