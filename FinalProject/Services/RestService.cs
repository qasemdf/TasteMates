using System;
using System.Diagnostics;
using Newtonsoft.Json;
using FinalProject.Models;


namespace FinalProject;

public class MealDBResponse
{
    public MealsItem[] Meals { get; set; }
}

public class MealsItem
{
    public string StrMeal { get; set; }
    public string StrMealThumb { get; set; }
    public string StrYoutube { get; set; }
    public string StrInstructions { get; set; }
    public string StrIngredient1 { get; set; }
    public string StrIngredient2 { get; set; }
    public string StrIngredient3 { get; set; }
    public string StrIngredient4 { get; set; }
    public string StrIngredient5 { get; set; }
    public string StrIngredient6 { get; set; }
    public string StrIngredient7 { get; set; }
    public string StrIngredient8 { get; set; }
    public string StrIngredient9 { get; set; }
    public string StrIngredient10 { get; set; }
    public string StrIngredient11 { get; set; }
    public string StrIngredient12 { get; set; }
    public string StrIngredient13 { get; set; }
    public string StrIngredient14 { get; set; }
    public string StrIngredient15 { get; set; }
    public string StrIngredient16 { get; set; }
    public string StrIngredient17 { get; set; }
    public string StrIngredient18 { get; set; }
    public string StrIngredient19 { get; set; }
    public string StrIngredient20 { get; set; }
    public string StrMeasure1 { get; set; }
    public string StrMeasure2 { get; set; }
    public string StrMeasure3 { get; set; }
    public string StrMeasure4 { get; set; }
    public string StrMeasure5 { get; set; }
    public string StrMeasure6 { get; set; }
    public string StrMeasure7 { get; set; }
    public string StrMeasure8 { get; set; }
    public string StrMeasure9 { get; set; }
    public string StrMeasure10 { get; set; }
    public string StrMeasure11 { get; set; }
    public string StrMeasure12 { get; set; }
    public string StrMeasure13 { get; set; }
    public string StrMeasure14 { get; set; }
    public string StrMeasure15 { get; set; }
    public string StrMeasure16 { get; set; }
    public string StrMeasure17 { get; set; }
    public string StrMeasure18 { get; set; }
    public string StrMeasure19 { get; set; }
    public string StrMeasure20 { get; set; }

    public List<string> StrIngredientsList
    {
        get
        {
            List<string> ingredientsList = new List<string>();

            for (int i = 1; i <= 20; i++)
            {
                string ingredient = (string)GetType().GetProperty($"StrIngredient{i}").GetValue(this);
                string measure = (string)GetType().GetProperty($"StrMeasure{i}").GetValue(this);

                if (!string.IsNullOrEmpty(ingredient))
                {
                    string ingredientWithMeasure = $"{ingredient}: {measure}".Trim();
                    ingredientsList.Add(ingredientWithMeasure);
                }

            }

            return ingredientsList;
        }
    }

    public string IngredientsString
    {
        get
        {
            return string.Join(", ", StrIngredientsList);
        }
    }



    public override string ToString()
    {

        return $"{StrMeal} {StrInstructions} {IngredientsString}";
    }
}

public class RestService
{
    HttpClient _client;
    DatabaseHelper _databaseHelper; // Add this line


    public RestService()
    {
        _client = new HttpClient();
        _databaseHelper = new DatabaseHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Meals.db3")); // Add this line

    }

    MealDBResponse mr = null;

    public async Task<MealDBResponse> GetZipData(string query)
    {
        try
        {
            var response = await _client.GetAsync(query);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                mr = JsonConvert.DeserializeObject<MealDBResponse>(content);

            }

            if (mr != null && mr.Meals != null && mr.Meals.Length > 0)
            {
                var firstMeal = mr.Meals.First();
                var mealModel = new Recipes
                {
                    StrMeal = firstMeal.StrMeal,
                    StrInstructions = firstMeal.StrInstructions,
                    IngredientsString = firstMeal.IngredientsString
                };

                await _databaseHelper.SaveMealAsync(mealModel);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"\t\tERROR! {ex.Message}");
        }

        return mr;
    }
}










