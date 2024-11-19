using System;
using SQLite;

namespace FinalProject.Models;

[Table("user")]
public class Users
{
    [PrimaryKey, AutoIncrement, Column("_id")]
    public int Id { get; set; }

    [Unique]
    public string username { get; set; }
    public string password { get; set; }

    public override string ToString()
    {
        return string.Format("{0} {1}", username, password);
    }
}

