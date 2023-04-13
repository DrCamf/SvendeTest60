using SvendeTest60.Models;
using SvendeTest60.Views;

namespace SvendeTest60;

public partial class AppShell : Shell
{
	
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
    }
}
