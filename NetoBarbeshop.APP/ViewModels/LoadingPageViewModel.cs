using NetoBarbeshop.APP.Controls;
using NetoBarbeshop.APP.Models;
using NetoBarbeshop.APP.Service.Interface;
using NetoBarbeshop.APP.Views;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace NetoBarbeshop.APP.ViewModels
{
    public partial  class LoadingPageViewModel: BaseViewModel
    { 
        public LoadingPageViewModel()
        {
            checkuserlogin();
        }
        public async void checkuserlogin()
        {
            IsBusy = true;    
            var verificar = Preferences.Get(nameof(App.Usuario),"");

            if (string.IsNullOrWhiteSpace(verificar))
            {
                IsBusy = false;

                await Shell.Current.GoToAsync($"//{nameof(Login)}");
            }
            else
            {
                IsBusy = false;

                var token = await SecureStorage.GetAsync(nameof(App.Token));
                var userlogado = JsonConvert.DeserializeObject<UserLogin>(verificar);

                var handler = new JwtSecurityTokenHandler();
                var jsontoken = handler.ReadToken(token) as JwtSecurityToken;

                if (jsontoken.ValidTo < DateTime.UtcNow)
                {
                    await Shell.Current.DisplayAlert("Atenção", "Seção expirada, faça login pra continuar", "Ok");
                    await Shell.Current.GoToAsync($"//{nameof(Login)}");
                }
                else
                {
                    App.Token = token;
                    App.Usuario = userlogado;
                    Shell.Current.FlyoutHeader = new FlyoutHeaderControl();
  
                    await Shell.Current.GoToAsync($"//{nameof(Home)}");
                }
            }
        }
    }
}
