using SvendeTest60.ViewModels;

namespace SvendeTest60.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}