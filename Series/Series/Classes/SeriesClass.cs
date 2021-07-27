using System;

namespace Series.Classes
{
    public class SeriesClass : BaseEntity
    {
        Genre Genre { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        int Year { get; set; }

        public SeriesClass(int id, Genre genre, string name, string desc, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = name;
            this.Description = desc;
            this.Year = year;
        }

        public override string ToString()
        {
            string value = "";
            value += "Genre: " + Genre + Environment.NewLine;
            value += "Name: " + Title + Environment.NewLine;
            value += "Description: " + Description + Environment.NewLine;
            value += "Year: " + Year + Environment.NewLine;
            return value;
        }

        public string GetTitle()
        {
            return Title;
        }

        public int GetId()
        {
            return Id;
        }
    }
}
