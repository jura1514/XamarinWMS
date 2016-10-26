using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinWMS
{
    public class RandomThoughtDatabase
    {
        private SQLiteConnection _connection;

        public RandomThoughtDatabase()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<RandomData>();
        }

        public IEnumerable<RandomData> GetThoughts()
        {
            return (from t in _connection.Table<RandomData>()
                    select t).ToList();
        }

        public RandomData GetThought(int id)
        {
            return _connection.Table<RandomData>().FirstOrDefault(t => t.ID == id);
        }

        public void DeleteThought(int id)
        {
            _connection.Delete<RandomData>(id);
        }

        public void AddThought(string thought)
        {
            var newThought = new RandomData
            {
                Thought = thought,
                CreatedOn = DateTime.Now
            };

            _connection.Insert(newThought);
        }
    }
}
