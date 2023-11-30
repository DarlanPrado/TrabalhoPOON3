using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPOON3.Model;

namespace TrabalhoPOON3.Controller
{
    public class LocatarioController
    {
        public void adicionarLocatario(string cpfLocatario, string nome, string telefone)
        {
            string cpfTratado = cpfLocatario.Replace(" ", "").Replace(".", "").Replace("-", "");
            string telefoneTratado = telefone.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");

            if (cpfTratado.Length != 11)
            {
                throw new Exception("Numero de CPF invalido");
            }
            if (telefoneTratado.Length != 10)
            {
                throw new Exception("Numero de telefone invalido");
            }

            DataTable existeCpf = LocatarioModel.BuscarLocatarioPorCPF(cpfTratado);
            if (existeCpf != null && existeCpf.Rows.Count > 0)
            {
                throw new Exception("Já existe um Locatario com este CPF");
            }

            LocatarioModel.AdicionarLocatario(cpfTratado, nome, telefoneTratado);
        }

        
        public void editarLocatario(int idLocatario, string cpf, string nome, string telefone)
        {
            string cpfTratado = cpf.Replace(" ", "").Replace(".", "").Replace("-", "");
            string telefoneTratado = telefone.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");

            if (cpfTratado.Length != 11)
            {
                throw new Exception("Numero de CPF invalido");
            }
            if (telefoneTratado.Length != 10)
            {
                throw new Exception("Numero de telefone invalido");
            }

            DataTable existeCpf = LocatarioModel.BuscarLocatarioPorCPF(cpfTratado);
            if (existeCpf != null && existeCpf.Rows.Count > 0)
            {
                throw new Exception("Já existe um Locatario com este CPF");
            }

            LocatarioModel.EditarLocatario(idLocatario, cpfTratado, nome, telefoneTratado);
        }

        public DataTable ListarLocatario()
        {
            return LocatarioModel.ListarLocatarios();
        }

        public DataTable BuscarLocatarioPorID(int idLocatario)
        {
            return  LocatarioModel.BuscarLocatarioPorID(idLocatario);
        }

        public DataTable BuscarLocatarioPorCPF(string cpfLocatario)
        {
            string cpfTratado = cpfLocatario.Replace(" ", "").Replace(".", "").Replace("-", "");
            return LocatarioModel.BuscarLocatarioPorCPF(cpfTratado);
        }
    }
}
