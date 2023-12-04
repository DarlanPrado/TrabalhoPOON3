using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOON3.Model
{
    public class ImovelModel
    {
        // Define o caminho do arquivo de texto que armazena os imoveis
        private static string imovelFilePath = "C:\\Users\\vinic\\source\\repos\\TrabalhoPOON3\\TrabalhoPOON3\\Txt\\Imovel.txt";

        // Define o caminho do arquivo de texto que armazena a relação entre clientes e imoveis
        private static string clienteImovelFilePath = "C:\\Users\\vinic\\source\\repos\\TrabalhoPOON3\\TrabalhoPOON3\\Txt\\Cliente.txt";


        public List<string> ListarImovel()
        {
            try
            {
                // Lê todas as linhas do arquivo de texto e armazena em um array
                string[] imovel = File.ReadAllLines(imovelFilePath);

                // Converte o array de clientes para uma lista e retorna
                return imovel.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void AdicionarImovel(string TipoImovel, double valor)
        {

            try
            {
                // Cria uma string com os dados do imovel separados por vírgula
                string imovel = $"{TipoImovel},{valor}";

                // Usa o método AppendAllText para adicionar o imovel ao final do arquivo de texto
                File.AppendAllText(imovelFilePath, imovel + Environment.NewLine);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void EditarImovel(string tipoImovel, double valorNovo)
        {
            try
            {
                // Lê todas as linhas do arquivo de texto e armazena em um array
                string[] imoveis = File.ReadAllLines(imovelFilePath);

                for (int i = 0; i < imoveis.Length; i++)
                {
                    string[] dadosImovel = imoveis[i].Split(',');

                    if (dadosImovel.Length == 2 && dadosImovel[0] == tipoImovel && double.TryParse(dadosImovel[1], out double valorAtual))
                    {
                        // Atualiza o valor do imóvel
                        imoveis[i] = $"{tipoImovel},{valorNovo}";
                        File.WriteAllLines(imovelFilePath, imoveis);
                        break;
                    }
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
