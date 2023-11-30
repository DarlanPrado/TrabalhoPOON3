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
        public static void AdicionarImovel(string idCliente,string TipoImovel, double valor, bool disponivel)
        {
            int idImovel = 0;

            try
            {
                using (var cmd = conn().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO cliente (TIPO_IMOVEL, VALOR, BL_DISPONIVEL) VALUES (@tipoImovel, @valor, @disponivel);" +
                                      "SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("@tipoImovel", TipoImovel);
                    cmd.Parameters.AddWithValue("@valor", valor);
                    cmd.Parameters.AddWithValue("@disponivel", disponivel ? 1 : 0);

                    idImovel = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                using (var cmd = conn().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO cliente_imovel (ID_CLIENTE, ID_IMOVEL, BL_PROPIETARIO_ATUAL) VALUES (@idCliente, @idImovel, @propietarioAtual);";

                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    cmd.Parameters.AddWithValue("@idImovel", idImovel);
                    cmd.Parameters.AddWithValue("@propietarioAtual", 1);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void AdicionarImovelAoCliente(string idImovel, string idCliente)
        {
            try
            {
                using (var cmd = conn().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO cliente_imovel (ID_CLIENTE, ID_IMOVEL, BL_PROPIETARIO_ATUAL) VALUES (@idCliente, @idImovel, @propietarioAtual);";

                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    cmd.Parameters.AddWithValue("@idImovel", idImovel);
                    cmd.Parameters.AddWithValue("@propietarioAtual", 1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EditarImovel(string idImovel,string TipoImovel, double valor, bool disponivel)
        {
            try
            {
                using (var cmd = conn().CreateCommand())
                {
                    cmd.CommandText = "UPDATE imovel SET TIPO_IMOVEL = @tipoImovel, VALOR = @valor, BL_DISPONIVEL = @disponivel WHERE ID_IMOVEL = @idImovel";

                    cmd.Parameters.AddWithValue("@idImovel", idImovel);
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

        public static DataTable ListarImoveisDoCiente(string idCLiente)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = conn().CreateCommand())
                {
                    cmd.CommandText = "SELECT imovel.* FROM imovel"+
                        "LEFT JOIN cliente_imovel ON cliente_imovel.ID_IMOVEL = imovel.ID_IMOVEL" +
                        "WHERE cliente_imovel.ID_CLIENTE = @idCLiente";

                    cmd.Parameters.AddWithValue("@idCLiente", idCLiente);

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

        public static DataTable BuscarImovelPorID(int idImovel)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {

                using (var cmd = conn().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM imovel WHERE imovel.ID_IMOVEL = @idImovel";
                    cmd.Parameters.AddWithValue("@idImovel", idImovel);

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
