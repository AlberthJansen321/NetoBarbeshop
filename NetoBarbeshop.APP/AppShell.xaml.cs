using NetoBarbeshop.APP.ViewModels;
using NetoBarbeshop.APP.Views;

namespace NetoBarbeshop.APP;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        this.BindingContext = new AppShellViewModel();
        
        Routing.RegisterRoute(nameof(Home), (typeof(Home)));
        Routing.RegisterRoute(nameof(Login), typeof(Login));
    }
}
