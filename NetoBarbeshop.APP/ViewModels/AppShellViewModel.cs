using CommunityToolkit.Mvvm.Input;
using NetoBarbeshop.APP.Service.Interface;
using NetoBarbeshop.APP.Views;


namespace NetoBarbeshop.APP.ViewModels
{
    public partial class AppShellViewModel : BaseViewModel
    {
        //private readonly IHomeService _homeService = DependencyService.Get<IHomeService>();
        //private readonly ILoginService _loginService = DependencyService.Get<ILoginService>();
        //private HomePageViewModel viewModel = DependencyService.Get<HomePageViewModel>();
        public AppShellViewModel()
        {
           
        }
        [RelayCommand]
        async void SignOut()
        {
            if (Preferences.ContainsKey(nameof(App.Usuario)))
            {
                Preferences.Remove(nameof(App.Usuario));                
            }
           // await _navigationService.GoBack();
            await Shell.Current.GoToAsync($"//{nameof(Login)}");        
        }
    }
}
