using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOON3.View
{
    public class Tela
    {
        // propriedades
        ConsoleColor corTexto, corFundo;


        // construtor
        public Tela(ConsoleColor ct = ConsoleColor.Magenta,
                    ConsoleColor cf = ConsoleColor.Black)
        {
            this.corFundo = cf;
            this.corTexto = ct;

            this.ConfigurarTela();
        }


        public void ConfigurarTela()
        {
            Console.BackgroundColor = this.corFundo;
            Console.ForegroundColor = this.corTexto;
            Console.Clear();
        }

        public void MontarTelaSistema()
        {
            this.MontarMoldura(0, 0, 119, 24);
            this.MontarLinhaHor(2, 0, 119);
            this.CentralizarMensagem(0, 119, 1, "Banco");
        }

        public void MontarTelaSistema(int ci, int li, int cf, int lf,int lincen,string text)
        {
            this.MontarMoldura(ci, li, cf, lf);
            this.CentralizarMensagem(ci,cf,lincen,text);
        }



        public void MontarMoldura(int ci, int li, int cf, int lf)
        {
            int col, lin;

            // limpa a area em que será montada a moldura
            this.LimparArea(ci, li, cf, lf);

            // desenha as linhas horizontais
            for (col = ci; col <= cf; col++)
            {
                Console.SetCursorPosition(col, li);
                Console.Write("-");
                Console.SetCursorPosition(col, lf);
                Console.Write("-");
            }

            // desenha as linhas verticais
            for (lin = li; lin <= lf; lin++)
            {
                Console.SetCursorPosition(ci, lin);
                Console.Write("|");
                Console.SetCursorPosition(cf, lin);
                Console.Write("|");
            }

            // desenha os cantos da moldura
            Console.SetCursorPosition(ci, li); Console.Write("+");
            Console.SetCursorPosition(ci, lf); Console.Write("+");
            Console.SetCursorPosition(cf, li); Console.Write("+");
            Console.SetCursorPosition(cf, lf); Console.Write("+");
        }


        public void LimparArea(int ci, int li, int cf, int lf)
        {
            int col, lin;
            // para cada coluna
            for (col = ci; col <= cf; col++)
            {
                // em cada uma das linahs
                for (lin = li; lin <= lf; lin++)
                {
                    // posiciona
                    Console.SetCursorPosition(col, lin);
                    // imprime 1 espaço em branco para "limpar"
                    Console.Write(" ");
                }
            }
        }


        public void MontarLinhaHor(int lin, int ci, int cf)
        {
            int col;
            // traça a linha
            for (col = ci; col <= cf; col++)
            {
                Console.SetCursorPosition(col, lin);
                Console.Write("-");
            }
            // arruma as pontas
            Console.SetCursorPosition(ci, lin);
            Console.Write("+");
            Console.SetCursorPosition(cf, lin);
            Console.Write("+");
        }

        public void CentralizarMensagem(int ci, int cf, int lin, string mensagem)
        {
            int larguraTela = cf - ci + 1;
            int comprimentoMensagem = mensagem.Length;

            int espacosAntes = larguraTela/2 - comprimentoMensagem/2;


            Console.SetCursorPosition(ci + espacosAntes , lin);
            Console.Write(mensagem);
        }


        public string MostrarMenu(List<string> menu, int ci, int li,int dif)
        {
            int cf, lf, x;
            string op;

            // calcula a coluna final e linha final
            cf = ci + menu[0].Length + 94 - dif;
            lf = li + menu.Count() + 2;

            // monta a moldura do menu
            this.MontarMoldura(ci, li, cf, lf);

            // mostra as opções do menu
            for (x = 0; x < menu.Count(); x++)
            {
                Console.SetCursorPosition(ci + 1, li + x + 1);
                Console.Write(menu[x]);
            }
            Console.SetCursorPosition(ci + 1, li + x + 1);
            Console.Write("Opção : ");
            op = Console.ReadLine();
            return op;
        }
    }
}
