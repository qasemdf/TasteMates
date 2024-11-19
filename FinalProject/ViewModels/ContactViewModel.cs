using System;
using System.Windows.Input;

namespace FinalProject.ViewModels;

    public class ContactViewModel : BaseViewModel
    {

    public ContactViewModel()
	{
        OpenWebCommand = new Command(() => OpenMaui());
    }
    public async void OpenMaui()
    {
        await Browser.Default.OpenAsync("https://www.themealdb.com/", BrowserLaunchMode.SystemPreferred);
    }


    public ICommand OpenWebCommand { get; }

}


