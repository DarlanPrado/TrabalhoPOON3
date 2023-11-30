using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPOON3.Controller;
using TrabalhoPOON3.Model;

namespace TrabalhoPOON3.View
{
    public class ImovelView : Tela
    {
        private LocatarioController locatarioController = new LocatarioController();

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
                "0 - Sair"
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
                        AlterarImovel();
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

                        CentralizarMensagem(2, 117, 10, " == Nome do Locatario == ");
            string nomeLocatario = Console.ReadLine();

            CentralizarMensagem(2, 117, 11, " == Telefone do Locatario == ");
            string telefoneLocatario = Console.ReadLine();

            // Substitua as informações acima pelos dados específicos do Imóvel
            // ...

            locatarioController.adicionarLocatario(cpfLocatario, nomeLocatario, telefoneLocatario);
            Console.WriteLine("Imóvel cadastrado com sucesso.");
        }

        private void ListarImoveis()
        {
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);

            CentralizarMensagem(2, 117, 5, "== Listar Imóveis ==");

            DataTable imoveis = locatarioController.listLocatario();

            if (imoveis.Rows.Count == 0)
            {
                Console.WriteLine("Nenhum imóvel cadastrado.");
            }
            else
            {
                foreach (System.Data.DataRow row in imoveis.Rows)
                {
                    Console.WriteLine($"ID Imóvel: {row["ID_IMOVEL"]}, ID ou CPF do Cliente: {row["ID_OU_CPF_CLIENTE"]}, Tipo: {row["TIPO_IMOVEL"]}, Valor do Aluguel: {row["VALOR_ALUGUEL"]}");
                }
            }
        }
        //Darlan muda essa parte pra mudar as info de cadastro
        private void AlterarImovel()
        {
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);

            CentralizarMensagem(2, 117, 5, " == Alterar Imóvel == ");

            CentralizarMensagem(2, 117, 6, " == Digite o ID do Imóvel que deseja alterar == ");
            string idImovel = Console.ReadLine();

            if (int.TryParse(idImovel, out int idImovelInt))
            {
                DataTable imovel = locatarioController.getInfosLocatario(idImovelInt);

                if (imovel.Rows.Count > 0)
                {
                    CentralizarMensagem(2, 117, 8, " == Novo Valor do Aluguel == ");
                    string novoValorAluguel = Console.ReadLine();


                    if (double.TryParse(novoValorAluguel, out double novoValorAluguelDouble))
                    {
                        //Essa parte
                        locatarioController.editarLocatario(idImovelInt, novoValorAluguelDouble);
                        Console.WriteLine("Valor do aluguel alterado com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Valor do Aluguel inválido.");
                    }
                }
                else
                {
                    Console.WriteLine("Imóvel não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID do Imóvel inválido.");
            }
        }
    }

}
