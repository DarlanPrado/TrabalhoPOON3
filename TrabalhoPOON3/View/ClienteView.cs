using System;
using System.Collections.Generic;
using TrabalhoPOON3.Model;

namespace TrabalhoPOON3.View
{
    public class ClienteView : Tela
    {

        public ClienteModel clienteController = new ClienteModel();

        public void MontarClienteView()
        {
            ConfigurarTela();
            string escolha;

            do
            {
                MontarTelaSistema(2, 2, 119 - 2, 24 - 2, 4, "Área do Cliente");
                escolha = MostrarMenu(new List<string>
                {
                    "1 - Cadastrar Cliente",
                    "2 - Listar Clientes",
                    "3 - Buscar Cliente por CPF",
                    "4 - Imoveis",
                    "5 - Editar Locatario",
                    "0 - Sair"
                }, 5, 5, 6);

                switch (escolha)
                {
                    case "1":
                        CadastrarCliente();
                        break;
                    case "2":
                        ListarClientes();
                        break;
                    case "3":
                        BuscarClientePorCPF();
                        break;
                    case "4":
                        Imovel(); //TODO
                        break;
                    case "5":
                        EditarCliente();
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

        private void Imovel()
        {

        }


        private void EditarCliente()
        {
            //
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);
            //

            CentralizarMensagem(2, 117, 5, " == Editar Informações do Cliente == ");


            CentralizarMensagem(2, 117, 6, " == CPF == ");
            string cpf = Console.ReadLine();

            CentralizarMensagem(2, 117, 8, " == NOME == ");
            string nome = Console.ReadLine();

            CentralizarMensagem(2, 117, 10, " == TELEFONE == ");
            string telefone = Console.ReadLine();

            CentralizarMensagem(2, 117, 12, " == ID == ");
            int id =int.Parse(Console.ReadLine());


            try
            {
                clienteController.EditarCliente(id, cpf, nome, telefone);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void CadastrarCliente()
        {
            //
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);
            //

            CentralizarMensagem(2, 117, 5, " == Cadastrar Usuario == ");

            CentralizarMensagem(2, 117, 6, " == CPF == ");
            string cpf = Console.ReadLine();

            CentralizarMensagem(2, 117, 8, " == NOME == ");
            string nome = Console.ReadLine();

            CentralizarMensagem(2, 117, 10, " == TELEFONE == ");
            string telefone = Console.ReadLine();

            try
            {
                clienteController.AdicionarCliente(cpf, nome, telefone);
                Console.SetCursorPosition(5, 5);
                Console.WriteLine("Cliente cadastrado com sucesso.");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void ListarClientes()
        {
            //
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);
            CentralizarMensagem(2, 117, 5, " == Listar Cliente == ");
            List<string> clientes = clienteController.ListarClientes();
            //

            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
            }
            else
            {
                string clientesString = string.Join(Environment.NewLine, clientes);
                LimparArea(5, 5, 114, 20);
                Console.SetCursorPosition(5, 5);
                Console.WriteLine(clientesString);
                Console.ReadKey();
            }
        }

        private void BuscarClientePorCPF()
        {
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);
            CentralizarMensagem(2, 117, 5, "== Digite o CPF de cliente ==");

            string cpf = Console.ReadLine();
            var cliente = clienteController.BuscarClientePorCPF(cpf);

            if (!string.IsNullOrEmpty(cliente))
            {
                LimparArea(5, 5, 114, 20);
                Console.SetCursorPosition(5, 5);
                Console.WriteLine($"Cliente encontrado: {cliente}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

    }
}
