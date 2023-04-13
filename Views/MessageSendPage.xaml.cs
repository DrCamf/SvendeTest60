using SvendeTest60.ViewModels;

namespace SvendeTest60.Views;

public partial class MessageSendPage : ContentPage
{
	public MessageSendPage(MessageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}