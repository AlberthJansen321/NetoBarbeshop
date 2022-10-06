using NetoBarbeshop.APP.ViewModels;

namespace NetoBarbeshop.APP.Views;

public partial class Loading : ContentPage
{
	public Loading(LoadingPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();

	}
}