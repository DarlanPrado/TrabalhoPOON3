using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPOON3.Controller;

namespace TrabalhoPOON3.View
{
    public class LocatarioView : Tela
    {

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
                    case "3":
                        BuscarLocatarioPorID();
                        break;
                    case "4":
                        BuscarLocatarioPorCPF();
                        break;
                    case "5":
                        EditarLocatario(); //TODO Editar Locatario
                        break;
                    case "0":
                        Console.WriteLine("Saindo da Área do Cliente.");
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

            LocatarioController.adicionarLocatario(cpf, nome, telefone);

            Console.WriteLine("Cliente cadastrado com sucesso.");
        }

        private void ListarLocatarios()
        {
            //
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);
            CentralizarMensagem(2, 117, 5, " == Listar Cliente == ");
            var clientes = LocatarioController.listLocatario();
            //


            if (clientes.Rows.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
            }
            else
            {
                foreach (System.Data.DataRow row in clientes.Rows)
                {
                    Console.WriteLine($"ID: {row["ID_CLIENTE"]}, CPF: {row["CPF"]}, Nome: {row["NOME"]}, Telefone: {row["TELEFONE"]}");
                }
            }
        }

        private void BuscarLocatarioPorID()
        {
            //
            string id;
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);
            CentralizarMensagem(2, 117, 5, " == Digite o id de cliente == ");
            id = Console.ReadLine();
            //


            if (int.TryParse(id, out int numeroInt))
            {
                var cliente = LocatarioController.BuscarClientePorID(numeroInt); //TODO LocatarioController.BuscarLocatarioPorID

                if (cliente.Rows.Count > 0)
                {
                    Console.WriteLine($"Cliente encontrado: ID: {cliente.Rows[0]["ID_CLIENTE"]}, CPF: {cliente.Rows[0]["CPF"]}, Nome: {cliente.Rows[0]["NOME"]}, Telefone: {cliente.Rows[0]["TELEFONE"]}");
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }

        private void BuscarLocatarioPorCPF()
        {
            //
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);
            CentralizarMensagem(2, 117, 5, "== Digite o CPF de cliente ==");
            string cpf = Console.ReadLine();
            //

            var cliente = ClienteModel.BuscarClientePorCPF(cpf); //TODO LocatarioController.BuscarLocatarioPorCPF

            if (cliente.Rows.Count > 0)
            {
                Console.WriteLine($"Cliente encontrado: ID: {cliente.Rows[0]["ID_CLIENTE"]}, CPF: {cliente.Rows[0]["CPF"]}, Nome: {cliente.Rows[0]["NOME"]}, Telefone: {cliente.Rows[0]["TELEFONE"]}");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }
    }
}
