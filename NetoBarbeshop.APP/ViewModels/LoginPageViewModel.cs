using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using NetoBarbeshop.APP.Views;
using NetoBarbeshop.APP.Controls;
using NetoBarbeshop.APP.Models;
using Newtonsoft.Json;
using NetoBarbeshop.APP.Service;
using NetoBarbeshop.APP.Service.Interface;


namespace NetoBarbeshop.APP.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public string senha;

        private ILoginService _loginService;
        IConnectivity _connectivity;

        public LoginPageViewModel(ILoginService loginService, IConnectivity connectivity)
        {
            _loginService = loginService;
            _connectivity = connectivity;
        }

        #region Commands
        [RelayCommand]
        public async void Login()
        {
            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Email))
            {
                if (_connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Atenção", "Verifique sua conexão com a internet", "Ok");
                    return;
                }

                IsBusy = true;

                var loginuser = new UserLogin()
                {
                    Email = this.Email,
                    Senha = this.Senha
                };

                var result = await _loginService.Login(loginuser);

                if (result != null)
                {
                    IsBusy = false;

                    loginuser.Senha = string.Empty;

                    if (Preferences.ContainsKey(nameof(App.Usuario)))
                    {
                        Preferences.Remove(nameof(App.Usuario));
                    }

                    App.Token = result.Token;
                    await SecureStorage.SetAsync(nameof(App.Token), result.Token);

                    string userloginstring = JsonConvert.SerializeObject(loginuser);
                    Preferences.Set(nameof(App.Usuario), userloginstring);
                    App.Usuario = loginuser;
                    Shell.Current.FlyoutHeader = new FlyoutHeaderControl();
                    App.updateview = true;
                    await Shell.Current.GoToAsync($"//{nameof(Home)}", true);

                }
                else
                {
                    IsBusy = false;
                    await Shell.Current.DisplayAlert("Atenção", "Verifique seu usuario e sua senha", "Ok");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Atenção", "Preencha todos os campos corretamente", "Ok");
            }
        }
        #endregion
    }
}
