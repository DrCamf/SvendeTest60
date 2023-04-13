using SvendeTest60.Models;

namespace SvendeTest60;

public partial class App : Application
{
    public static IList<UserModel> UserBasicInfo;
    public static UserModel UserInfo;
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
