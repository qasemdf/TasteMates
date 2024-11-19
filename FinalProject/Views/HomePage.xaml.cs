using System.Diagnostics;
using FinalProject.Models;
using FinalProject.Views;
using Plugin.Maui.Audio;

namespace FinalProject;

public partial class HomePage : ContentPage
{

    RestService _restService;
    private readonly IAudioManager audioManager;
    private IAudioPlayer player;


    public HomePage()
	{
		InitializeComponent();
        DB.OpenConnection();
        _restService = new RestService();
    }


    public string GenerateRequestUri(string endpoint, string meal)
    {
        string requestUri = endpoint;
        requestUri += $"{meal}";
        return requestUri;

    }

    private async void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
        String query = GenerateRequestUri(Constants.ZipEndpoint, meal.Text);
        MealDBResponse resp = await _restService.GetZipData(query);
        if (resp != null && resp.Meals != null)
        {
            cv.ItemsSource = resp.Meals;
        }
        else
        {
            Debug.WriteLine("Error: Response or Meals is null");
        }
    }

    async void RecepiesPage_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new SavedRecipesPage());

    }

    async void AccountPage_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new AccountsPage(audioManager));

    }
    async void FoodsPage_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new FoodPage());

    }

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        try
        {
            String query = GenerateRequestUri(Constants.ZipEndpoint, meal.Text);
            MealDBResponse resp = await _restService.GetZipData(query);

            if (resp != null && resp.Meals != null && resp.Meals.Length > 0)
            {
                var mealNames = resp.Meals.Select(meal => meal.StrMeal).ToArray();
                var selectedMealName = await DisplayActionSheet("Select a Tutorial", "Cancel", null, mealNames);

                if (!string.IsNullOrEmpty(selectedMealName))
                {
                    var selectedMealItem = resp.Meals.FirstOrDefault(meal => meal.StrMeal == selectedMealName);
                    string youtubeLink = selectedMealItem?.StrYoutube;

                    if (!string.IsNullOrEmpty(youtubeLink))
                    {
                        await Browser.OpenAsync(youtubeLink, BrowserLaunchMode.SystemPreferred);
                    }
                    else
                    {
                        Debug.WriteLine("Error: YouTube link is null or empty");
                    }
                }
                else
                {
                    Debug.WriteLine("User canceled meal selection or no meal selected.");
                }
            }
            else
            {
                Debug.WriteLine("Error: Response, Meals, or Meals length is null");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex.Message}");
        }

    }

    internal static string GenerateRequestUri(string zipEndpoint, object text)
    {
        throw new NotImplementedException();
    }

    async void saveButton_Clicked(System.Object sender, System.EventArgs e)
    {
        try
        {
            String query = GenerateRequestUri(Constants.ZipEndpoint, meal.Text);
            MealDBResponse resp = await _restService.GetZipData(query);

            if (resp != null && resp.Meals != null && resp.Meals.Length > 0)
            {
                var mealNames = resp.Meals.Select(meal => meal.StrMeal).ToArray();

                var selectedMealName = await DisplayActionSheet("Select a Meal", "Cancel", null, mealNames);

                if (!string.IsNullOrEmpty(selectedMealName))
                {
                    var selectedMealItem = resp.Meals.FirstOrDefault(meal => meal.StrMeal == selectedMealName);

                    var mealModel = new Recipes
                    {
                        StrMeal = selectedMealItem.StrMeal,
                        StrInstructions = selectedMealItem.StrInstructions,
                        IngredientsString = selectedMealItem.IngredientsString
                    };
                    DB.conn.Insert(mealModel);

                    Debug.WriteLine("Data saved to the database.");
                }
                else
                {
                    Debug.WriteLine("User canceled meal selection or no meal selected.");
                }
            }
            else
            {
                Debug.WriteLine("Error: Response, Meals, or Meals length is null");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex.Message}");
        }
    }
}
