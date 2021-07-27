using System;
using System.Collections.Generic;
using Series.Interfaces;

namespace Series.Classes
{
    public class SeriesRepository : IRepository<SeriesClass>
    {
        List<SeriesClass> seriesList = new List<SeriesClass>();

        public List<SeriesClass> List()
        {
            return seriesList;
        }

        public SeriesClass GetById(int id)
        {
            return seriesList[id];
        }

        public void Insert(SeriesClass value)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, SeriesClass value)
        {
            throw new NotImplementedException();
        }

        public int NextId()
        {
            return seriesList.Count;
        }
    }
}
