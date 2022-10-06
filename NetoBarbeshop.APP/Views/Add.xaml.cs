using NetoBarbeshop.APP.ViewModels;

namespace NetoBarbeshop.APP.Views;

public partial class Add : ContentPage
{
	public Add(HomePageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}