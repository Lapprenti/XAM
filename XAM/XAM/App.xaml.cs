using Business;
using Business.contracts;
using Prism;
using Prism.Ioc;
using XAM.Contracts;
using XAM.Services;
using XAM.ViewModels;
using XAM.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace XAM
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/SeasonsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterSingleton<IDeviceService, DeviceService>();
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.Register<IBLL, BLL>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SeasonsPage, SeasonsViewModel>();
            containerRegistry.RegisterForNavigation<DriversPage, DriversViewModel>();
        }
    }
}
