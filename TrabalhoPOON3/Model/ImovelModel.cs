using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOON3.Model
{
    internal class ImovelModel : Database
    {
        // Define o caminho do arquivo de texto que armazena os imoveis
        private static string imovelFilePath = "C:\\Users\\vinicius.zanatta\\Desktop\\TrabalhoPOON3\\TrabalhoPOON3\\Txt\\imovel.txt";

        // Define o caminho do arquivo de texto que armazena a relação entre clientes e imoveis
        private static string clienteImovelFilePath = "cliente_imovel.txt";

        public void AdicionarImovel(string cpfCliente, string TipoImovel, double valor)
        {
            int idImovel = 0;

            try
            {
                // Cria uma string com os dados do imovel separados por vírgula
                string imovel = $"{TipoImovel},{valor}";

                // Usa o método AppendAllText para adicionar o imovel ao final do arquivo de texto
                File.AppendAllText(imovelFilePath, imovel + Environment.NewLine);

                // Obtém o número de linhas do arquivo de texto, que corresponde ao id do imovel
                idImovel = File.ReadAllLines(imovelFilePath).Length;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                // Cria uma string com os dados da relação entre cliente e imovel separados por vírgula
                string clienteImovel = $"{cpfCliente},{idImovel},1";

                // Usa o método AppendAllText para adicionar a relação ao final do arquivo de texto
                File.AppendAllText(clienteImovelFilePath, clienteImovel + Environment.NewLine);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void AdicionarImovelAoCliente(string idImovel, string idCliente)
        {
            try
            {
                // Cria uma string com os dados da relação entre cliente e imovel separados por vírgula
                string clienteImovel = $"{idCliente},{idImovel},1";

                // Usa o método AppendAllText para adicionar a relação ao final do arquivo de texto
                File.AppendAllText(clienteImovelFilePath, clienteImovel + Environment.NewLine);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditarImovel(string idImovel, string TipoImovel, double valor, bool disponivel)
        {
            try
            {
                // Lê todas as linhas do arquivo de texto e armazena em um array
                string[] imoveis = File.ReadAllLines(imovelFilePath);

                // Verifica se o id é válido e menor que o tamanho do array
                if (int.TryParse(idImovel, out int id) && id > 0 && id <= imoveis.Length)
                {
                    // Substitui a linha correspondente ao id pelo novo imovel
                    imoveis[id - 1] = $"{TipoImovel},{valor},{disponivel}";

                    // Escreve o array atualizado no arquivo de texto
                    File.WriteAllLines(imovelFilePath, imoveis);
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

        public string ListarImoveisDoCliente(string cpfCliente)
        {
            try
            {
                // Lê todas as linhas do arquivo de texto que armazena a relação entre clientes e imoveis
                string[] clienteImoveis = File.ReadAllLines(clienteImovelFilePath);

                // Filtra as entradas relacionadas ao cliente fornecido
                var imoveisDoCliente = clienteImoveis
                    .Where(line => line.Split(',')[0] == cpfCliente)
                    .Select(line => line.Split(',')[1]) // Pega o id do imovel
                    .ToList();

                // Lê todas as linhas do arquivo de texto que armazena os imoveis
                string[] imoveis = File.ReadAllLines(imovelFilePath);

                // Filtra os dados dos imoveis do cliente
                var dadosImoveisDoCliente = imoveisDoCliente
                    .Select(idImovel =>
                    {
                        if (int.TryParse(idImovel, out int id) && id > 0 && id <= imoveis.Length)
                        {
                            return imoveis[id - 1];
                        }
                        return null;
                    })
                    .Where(dadosImovel => dadosImovel != null)
                    .ToList();
                string dadosImoveisString = string.Join(Environment.NewLine, dadosImoveisDoCliente);


                return dadosImoveisString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
