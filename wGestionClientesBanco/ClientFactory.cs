using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wGestionClientesBanco
{
    internal class ClientFactory
    {
        public static Client CrearCliente(string name, string id, decimal balance, int cuentasActivas = 1)
        {
            if (balance >= 50000000)
            {
                return new CorporativeClient(name, id, balance);
            }
            else
            {
                return new IndividualClient(name, id, balance);
            }
        }
    }
}
