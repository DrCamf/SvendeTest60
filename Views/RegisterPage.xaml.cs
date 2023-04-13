using SvendeTest60.ViewModels;

namespace SvendeTest60.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}