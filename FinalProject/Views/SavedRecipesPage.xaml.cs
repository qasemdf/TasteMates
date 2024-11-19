using FinalProject.Models;
namespace FinalProject.Views;


public partial class SavedRecipesPage : ContentPage
{


    public SavedRecipesPage()
    {
        InitializeComponent();
        DB.OpenConnection();
        update();
    }


    async void Recepies_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var selectedRecipe = (Recipes)e.SelectedItem;

        Recepies.SelectedItem = null;

        var result = await DisplayAlert(selectedRecipe.StrMeal,
            $"Instructions:\n{selectedRecipe.StrInstructions}\n\nIngredients:\n{selectedRecipe.IngredientsString}",
            "OK", "Delete");

        if (!result)
        {

            DB.conn.Delete(selectedRecipe);
            update();
        }
    }

    public void update()
    {
        Recepies.ItemsSource = DB.conn.Table<Recipes>().ToList();
    }
}
