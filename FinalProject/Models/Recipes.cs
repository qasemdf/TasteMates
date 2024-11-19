using System;
using System.ComponentModel;
using SQLite;

namespace FinalProject.Models;

public class Recipes : INotifyPropertyChanged
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    private string _strMeal;
    public string StrMeal
    {
        get { return _strMeal; }
        set
        {
            if (_strMeal != value)
            {
                _strMeal = value;
                OnPropertyChanged(nameof(StrMeal));
            }
        }
    }

    private string _strInstructions;
    public string StrInstructions
    {
        get { return _strInstructions; }
        set
        {
            if (_strInstructions != value)
            {
                _strInstructions = value;
                OnPropertyChanged(nameof(StrInstructions));
            }
        }
    }

    private string _ingredientsString;
    public string IngredientsString
    {
        get { return _ingredientsString; }
        set
        {
            if (_ingredientsString != value)
            {
                _ingredientsString = value;
                OnPropertyChanged(nameof(IngredientsString));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public override string ToString()
    {
        return $"{StrMeal} {StrInstructions} {IngredientsString}";
    }
}


