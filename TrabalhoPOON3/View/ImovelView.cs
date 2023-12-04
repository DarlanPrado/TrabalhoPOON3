using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPOON3.Model;

namespace TrabalhoPOON3.View
{
    public class ImovelView : Tela
    {
        private ImovelModel imovelController = new ImovelModel();

        public void MontarImovelView()
        {
            ConfigurarTela();
            string escolha;

            do
            {
                MontarTelaSistema(2, 2, 119 - 2, 24 - 2, 4, "Área do Imóvel");
                escolha = MostrarMenu(new List<string>
            {
                "1 - Cadastrar Imóvel",
                "2 - Listar Imóveis",
                "3 - Alterar Imóvel",
                "0 - Sair",
            }, 5, 5, 6);

                switch (escolha)
                {
                    case "1":
                        CadastrarImovel();
                        break;
                    case "2":
                        ListarImoveis();
                        break;
                    case "3":
                        AlterarValorImovel();
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

        private void AlterarValorImovel()
        {
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);

            CentralizarMensagem(2, 117, 5, " == Editar Imóvel == ");

            CentralizarMensagem(2, 117, 10, " == Tipo do Imovel == ");
            string tipoImovel = Console.ReadLine();

            CentralizarMensagem(2, 117, 11, " == Valor novo do Imovel == ");
            double valorImovel = double.Parse(Console.ReadLine());

            imovelController.EditarImovel(tipoImovel, valorImovel);
        }
        private void CadastrarImovel()
        {
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);

            CentralizarMensagem(2, 117, 5, " == Cadastrar Imóvel == ");

            CentralizarMensagem(2, 117, 10, " == Tipo do Imovel == ");
            string tipoImovel = Console.ReadLine();

            CentralizarMensagem(2, 117, 11, " == Valor do Imovel == ");
            double valorImovel = double.Parse(Console.ReadLine());

            try 
            {
                imovelController.AdicionarImovel(tipoImovel, valorImovel);
                Console.WriteLine("Imóvel cadastrado com sucesso.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void ListarImoveis()
        {
            //
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);
            CentralizarMensagem(2, 117, 5, "== Listar Imóveis ==");
            //

            List<string> resultado = imovelController.ListarImovel();

            string imovelString = string.Join(Environment.NewLine, resultado);

            CentralizarMensagem(2, 117, 10, " == Imoveis == ");
            CentralizarMensagem(2, 117, 10, imovelString);
            Console.ReadKey();

        }
    }

}
