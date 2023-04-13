using SvendeTest60.ViewModels;

namespace SvendeTest60.Views;

public partial class MessagePage : ContentPage
{
	public MessagePage(MessageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}