using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace TrabalhoPOON3
{
    public class Database
    {
        private static SQLiteConnection conect;

        protected static SQLiteConnection conn()
        {
            conect = new SQLiteConnection("Data Source= C:\\Users\\vinicius.zanatta\\source\\repos\\TrabalhoPOON3\\DataBase");
            conect.Open();
            return conect;
        }
    }
}
