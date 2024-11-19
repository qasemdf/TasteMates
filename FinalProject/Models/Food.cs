using System;
using SQLite;

namespace FinalProject.Models;

[Table("foods")]
public class Food
{

    [PrimaryKey]
    public string Id { get; set; }

    [Unique]
    public string Name { get; set; }
    public string Attribute { get; set; }


    public override string ToString()
    {
        return String.Format("{0} {1}", Name, Attribute);
    }

}

