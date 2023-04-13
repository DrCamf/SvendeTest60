using SvendeTest60.ViewModels;

namespace SvendeTest60.Views;

public partial class LoadingPage : ContentPage
{
	public LoadingPage(LoadingViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}