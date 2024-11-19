using System;
using System.Reflection;
using SQLite;
using FinalProject.Models;


namespace FinalProject;

public class DB
{
    private static string DBName = "log.db";
    public static SQLiteConnection conn;

    public static void OpenConnection()
    {
        string libFolder = FileSystem.AppDataDirectory;
        string fname = System.IO.Path.Combine(libFolder, DBName);
        conn = new SQLiteConnection(fname);
        conn.CreateTable<Users>();
        conn.CreateTable<Food>();
        conn.CreateTable<Recipes>();


    }

    //[Table("user")]
    //public class Users
    //{
    //    [PrimaryKey, AutoIncrement, Column("_id")]
    //    public int Id { get; set; }

    //    [Unique]
    //    public string username { get; set; }
    //    public string password { get; set; }

    //    public override string ToString()
    //    {
    //        return string.Format("{0} {1}", username, password);
    //    }
    //}

    //[Table("foods")]
    //public class Food
    //{

    //    [PrimaryKey]
    //    public string Id { get; set; }

    //    [Unique]
    //    public string Name { get; set; }
    //    public string Attribute { get; set; }


    //    public override string ToString()
    //    {
    //        return String.Format("{0} {1}", Name, Attribute);
    //    }

    //}

    public static void PopulateFoodTable()
    {
        // Make sure the database connection is open
        if (conn == null || conn.Table<Food>().Count() == 0)
        {
            OpenConnection();
        }

        // Create instances of the Food class and insert them into the table
        var food1 = new Food { Id = "1", Name = "Water", Attribute = "Liquid" };
        var food2 = new Food { Id = "2", Name = "Yeast", Attribute = "Baking" };
        var food3 = new Food { Id = "3", Name = "Sugar", Attribute = "Seasoning" };
        var food4 = new Food { Id = "4", Name = "Plain Flower", Attribute = "Baking" };
        var food5 = new Food { Id = "5", Name = "Salt", Attribute = "Seasoning" };
        var food6 = new Food { Id = "6", Name = "Olive Oil", Attribute = "Baking" };


        // Insert records into the Food table
        conn.Insert(food1);
        conn.Insert(food2);
        conn.Insert(food3);
        conn.Insert(food4);
        conn.Insert(food5);
        conn.Insert(food6);

    }

    [Table("linkMe")]
    public class LinkMe
    {
        [PrimaryKey]
        public string contact { get; set; }
    }
}

