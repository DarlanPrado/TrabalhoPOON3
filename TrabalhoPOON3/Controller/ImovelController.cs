using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPOON3.Model;

namespace TrabalhoPOON3.Controller
{
    public class ImovelController
    {
        public static void AdicionarImovel(string cpfCliente, string TipoImovel, double valor, bool disponivel)
        {
            string cpfTratado = cpfCliente.Replace(" ", "").Replace(".", "").Replace("-", "");
            if (cpfTratado.Length != 11)
            {
                throw new Exception("Numero de CPF invalido");
            }

            DataTable cliente = ClienteModel.BuscarClientePorCPF(cpfTratado);

            if (cliente.Rows.Count > 0)
            {
                string idCliente = cliente.Rows[0]["ID_CLIENTE"].ToString();
                ImovelModel.AdicionarImovel(idCliente, TipoImovel, valor, disponivel);
            }
            else
            {
                throw new Exception("Cliente não encontrado com o CPF fornecido");
            }
        }

        public static void AdicionarImovelAoCliente(string cpfCliente, string idImovel)
        {
            string cpfTratado = cpfCliente.Replace(" ", "").Replace(".", "").Replace("-", "");
            if (cpfTratado.Length != 11)
            {
                throw new Exception("Numero de CPF invalido");
            }

            DataTable cliente = ClienteModel.BuscarClientePorCPF(cpfTratado);
            if (cliente.Rows.Count > 0)
            {
                string idCliente = cliente.Rows[0]["ID_CLIENTE"].ToString();
                DataTable clientePossuiImovel = ImovelModel.ListarImoveisDoCiente(idCliente);

                foreach (System.Data.DataRow row in clientePossuiImovel.Rows)
                {
                    if(row["ID_IMOVEL"].ToString() == idImovel)
                    {
                        throw new Exception("O cliente já possui este imovel");
                        //Verificar se ele é o propietario atual, se nao, alterar a posse
                    }
                }

                ImovelModel.AdicionarImovelAoCliente(idImovel, idCliente);
            }
            else
            {
                throw new Exception("Cliente não encontrado com o CPF fornecido");
            }
        }

        public static void EditarImovel(string idImovel, string TipoImovel, double valor, bool disponivel)
        {
            ImovelModel.EditarImovel(idImovel, TipoImovel, valor, disponivel);
        }

        public static DataTable ListarImoveisDoCiente(string cpfCLiente)
        {
            string cpfTratado = cpfCLiente.Replace(" ", "").Replace(".", "").Replace("-", "");
            if (cpfTratado.Length != 11)
            {
                throw new Exception("Numero de CPF invalido");
            }

            DataTable cliente = ClienteModel.BuscarClientePorCPF(cpfTratado);

            if (cliente.Rows.Count > 0)
            {
                string idCliente = cliente.Rows[0]["ID_CLIENTE"].ToString();
                return ImovelModel.ListarImoveisDoCiente(idCliente);
            }
            else
            {
                throw new Exception("Cliente não encontrado com o CPF fornecido");
            }
        }

        public static DataTable BuscarImovelPorID(int idImovel)
        {
            return ImovelModel.BuscarImovelPorID(idImovel);
        }
    }
}
