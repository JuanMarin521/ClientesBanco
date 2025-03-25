using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wGestionClientesBanco
{
    internal class ClientFactory
    {
        public static Client CrearCliente(string name, string id, decimal balance, string type)
        {
            if (type== "Cliente Individual")
            {
                return new IndividualClient(name, id, balance);
            }
            else if (type == "Cliente Corporativo")
            {
                return new CorporativeClient(name, id, balance);
            }
            else
            {
                throw new ArgumentException("Tipo de cliente no válido");
            }
        }
    }
}
