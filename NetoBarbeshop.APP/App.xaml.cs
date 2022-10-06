using NetoBarbeshop.APP.Models;


namespace NetoBarbeshop.APP;


public partial class App : Application
{
    public static UserLogin Usuario;
    public static string Token;
    public const string url_base = "http://alberthdasilva-001-site1.htempurl.com/api/v1.0/";
    public static bool updateview = false;
	public App()
	{
        InitializeComponent();
        MainPage = new AppShell();
    }
}
