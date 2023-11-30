using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOON3.Model
{
    internal class ImovelModel : Database
    {
        public static void AdicionarImovel(string TipoImovel, double valor, bool disponivel)
        {
            try
            {
                using (var cmd = conn().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO cliente (TIPO_IMOVEL, VALOR, BL_DISPONIVEL) VALUES (@tipoImovel, @nome, @disponivel)";

                    cmd.Parameters.AddWithValue("@tipoImovel", TipoImovel);
                    cmd.Parameters.AddWithValue("@valor", valor);
                    cmd.Parameters.AddWithValue("@disponivel", disponivel ? 1 : 0);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EditarImovel(string TipoImovel, double valor, bool disponivel)
        {
            try
            {
                using (var cmd = conn().CreateCommand())
                {
                    cmd.CommandText = "UPDATE cliente SET NOME = @nome, TELEFONE = @telefone, CPF = @cpf WHERE ID_CLIENTE = @id";

                    cmd.Parameters.AddWithValue("@tipoImovel", TipoImovel);
                    cmd.Parameters.AddWithValue("@valor", valor);
                    cmd.Parameters.AddWithValue("@disponivel", disponivel ? 1 : 0);

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
