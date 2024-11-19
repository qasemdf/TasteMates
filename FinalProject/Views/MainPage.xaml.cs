using Plugin.Maui.Audio;

namespace FinalProject;


public partial class MainPage : ContentPage
{
    private readonly IAudioManager audioManager;
    private IAudioPlayer player;

    public MainPage(IAudioManager audioManager)
	{
		InitializeComponent();
        this.audioManager = audioManager;

    }



    async void createAccount_Clicked(System.Object sender, System.EventArgs e)
    {

        player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("welcome.wav"));
        player.Volume = .7;
        player.Play();
        await Navigation.PushAsync(new createAccountPage());

    }

    async void login_Clicked(System.Object sender, System.EventArgs e)
    {

        player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("letsgo.wav"));       
        player.Volume = .3;
        player.Play();
        await Navigation.PushAsync(new loginPage(audioManager));
    }

}


