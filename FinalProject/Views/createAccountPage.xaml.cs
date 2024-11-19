using FinalProject.Models;
namespace FinalProject;

public partial class createAccountPage : ContentPage
{
	public createAccountPage()
	{
		InitializeComponent();
	}

    async void createdAccount_Clicked(System.Object sender, System.EventArgs e)
    {
        if (pwd.Text != pwdRepeat.Text)
        {
            await DisplayAlert("Alert", "Passwords do not match, try again.", "Ok");
            pwd.Text = "";
            pwdRepeat.Text = "";
        }
        else
        {
            DB.OpenConnection();
            Users newUser = new Users
            {
                username = username.Text,
                password = pwd.Text
            };
            DB.conn.Insert(newUser);
            username.Text = "";
            pwd.Text = "";
            pwdRepeat.Text = "";
            await DisplayAlert("Alert", "Account created", "Return to login");
            await Navigation.PopAsync();
        }
    }


    async void loginAgain_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
