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

            DataTable existeCpf = ClienteModel.BuscarClientePorCPF(cpfTratado);
            if (existeCpf != null && existeCpf.Rows.Count > 0)
            {
                throw new Exception("Já existe um cliente com este CPF");
            }

            ClienteModel.AdicionarCliente(cpfTratado, nome, telefoneTratado);
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

            DataTable existeCpf = ClienteModel.BuscarClientePorCPF(cpfTratado);
            if (existeCpf != null && existeCpf.Rows.Count > 0)
            {
                throw new Exception("Já existe um cliente com este CPF");
            }

            ClienteModel.EditarCliente(idLocatario, cpfTratado, nome, telefoneTratado);
        }

        public DataTable ListarClientes()
        {
            return ClienteModel.ListarClientes();
        }

        public DataTable BuscarClientePorID(int idCliente)
        {
            return ClienteModel.BuscarClientePorID(idCliente);
        }

        public DataTable BuscarClientePorCPF(string cpfLocatario)
        {
            string cpfTratado = cpfLocatario.Replace(" ", "").Replace(".", "").Replace("-", "");
            return ClienteModel.BuscarClientePorCPF(cpfTratado);
        }
    }
}
