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
        private static string contratoFilePath = "C:\\Users\\vinic\\source\\repos\\TrabalhoPOON3\\TrabalhoPOON3\\Txt\\Contrato.txt";
        private static string locatarioFilePath = "C:\\Users\\vinic\\source\\repos\\TrabalhoPOON3\\TrabalhoPOON3\\Txt\\Locatario.txt";
        private static string clienteFilePath = "C:\\Users\\vinic\\source\\repos\\TrabalhoPOON3\\TrabalhoPOON3\\Txt\\Cliente.txt";
        LocatarioModel locatarioModel = new LocatarioModel();
        ClienteModel clienteModel = new ClienteModel();

       public void GerarContrato(string cpfCliente,string cpfLocatario)
        {
            string dadosCliente = clienteModel.BuscarClientePorCPF(cpfCliente);
            string dadosLocatario = locatarioModel.BuscarLocatarioPorCPF(cpfLocatario);
            try
            {
                // Cria uma string com os dados do locatario separados por vírgula
                string locatario = $"{dadosCliente},{dadosLocatario}";

                // Usa o método AppendAllText para adicionar o locatario ao final do arquivo de texto
                File.AppendAllText(contratoFilePath, locatario + Environment.NewLine);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string BuscarContratoPorCPF(string cpf)
        {
            try
            {
                // Lê todas as linhas do arquivo de texto que armazena os contratos
                string[] contratos = File.ReadAllLines(contratoFilePath);

                // Procura o contrato pelo CPF
                foreach (string contrato in contratos)
                {
                    string[] dadosContrato = contrato.Split(',');

                    // Verifica se o contrato pertence ao cliente ou locatário com o CPF fornecido
                    if (dadosContrato.Length >= 2 && (dadosContrato[0] == cpf || dadosContrato[1] == cpf))
                    {
                        // Retorna os dados do contrato se encontrado
                        return contrato;
                    }
                }

                // Retorna null se o contrato não for encontrado
                return null;
            }
            catch (Exception ex)
            {
                // Trata exceções durante a leitura do arquivo de contratos
                throw ex;
            }
        }

    }
}
