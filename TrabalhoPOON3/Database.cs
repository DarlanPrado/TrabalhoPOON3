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
            string diretorioDoApp = AppDomain.CurrentDomain.BaseDirectory;
            conect = new SQLiteConnection($"Data Source={diretorioDoApp}\\DataBase\\db_trabalho_poo_n3.db");
            conect.Open();
            return conect;
        }
    }
}
