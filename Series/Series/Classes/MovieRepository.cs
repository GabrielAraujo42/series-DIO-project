using System;
using System.Collections.Generic;
using Series.Interfaces;

namespace Series.Classes
{
    public class MovieRepository : IRepository<Movie>
    {
        List<Movie> moviesList = new List<Movie>();

        public List<Movie> GetList()
        {
            return moviesList;
        }

        public Movie GetById(int id)
        {
            return moviesList[id];
        }

        public void Insert(Movie value)
        {
            moviesList.Add(value);
        }

        public void Remove(int id)
        {
            moviesList[id].Remove();
        }

        public void Update(int id, Movie value)
        {
            moviesList[id] = value;
        }

        public int NextId()
        {
            return moviesList.Count;
        }

        public bool CheckId(int id)
        {
            return 0 <= id && id < moviesList.Count;
        }
    }
}
