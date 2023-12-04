using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOON3.Model
{
    public class LocatarioModel : Database
    {
        // Define o caminho do arquivo de texto que armazena os locatarios
        private static string locatarioFilePath = "C:\\Users\\vinic\\source\\repos\\TrabalhoPOON3\\TrabalhoPOON3\\Txt\\Locatario.txt";

        public void AdicionarLocatario(string cpf, string nome, string telefone)
        {
            try
            {
                // Cria uma string com os dados do locatario separados por vírgula
                string locatario = $"{cpf},{nome},{telefone}";

                // Usa o método AppendAllText para adicionar o locatario ao final do arquivo de texto
                File.AppendAllText(locatarioFilePath, locatario + Environment.NewLine);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditarLocatario(string cpf, string nome, string telefone)
        {
            try
            {
                // Lê todas as linhas do arquivo de texto e armazena em um array
                string[] locatario = File.ReadAllLines(locatarioFilePath);


                for (int i = 0; i < locatario.Length; i++)
                {

                    string[] dadosCliente = locatario[i].Split(',');
                    if (dadosCliente[0] == cpf)
                    {
                        // Retorna os dados do cliente se encontrado
                        locatario[i] = $"{cpf},{nome},{telefone}";

                    }
                }
                File.WriteAllLines(locatarioFilePath, locatario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> ListarLocatarios()
        {
            try
            {
                // Lê todas as linhas do arquivo de texto que armazena os locatarios
                string[] locatarios = File.ReadAllLines(locatarioFilePath);

                // Converte o array de locatarios para uma lista e retorna
                return locatarios.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string BuscarLocatarioPorCPF(string cpf)
        {
            try
            {
                // Lê todas as linhas do arquivo de texto que armazena os locatarios
                string[] locatarios = File.ReadAllLines(locatarioFilePath);

                // Procura o locatario pelo CPF
                foreach (string locatario in locatarios)
                {
                    string[] dadosLocatario = locatario.Split(',');
                    if (dadosLocatario.Length >= 3 && dadosLocatario[0] == cpf)
                    {
                        // Retorna os dados do locatario se encontrado
                        return locatario;
                    }
                }

                // Retorna null se o locatario não for encontrado
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
