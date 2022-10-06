using Microsoft.Maui.Controls;
using NetoBarbeshop.APP.Models;
using NetoBarbeshop.APP.Service.Interface;
using NetoBarbeshop.APP.ViewModels;
using System.Threading.Tasks;

namespace NetoBarbeshop.APP.Views;

[QueryProperty(nameof(UserLogin), "UserLogin")]
public partial class Home : ContentPage
{
    public HomePageViewModel _vm;
    public Home(HomePageViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
        this.BindingContext = vm;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        Task.Run(() =>
        {
            App.Current.Dispatcher.Dispatch(async () =>
            {
                if (collectionview.EmptyView == null)
                {
                    collectionview.EmptyView = Resources["BasicEmptyView"];
                }

                if (App.updateview == true)
                {
                    collectionview.ItemsSource = null;
                    collectionview.EmptyView = null;

                    await _vm.GetserviceDonesPendentes();

                    collectionview.ItemsSource = _vm.ServiceDones;
                    collectionview.EmptyView = Resources["BasicEmptyView"];

                    App.updateview = false;
                }

            });
        });
       
    }
}
