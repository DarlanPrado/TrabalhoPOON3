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
                        //AlterarImovel();
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

        private void CadastrarImovel()
        {
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);

            CentralizarMensagem(2, 117, 5, " == Cadastrar Imóvel == ");

            CentralizarMensagem(2, 117, 8, " == CPF do Locatario == ");
            string cpfLocatario = Console.ReadLine();

            CentralizarMensagem(2, 117, 10, " == Tipo do Imovel == ");
            string tipoImovel = Console.ReadLine();

            CentralizarMensagem(2, 117, 11, " == Valor do Imovel == ");
            double valorImovel = double.Parse(Console.ReadLine());

            // Substitua as informações acima pelos dados específicos do Imóvel
            // ...
            try 
            {
                imovelController.AdicionarImovel(cpfLocatario, tipoImovel, valorImovel);
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
            CentralizarMensagem(2, 117, 10, " == Cpf do Cliente == ");
            string cpfCliente = Console.ReadLine();
            //

            string resultado = imovelController.ListarImoveisDoCliente(cpfCliente);


            CentralizarMensagem(2, 117, 10, " == Imoveis do Cliente == ");
            CentralizarMensagem(2, 117, 10, resultado);

        }
        //Darlan muda essa parte pra mudar as info de cadastro
        //private void AlterarImovel()
        //{
        //    LimparArea(5, 5, 114, 20);
        //    Console.SetCursorPosition(5, 5);

        //    CentralizarMensagem(2, 117, 5, " == Alterar Imóvel == ");

        //    CentralizarMensagem(2, 117, 6, " == Digite o CPF do Cliente do Imovel que deseja alterar == ");
        //    string cpfImovel = Console.ReadLine();

        //    if (int.TryParse(cpfImovel, out int idImovelInt))
        //    {
        //        DataTable imovel = ImovelController.BuscarImovelPorID(idImovelInt);

        //        if (imovel.Rows.Count > 0)
        //        {
        //            CentralizarMensagem(2, 117, 8, " == Novo Valor do Aluguel == ");
        //            string novoValorAluguel = Console.ReadLine();


        //            if (double.TryParse(novoValorAluguel, out double novoValorAluguelDouble))
        //            {
        //                //Essa parte
        //                //locatarioController.editarLocatario(idImovelInt, novoValorAluguelDouble);
        //                Console.WriteLine("Valor do aluguel alterado com sucesso.");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Valor do Aluguel inválido.");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Imóvel não encontrado.");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("ID do Imóvel inválido.");
        //    }
        //}
    }

}
