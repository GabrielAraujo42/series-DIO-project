using System.Collections.Generic;
using Series.Interfaces;

namespace Series.Classes
{
    // Class to control the Program's catalog of movies
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

        // Function to check if id is in the list's range
        public bool CheckId(int id)
        {
            return 0 <= id && id < moviesList.Count;
        }
    }
}
