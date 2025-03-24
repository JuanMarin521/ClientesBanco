using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wGestionClientesBanco
{
    internal class PersonFactory
    {
        public static Person CreatePerson(string name, string id, decimal balance, bool isCorporativeClient)
        {
            if (isCorporativeClient)
            {
                return new CorporativeClient(name, id, balance, isCorporativeClient);
            }
            else
            {
                return new IndividualClient(name, id, balance, 1);
            }
        }
    }
}
