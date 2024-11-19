using Plugin.Maui.Audio;

namespace FinalProject;

public partial class AccountsPage : ContentPage
{
    private readonly IAudioManager audioManager;
    private IAudioPlayer player;

    public AccountsPage(IAudioManager audioManager)
	{
		InitializeComponent();
        this.audioManager = audioManager;
        if (AuthenticationService.Instance.CurrentUser == null)
        {
            Navigation.PopToRootAsync();
        }

        var currentUser = AuthenticationService.Instance.CurrentUser.username;

        username.Text += currentUser;
    }

    async void LogOut_Clicked(System.Object sender, System.EventArgs e)
    {
        AuthenticationService.Instance.Logout();
        try
        {
            var currentUser = AuthenticationService.Instance.CurrentUser;
            var stackCount = Navigation.NavigationStack.Count;
            await DisplayAlert("Signed Out", "you have signed out", "Ok");
            await Navigation.PopToRootAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alert", "Somthings up -_-" + ex, "Ok");
        }
    }
}
