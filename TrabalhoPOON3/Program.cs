using System;
using System.Collections.Generic;

namespace TrabalhoPOON3.View
{
    class Program
    {
        static void Main()
        {
            Tela tela = new Tela();
            ClienteView clienteView = new ClienteView();

            string opcao;
            List<string> menuPrincipal = new List<string>();

            menuPrincipal.Add("1 - Área do Cliente");
            menuPrincipal.Add("2 - Área do Imóvel");
            menuPrincipal.Add("3 - Área do Locatário");
            menuPrincipal.Add("0 - Sair");

            tela.ConfigurarTela();

            while (true)
            {
                tela.MontarTelaSistema();
                opcao = tela.MostrarMenu(menuPrincipal, 3, 3, 0);

                switch (opcao)
                {
                    case "0":
                        Console.Clear();
                        return;
                    case "1":
                        clienteView.MontarClienteView();
                        break;
                    // Adicione cases para outras opções de menu, se necessário
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}
