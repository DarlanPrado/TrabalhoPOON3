using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPOON3.Model;

namespace TrabalhoPOON3.View
{
    internal class ContratoView : Tela
    {
        ContratoModel contratoModel = new ContratoModel();
        public void MontarContratoView()
        {
            ConfigurarTela();
            string escolha;

            do
            {
                MontarTelaSistema(2, 2, 119 - 2, 24 - 2, 4, "Área do Imóvel");
                escolha = MostrarMenu(new List<string>
            {
                "1 - Gerar Contrato",
                "2 - Listar Contrato por CPF de Cliente",
                "3 - Listar Contrato por CPF de Locatario",
                "0 - Sair",
            }, 5, 5, 6);

                switch (escolha)
                {
                    case "1":
                        GerarContrato();
                        break;
                    case "2":
                        BuscarContratoPorCliente();
                        break;
                    case "3":
                        BuscarContratoPorLocatario();
                        break;
                    case "0":
                        Console.WriteLine("Saindo da Área do Imóvel.");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            } while (escolha != "0");
        }

        public void BuscarContratoPorCliente()
        {
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);

            CentralizarMensagem(2, 117, 5, " == Buscar Contrato Por Cliente == ");
            CentralizarMensagem(2, 117, 7, " == CPF do Cliente == ");

            string cpfCliente = Console.ReadLine();

            string dados = contratoModel.BuscarContratoPorCPF(cpfCliente);

            if (dados != null)
            {
                LimparArea(5, 5, 114, 20);
                Console.SetCursorPosition(5, 5);

                // Separar os dados
                string[] partes = dados.Split(',');

                // Certifique-se de que há pelo menos 8 partes antes de atribuir
                if (partes.Length >= 8)
                {
                    string cpfClientes = partes[0];
                    string nomeCliente = partes[1];
                    string numeroCliente = partes[2];
                    string valorImovel = partes[3];
                    string tipoImovel = partes[4];
                    string cpfLocatario = partes[5];
                    string nomeLocatario = partes[6];
                    string numeroLocatario = partes[7];
                    // Adicione as outras variáveis conforme necessário

                    LimparArea(5, 5, 114, 20);
                    Console.SetCursorPosition(5, 5);

                    // Exemplo de impressão das variáveis
                    CentralizarMensagem(2, 117, 5, $"CPF Cliente do Contrato: {cpfClientes}");
                    CentralizarMensagem(2, 117, 6, $"Nome Cliente do Contrato: {nomeCliente}");
                    CentralizarMensagem(2, 117, 7, $"Numero Cliente do Contrato: {numeroCliente}");
                    CentralizarMensagem(2, 117, 8, $"Valor do Imovel: {valorImovel}");
                    CentralizarMensagem(2, 117, 9, $"Tipo do Imovel: {tipoImovel}");
                    CentralizarMensagem(2, 117, 10, $"CPF Locatario do Contrato: {cpfLocatario}");
                    CentralizarMensagem(2, 117, 11, $"Nome do Locatario do Contrato: {nomeLocatario}");
                    CentralizarMensagem(2, 117, 12, $"Numero do Locatario do Contrato: {numeroLocatario}");
                    // Adicione outras variáveis conforme necessário
                }
                else
                {
                    Console.WriteLine("Os dados do contrato não têm o formato esperado.");
                }
            }
            else
            {
                Console.WriteLine("Contrato não encontrado para o CPF do cliente fornecido.");
            }

            Console.ReadKey();
        }


        public void BuscarContratoPorLocatario()
        {
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);
            //

            CentralizarMensagem(2, 117, 5, " == Buscar Contrato Por Locatario == ");

            CentralizarMensagem(2, 117, 7, " == CPF do Locatario == ");
            string cpfLocatario = Console.ReadLine();


            string dados = contratoModel.BuscarContratoPorCPF(cpfLocatario);


            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);
            Console.WriteLine(dados);
            Console.ReadKey();
        }
        public void GerarContrato()
        {
            //
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);
            //

            CentralizarMensagem(2, 117, 5, " == Gerar Contrato == ");

            CentralizarMensagem(2, 117, 11, " == Cpf do Cliente == ");
            string cpfCliente = Console.ReadLine();

            CentralizarMensagem(2, 117, 11, " == Cpf do Locatario == ");
            string cpfLocatario = Console.ReadLine();

            contratoModel.GerarContrato(cpfCliente, cpfLocatario);
        }
    }
}
