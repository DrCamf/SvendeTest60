namespace SvendeTest60.Controller;

public partial class FlyOutHeader : ContentPage
{
	public FlyOutHeader()
	{
		InitializeComponent();
        SetValues();
    }

    private void SetValues()
    {
        if (App.UserInfo != null)
        {
            lblUserName.Text = App.UserInfo.Email;
            lblRole.Text = App.UserInfo.Role;
        }
    }
}