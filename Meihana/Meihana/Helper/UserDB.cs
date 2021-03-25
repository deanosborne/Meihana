using Meihana.Models;
using Meihana.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Meihana.Helper
{
    public class UserDB
    {
        private SQLiteConnection conn;

    public UserDB()
    {
        conn = DependencyService.Get<ISQLite>().GetConnection();
        conn.CreateTable<User>();
    }

    public IEnumerable<User> GetUsers()
    {
        return (from u in conn.Table<User>()
                select u).ToList();
    }

    public User GetSpecificUser(int id)
    {
        return conn.Table<User>().FirstOrDefault(t => t.ID == id);
    }

    public void DeleteUser(int id)
    {
        conn.Delete<User>(id);
    }

    public string AddUser(User user)
    {
        var data = conn.Table<User>();
        var d1 = data.Where(x => x.Email == user.Email).FirstOrDefault();
        if (d1 == null)
        {
            conn.Insert(user);
            return "Sucessfully Added";
        }
        else
            return "Already Mail id Exist";
    }

    public bool updateUserValidation(string userid)
    {
        var data = conn.Table<User>();
        var d1 = (from values in data
                  where values.Email == userid
                  select values).Single();
        if (d1 != null)
        {
            return true;
        }
        else
            return false;
    }

    public bool updateUser(string username, string pwd)
    {
        var data = conn.Table<User>();
        var d1 = (from values in data
                  where values.Email == username
                  select values).Single();
        if (true)
        {
            d1.Password = pwd;
            conn.Update(d1);
            return true;
        }
        else
            return false;
    }

    public bool LoginValidate(string userName1, string pwd1)
    {
        var data = conn.Table<User>();
        var d1 = data.Where(x => x.Email == userName1 && x.Password == pwd1).FirstOrDefault();
        if (d1 != null)
        {
            return true;
        }
        else
            return false;
    }
}
 }
