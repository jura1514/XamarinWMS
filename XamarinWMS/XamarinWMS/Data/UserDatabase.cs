﻿using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.Data
{
    public class UserDatabase
    {
        private SQLiteConnection _connection;

        public UserDatabase(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<UserData>();
        }

        public List<UserData> GetAllUsers()
        {
            return _connection.Query<UserData>("Select * From [UserData]");
        }
        public UserData GetUserById(string aSelectedUser)
        {
            return _connection.Find<UserData>(aSelectedUser);
        }
        public int SaveUser(UserData aUser)
        {
            return _connection.Insert(aUser);
        }
        public int DeleteUser(UserData aUser)
        {
            return _connection.Delete(aUser);
        }
        public int EditUser(UserData aUser)
        {
            return _connection.Update(aUser);
        }
    }
}
