using System;
using System.Collections.Generic;
using TrabalhoPOON3.Controller;

namespace TrabalhoPOON3.View
{
    public class ClienteView : Tela
    {

        public ClienteController clienteController = new ClienteController();

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
                    "3 - Buscar Cliente por ID",
                    "4 - Buscar Cliente por CPF",
                    "5 - Imoveis",
                    "6 - Editar Locatario",
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
                        BuscarClientePorID();
                        break;
                    case "4":
                        BuscarClientePorCPF();
                        break;
                    case "5":
                        Imovel(); //TODO
                        break;
                    case "6":
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
                clienteController.editarCliente(id, cpf, nome, telefone);
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
                clienteController.adicionarCliente(cpf, nome, telefone);
                Console.WriteLine("Cliente cadastrado com sucesso.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void ListarClientes()
        {
            //
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);
            CentralizarMensagem(2, 117, 5, " == Listar Cliente == ");
            var clientes = clienteController.ListarClientes();
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

        private void BuscarClientePorID()
        {
            //
            string id;
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);
            CentralizarMensagem(2, 117, 5, "== Digite o id de cliente ==");
            id = Console.ReadLine();
            //


            if (int.TryParse(id, out int numeroInt))
            {
                var cliente = clienteController.BuscarClientePorID(numeroInt);

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

        private void BuscarClientePorCPF()
        {
            //
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);
            CentralizarMensagem(2, 117, 5, "== Digite o CPF de cliente ==");
            string cpf = Console.ReadLine();
            //

            var cliente = clienteController.BuscarClientePorCPF(cpf);

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
