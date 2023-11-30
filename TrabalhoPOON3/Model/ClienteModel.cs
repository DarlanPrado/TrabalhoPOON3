using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOON3.Model
{
    public class ClienteModel : Database
    {
        // Define o caminho do arquivo de texto que armazena os clientes
        private static string clienteFilePath = "C:\\Users\\vinicius.zanatta\\Desktop\\TrabalhoPOON3\\TrabalhoPOON3\\Txt\\cliente.txt";

        public void AdicionarCliente(string cpf, string nome, string telefone)
        {
            try
            {
                // Cria uma string com os dados do cliente separados por vírgula
                string cliente = $"{cpf},{nome},{telefone}";

                // Usa o método AppendAllText para adicionar o cliente ao final do arquivo de texto
                File.AppendAllText(clienteFilePath, cliente + Environment.NewLine);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditarCliente(int id, string cpf, string nome, string telefone)
        {
            try
            {
                // Lê todas as linhas do arquivo de texto e armazena em um array
                string[] clientes = File.ReadAllLines(clienteFilePath);

                // Verifica se o id é válido e menor que o tamanho do array
                if (id > 0 && id <= clientes.Length)
                {
                    // Substitui a linha correspondente ao id pelo novo cliente
                    clientes[id - 1] = $"{cpf},{nome},{telefone}";

                    // Escreve o array atualizado no arquivo de texto
                    File.WriteAllLines(clienteFilePath, clientes);
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

        public List<string> ListarClientes()
        {
            try
            {
                // Lê todas as linhas do arquivo de texto e armazena em um array
                string[] clientes = File.ReadAllLines(clienteFilePath);

                // Converte o array de clientes para uma lista e retorna
                return clientes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string BuscarClientePorCPF(string cpf)
        {
            try
            {
                // Lê todas as linhas do arquivo de texto e armazena em um array
                string[] clientes = File.ReadAllLines(clienteFilePath);

                // Procura o cliente pelo CPF
                foreach (string cliente in clientes)
                {
                    string[] dadosCliente = cliente.Split(',');
                    if (dadosCliente.Length >= 3 && dadosCliente[0] == cpf)
                    {
                        // Retorna os dados do cliente se encontrado
                        return cliente;
                    }
                }

                // Retorna null se o cliente não for encontrado
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
