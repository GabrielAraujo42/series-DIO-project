using System;

namespace Series.Classes
{
    public class Movie : BaseEntity
    {
        Genre Genre { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        int Year { get; set; }
        // Property to control if Movie was removed from the Program's catalog
        bool WasRemoved { get; set; }

        public Movie(int id, Genre genre, string name, string desc, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = name;
            this.Description = desc;
            this.Year = year;
            this.WasRemoved = false;
        }

        public override string ToString()
        {
            string value = "";
            value += "Genre: " + Genre + Environment.NewLine;
            value += "Name: " + Title + Environment.NewLine;
            value += "Description: " + Description + Environment.NewLine;
            value += "Year: " + Year + Environment.NewLine;
            if (WasRemoved)
            {
                value += "This item was removed from the catalog." + Environment.NewLine;
            }
            return value;
        }

        public void Remove()
        {
            WasRemoved = true;
        }

        public int GetId()
        {
            return Id;
        }

        public string GetTitle()
        {
            return Title;
        }

        public int GetGenre()
        {
            return (int)Genre;
        }

        public bool GetWasRemoved()
        {
            return WasRemoved;
        }
    }
}
