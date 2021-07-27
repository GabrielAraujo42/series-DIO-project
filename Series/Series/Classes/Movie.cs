using System;

namespace Series.Classes
{
    public class Movie : BaseEntity
    {
        protected Genre Genre { get; set; }
        protected string Title { get; set; }
        protected string Description { get; set; }
        protected int Year { get; set; }
        protected bool WasRemoved { get; set; }

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

        public string GetTitle()
        {
            return Title;
        }

        public int GetId()
        {
            return Id;
        }

        public bool GetWasRemoved()
        {
            return WasRemoved;
        }
    }
}
