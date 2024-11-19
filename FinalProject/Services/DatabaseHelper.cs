// DatabaseHelper.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using FinalProject.Models;

public class DatabaseHelper
{
    readonly SQLiteAsyncConnection _database;

    public DatabaseHelper(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Recipes>().Wait();
    }

    public async Task<List<Recipes>> GetMealsAsync()
    {
        return await _database.Table<Recipes>().ToListAsync();
    }

    public async Task<int> SaveMealAsync(Recipes meal)
    {
        if (meal.Id != 0)
        {
            return await _database.UpdateAsync(meal);
        }
        else
        {
            return await _database.InsertAsync(meal);
        }
    }
    public async Task<int> DeleteMealAsync(int mealId)
    {
        return await _database.DeleteAsync<Recipes>(mealId);
    }
}
