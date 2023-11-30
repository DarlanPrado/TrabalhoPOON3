using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOON3.Model
{
    internal class AcordoContratoModel : Database
    {
        public static void gerarBoleto(string idContrato, int numeroParcela, string status, DateTime dataVencimento, double valor)
        {
            try
            {
                using (var cmd = conn().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO boleto (NUMERO_PARCELA, STATUS, DATA_EMISSAO, DATA_VENCIMENTO, VALOR) VALUES (@numeroParcela, @status, , @dataEmissao, @dataVencimento, @valor)";

                    cmd.Parameters.AddWithValue("@numeroParcela", numeroParcela);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@dataVencimento", dataVencimento);
                    cmd.Parameters.AddWithValue("@dataEmissao", DateTime.Now);
                    cmd.Parameters.AddWithValue("@dataVencimento", dataVencimento);
                    cmd.Parameters.AddWithValue("@valor", valor);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
