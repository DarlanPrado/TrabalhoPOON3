using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOON3.Model
{
    public class ContratoModel
    {
        // Define o caminho do arquivo de texto que armazena os contratos
        private static string contratoFilePath = "C:\\Users\\vinicius.zanatta\\Desktop\\TrabalhoPOON3\\TrabalhoPOON3\\Txt\\contrato.txt";

        public static void AdicionarContrato(string idCliente, string idImovel, DateTime dataInicio, DateTime dataFim, double valorAluguel, int numeroParcelas)
        {
            try
            {
                // Cria uma string com os dados do contrato separados por vírgula
                string contrato = $"{idCliente},{idImovel},{dataInicio},{dataFim},{valorAluguel},{numeroParcelas}";

                // Usa o método AppendAllText para adicionar o contrato ao final do arquivo de texto
                File.AppendAllText(contratoFilePath, contrato + Environment.NewLine);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EditarContrato(int id, string idCliente, string idImovel, DateTime dataInicio, DateTime dataFim, double valorAluguel, int numeroParcelas)
        {
            try
            {
                // Lê todas as linhas do arquivo de texto e armazena em um array
                string[] contratos = File.ReadAllLines(contratoFilePath);

                // Verifica se o id é válido e menor que o tamanho do array
                if (id > 0 && id <= contratos.Length)
                {
                    // Substitui a linha correspondente ao id pelo novo contrato
                    contratos[id - 1] = $"{idCliente},{idImovel},{dataInicio},{dataFim},{valorAluguel},{numeroParcelas}";

                    // Escreve o array atualizado no arquivo de texto
                    File.WriteAllLines(contratoFilePath, contratos);
                }
                else
                {
                    // Lança uma exceção se o id for inválido
                    throw new ArgumentException("Id inválido");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<string> ListarContratos()
        {
            try
            {
                // Lê todas as linhas do arquivo de texto que armazena os contratos
                string[] contratos = File.ReadAllLines(contratoFilePath);

                // Converte o array de contratos para uma lista e retorna
                return contratos.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
