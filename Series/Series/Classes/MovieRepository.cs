using System;
using System.Collections.Generic;
using Series.Interfaces;

namespace Series.Classes
{
    public class MovieRepository : IRepository<Movie>
    {
        List<Movie> seriesList = new List<Movie>();

        public List<Movie> GetList()
        {
            return seriesList;
        }

        public Movie GetById(int id)
        {
            return seriesList[id];
        }

        public void Insert(Movie value)
        {
            seriesList.Add(value);
        }

        public void Remove(int id)
        {
            seriesList[id].Remove();
        }

        public void Update(int id, Movie value)
        {
            seriesList[id] = value;
        }

        public int NextId()
        {
            return seriesList.Count;
        }
    }
}
