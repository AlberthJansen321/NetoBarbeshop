namespace NetoBarbeshop.APP.Controls;

public partial class FlyoutHeaderControl : StackLayout
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();

		if(App.Usuario != null)
		{
			LabelEmail.Text = App.Usuario.Email;
		}
	}
}