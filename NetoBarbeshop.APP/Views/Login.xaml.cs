using NetoBarbeshop.APP.ViewModels;

namespace NetoBarbeshop.APP.Views;

public partial class Login : ContentPage
{
    public Login(LoginPageViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}