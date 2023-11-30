using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOON3.Model
{
    internal class AcordoContratoModel : Database
    {
        // Define o caminho do arquivo de texto que armazena os boletos
        private static string boletoFilePath = "C:\\Users\\vinicius.zanatta\\Desktop\\TrabalhoPOON3\\TrabalhoPOON3\\Txt\\boleto.txt";

        public static void gerarBoleto(string idContrato, int numeroParcela, string status, DateTime dataVencimento, double valor)
        {
            try
            {
                // Cria uma string com os dados do boleto separados por vírgula
                string boleto = $"{idContrato},{numeroParcela},{status},{DateTime.Now},{dataVencimento},{valor}";

                // Usa o método AppendAllText para adicionar o boleto ao final do arquivo de texto
                File.AppendAllText(boletoFilePath, boleto + Environment.NewLine);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
