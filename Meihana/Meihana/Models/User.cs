using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Meihana.Models
{
    public class User
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User()
        {

        }
    }
}
