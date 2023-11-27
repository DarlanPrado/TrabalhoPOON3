using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOON3.Model
{
    public class LocatarioModel : Database
    {
        public static void AdicionarLocatario(string cpf, string nome, string telefone)
        {
            try
            {
                using (var cmd = conn().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO cliente (CPF, NOME, TELEFONE) VALUES (@cpf, @nome, @telefone)";

                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@telefone", telefone);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EditarLocatario(int id, string cpf, string nome, string telefone)
        {
            try
            {
                using (var cmd = conn().CreateCommand())
                {
                    cmd.CommandText = "UPDATE cliente SET NOME = @nome, TELEFONE = @telefone, CPF = @cpf WHERE ID_CLIENTE = @id";

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@telefone", telefone);
                    cmd.Parameters.AddWithValue("@cpf", cpf);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ListarLocatarios()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = conn().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM cliente";

                    da = new SQLiteDataAdapter(cmd.CommandText, conn());
                    da.Fill(dt);
                    return dt;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable BuscarLocatarioPorID(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {

                using (var cmd = conn().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM cliente WHERE cliente.ID_CLIENTE = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    da = new SQLiteDataAdapter(cmd.CommandText, conn());
                    da.Fill(dt);
                    return dt;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable BuscarLocatarioPorCPF(string cpf)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {

                using (var cmd = conn().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM cliente WHERE cliente.CPF =@cpf";
                    cmd.Parameters.AddWithValue("@cpf", cpf);

                    da = new SQLiteDataAdapter(cmd.CommandText, conn());
                    da.Fill(dt);
                    return dt;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
