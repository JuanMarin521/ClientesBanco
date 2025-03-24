using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wGestionClientesBanco
{
    public class CorporativeClient : Person
    {
        public bool isCorporativeClient { get; set; }
        public CorporativeClient(string name, string id, decimal balance, bool isCorporativeClient): base (name, id, balance)
        {
            //Si el saldo es mayor o igual a 50 millones, es un cliente corporativo
            if (balance >= 50000000)
            {
                isCorporativeClient = true;
            }

           
        }
    }
}
