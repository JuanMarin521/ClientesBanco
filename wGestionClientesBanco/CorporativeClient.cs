using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace wGestionClientesBanco
{
    public class CorporativeClient : Client
    {
        public bool isCorporativeClient { get; set; }

        #region Metodos
        public CorporativeClient(string name, string id, decimal balance) : base(name, id, balance)
        {
            //Se verifica si el cliente es corporativo
            VerifyAccessCredit();

        }

        public void VerifyAccessCredit()
        {
            //Se verifica si el cliente es corporativo con un balance mayor a 50,000,000
            if (Balance >= 50000000)
            {
                isCorporativeClient = true;
                CalcularBeneficio();
            }
            else
            {
                isCorporativeClient = false;
                CalcularBeneficio();
            }

        }

        public override string CalcularBeneficio()
        {
            return isCorporativeClient
            ? "Cliente con acceso a línea de crédito."
            : "No cumple con el saldo mínimo para línea de crédito.";

        }
        #endregion
    }
}
