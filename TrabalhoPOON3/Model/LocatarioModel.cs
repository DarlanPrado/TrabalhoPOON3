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
        private static string locatarioFilePath = "C:\\Users\\vinicius.zanatta\\Desktop\\TrabalhoPOON3\\TrabalhoPOON3\\Txt\\locatario.txt";

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

        public void EditarLocatario(int id, string cpf, string nome, string telefone)
        {
            try
            {
                // Lê todas as linhas do arquivo de texto e armazena em um array
                string[] locatarios = File.ReadAllLines(locatarioFilePath);

                // Verifica se o id é válido e menor que o tamanho do array
                if (id > 0 && id <= locatarios.Length)
                {
                    // Substitui a linha correspondente ao id pelo novo locatario
                    locatarios[id - 1] = $"{cpf},{nome},{telefone}";

                    // Escreve o array atualizado no arquivo de texto
                    File.WriteAllLines(locatarioFilePath, locatarios);
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
