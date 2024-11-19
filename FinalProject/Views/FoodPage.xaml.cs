namespace FinalProject;
using FinalProject.Models;


public partial class FoodPage : ContentPage
{
	public FoodPage()
	{

		InitializeComponent();
        DB.OpenConnection();
        food1.ItemsSource = DB.conn.Table<Food>().ToList();
    }

}
