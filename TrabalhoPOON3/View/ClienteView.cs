using System;
using System.Collections.Generic;
using TrabalhoPOON3.Model;

namespace TrabalhoPOON3.View
{
    public class ClienteView : Tela
    {

        public ClienteModel clienteController = new ClienteModel();
        public ImovelModel imovelController = new ImovelModel();

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
                    "4 - Imoveis por CPF do Cliente",
                    "5 - Vincular Imovel ao Cliente",
                    "6 - Editar Cliente",
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
                        ListarImoveisPorCliente();
                        break;
                    case "5":
                        VincularImovelAoCliente();
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

        private void VincularImovelAoCliente()
        {
            //
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);
            //

            CentralizarMensagem(2, 117, 5, " == Editar Informações do Cliente == ");


            CentralizarMensagem(2, 117, 6, " == CPF == ");
            string cpf = Console.ReadLine();

            CentralizarMensagem(2, 117, 8, " == Valor do Imovel == ");
            string valor = Console.ReadLine();

            CentralizarMensagem(2, 117, 10, " == Tipo do Imovel == ");
            string tipo = Console.ReadLine();



            clienteController.VincularImovelAoCliente(cpf,valor,tipo);

        }

        private void ListarImoveisPorCliente()
        {
            //
            LimparArea(5, 5, 114, 20);
            Console.SetCursorPosition(5, 5);
            //

            CentralizarMensagem(2, 117, 5, " == Editar Informações do Cliente == ");


            CentralizarMensagem(2, 117, 6, " == CPF == ");
            string cpf = Console.ReadLine();

            string imovel = imovelController.ListarImoveisDoCliente(cpf);
            CentralizarMensagem(2, 117, 8, "Os imoveis são:\n");
            CentralizarMensagem(2, 117, 10,imovel);


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

            try
            {
                clienteController.EditarCliente(cpf, nome, telefone);
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
                LimparArea(5, 5, 114, 20);
                Console.SetCursorPosition(5, 5);
                CentralizarMensagem(2, 117, 5, "Cliente cadastrado com sucesso.");
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
                if (clientesString != null)
                {
                    LimparArea(5, 5, 114, 20);
                    Console.SetCursorPosition(5, 5);

                    // Separar os dados
                    string[] partes = clientesString.Split(',');

                    // Certifique-se de que há pelo menos 8 partes antes de atribuir
                    if (partes.Length >= 8)
                    {
                        string cpfClientes = partes[0];
                        string nomeCliente = partes[1];
                        string numeroCliente = partes[2];
                        // Adicione as outras variáveis conforme necessário

                        LimparArea(5, 5, 114, 20);
                        Console.SetCursorPosition(5, 5);

                        // Exemplo de impressão das variáveis
                        CentralizarMensagem(2, 117, 5, $"CPF Cliente do Contrato: {cpfClientes}");
                        CentralizarMensagem(2, 117, 6, $"Nome Cliente do Contrato: {nomeCliente}");
                        CentralizarMensagem(2, 117, 7, $"Numero Cliente do Contrato: {numeroCliente}");
                        Console.ReadKey();
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
