using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOON3.Model
{
    public class ClienteModel
    {

        public ImovelModel imovelController = new ImovelModel();

        // Define o caminho do arquivo de texto que armazena os clientes
        private static string clienteFilePath = "C:\\Users\\vinic\\source\\repos\\TrabalhoPOON3\\TrabalhoPOON3\\Txt\\Cliente.txt";

        public void AdicionarCliente(string cpf, string nome, string telefone)
        {
            try
            {
                // Cria uma string com os dados do cliente separados por vírgula
                string cliente = $"{cpf},{nome},{telefone}\n";

                // Usa o método AppendAllText para adicionar o cliente ao final do arquivo de texto
                File.AppendAllText(clienteFilePath, cliente + Environment.NewLine);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditarCliente(string cpf, string nome, string telefone)
        {
            try
            {
                // Lê todas as linhas do arquivo de texto e armazena em um array
                string[] clientes = File.ReadAllLines(clienteFilePath);


                for(int i = 0; i < clientes.Length; i++)
                {

                    string[] dadosCliente = clientes[i].Split(',');
                    if (dadosCliente[0] == cpf)
                    {
                        // Retorna os dados do cliente se encontrado
                        clientes[i] = $"{cpf},{nome},{telefone}";

                    }
                }
                File.WriteAllLines(clienteFilePath, clientes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditarCliente(string cpf, string nome, string telefone, string valor, string tipo)
        {
            try
            {
                // Lê todas as linhas do arquivo de texto e armazena em um array
                string[] clientes = File.ReadAllLines(clienteFilePath);

                for (int i = 0; i < clientes.Length; i++)
                {
                    string[] dadosCliente = clientes[i].Split(',');

                    if (dadosCliente[0] == cpf)
                    {
                        // Adiciona as informações do imóvel à linha do cliente
                        string clienteAtualizado = $"{cpf},{nome},{telefone},{valor},{tipo}";

                        // Atualiza a linha do cliente no arquivo
                        clientes[i] = clienteAtualizado;
                        File.WriteAllLines(clienteFilePath, clientes);

                        break;
                    }
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

        public void VincularImovelAoCliente(string cpf, string valor, string tipo)
        {
            try
            {
                // Verifica se o cliente com o CPF fornecido existe
                string dadosCliente = this.BuscarClientePorCPF(cpf);

                if (dadosCliente != null)
                {
                    // Obtém dados do cliente
                    string[] dadosClienteArray = dadosCliente.Split(',');
                    string nome = dadosClienteArray[1];
                    string telefone = dadosClienteArray[2];

                    // Chama a função para adicionar informações do imóvel ao cliente
                    EditarCliente(cpf, nome, telefone, valor, tipo);
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado com o CPF fornecido.");
                }
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
                    if (dadosCliente[0] == cpf)
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