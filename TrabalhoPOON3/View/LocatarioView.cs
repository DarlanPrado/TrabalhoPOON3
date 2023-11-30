using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPOON3.Model;

namespace TrabalhoPOON3.View
{
    public class LocatarioView : Tela
    {

        private LocatarioModel locatarioController = new LocatarioModel();

        public void MontarLocatarioView()
        {
            ConfigurarTela();
            string escolha;

            do
            {
                MontarTelaSistema(2, 2, 119 - 2, 24 - 2, 4, "Área do Locatario");
                escolha = MostrarMenu(new List<string>
                {
                    "1 - Cadastrar Locatario",
                    "2 - Listar Locatario",
                    "3 - Buscar Locatario por ID",
                    "4 - Buscar Locatario por CPF",
                    "5 - Editar Locatario",
                    "0 - Sair"
                }, 5, 5, 6);

                switch (escolha)
                {
                    case "1":
                        CadastrarLocatario();
                        break;
                    case "2":
                        ListarLocatarios();
                        break;
                    case "4":
                        BuscarLocatarioPorCPF();
                        break;
                    case "5":
                        EditarLocatario(); //TODO Editar Locatario
                        break;
                    case "0":
                        Console.WriteLine("Saindo da Área do Locatario.");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

            } while (escolha != "0");
        }

        private void EditarLocatario()
        {

        }

        private void CadastrarLocatario()
        {
            //
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);
            //

            CentralizarMensagem(2, 117, 5, " == Cadastrar Locatario == ");

            CentralizarMensagem(2, 117, 6, " == CPF == ");
            string cpf = Console.ReadLine();

            CentralizarMensagem(2, 117, 8, " == NOME == ");
            string nome = Console.ReadLine();

            CentralizarMensagem(2, 117, 10, " == TELEFONE == ");
            string telefone = Console.ReadLine();

            try 
            {
                locatarioController.AdicionarLocatario(cpf, nome, telefone);
                Console.WriteLine("Locatario cadastrado com sucesso.");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void ListarLocatarios()
        {
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);
            CentralizarMensagem(2, 117, 5, " == Listar Locatario == ");

            List<string> locatarios = locatarioController.ListarLocatarios();

            if (locatarios.Count == 0)
            {
                Console.WriteLine("Nenhum Locatario cadastrado.");
            }
            else
            {
                foreach (string locatario in locatarios)
                {
                    Console.WriteLine(locatario);
                    Console.ReadKey();
                }
            }
        }

        private void BuscarLocatarioPorCPF()
        {
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);
            CentralizarMensagem(2, 117, 5, "== Digite o CPF de Locatario ===");
            string cpf = Console.ReadLine();

            var locatario = locatarioController.BuscarLocatarioPorCPF(cpf);

            if (!string.IsNullOrEmpty(locatario))
            {
                Console.WriteLine($"Locatario encontrado: {locatario}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Locatario não encontrado.");
            }
        }
    }
}
