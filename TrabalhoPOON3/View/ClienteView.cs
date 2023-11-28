using System;
using System.Collections.Generic;
using TrabalhoPOON3.Model;

using System;
using System.Collections.Generic;
using TrabalhoPOON3.Model;

namespace TrabalhoPOON3.View
{
    public class ClienteView
    {
        private Tela telaClienteView = new Tela();

        public void MontarClienteView()
        {
            telaClienteView.ConfigurarTela();
            string escolha;

            do
            {
                telaClienteView.MontarTelaSistema(2, 2, 119 - 2, 24 - 2, 4, "Área do Cliente");
                escolha = telaClienteView.MostrarMenu(new List<string>
                {
                    "1 - Cadastrar Cliente",
                    "2 - Listar Clientes",
                    "3 - Buscar Cliente por ID",
                    "4 - Buscar Cliente por CPF",
                    "0 - Sair"
                }, 5, 5, 3);

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
                    case "0":
                        Console.WriteLine("Saindo da Área do Cliente.");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

            } while (escolha != "0");
        }

        private void CadastrarCliente()
        {
            Console.WriteLine("== Cadastrar Cliente ==");

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            ClienteModel.AdicionarCliente(cpf, nome, telefone);

            Console.WriteLine("Cliente cadastrado com sucesso.");
        }

        private void ListarClientes()
        {
            Console.WriteLine("== Lista de Clientes ==");

            var clientes = ClienteModel.ListarClientes();

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
            Console.Write("Digite o ID do cliente: ");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                var cliente = ClienteModel.BuscarClientePorID(id);

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
            Console.Write("Digite o CPF do cliente: ");
            string cpf = Console.ReadLine();

            var cliente = ClienteModel.BuscarClientePorCPF(cpf);

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
