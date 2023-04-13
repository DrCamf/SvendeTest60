using SvendeTest60.ViewModels;

namespace SvendeTest60.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}