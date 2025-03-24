using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wGestionClientesBanco
{
    public class IndividualClient : Person
    {
        public int cuentasActivas { get; set; }
        public IndividualClient(string name, string id, decimal balance, int cuentasActivas) : base(name, id, balance)
        {
            if (cuentasActivas > 3)
            {
                throw new ArgumentOutOfRangeException("No se pueden tener mas de 3 cuentas activas");
            }
            else
            {
                this.cuentasActivas = cuentasActivas;


            }

        }
    }

    
}
