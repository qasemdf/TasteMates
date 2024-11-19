using Plugin.Maui.Audio;


namespace FinalProject;

public partial class loginPage : ContentPage
{
    public readonly IAudioManager audioManager;
    private IAudioPlayer player;




    public loginPage(IAudioManager audioManager)
	{
		InitializeComponent();
        this.audioManager = audioManager;

    }



    async void logIn_Clicked(System.Object sender, System.EventArgs e)
    {
        string enteredUsername = username.Text;
        string enteredPassword = pwd.Text;


        bool isValid = AuthenticationService.Instance.Login(enteredUsername, enteredPassword);

        if (isValid)
        {
            if(player == null)
                player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("bellding.wav"));
            player.Volume = .3;
            player.Play();
            await Navigation.PushAsync(new HomePage());
        }
        else
        {
            await DisplayAlert("Alert", "username or password incorrect", "Ok");
        }

    }


    async void noAccount_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();

    }
}
