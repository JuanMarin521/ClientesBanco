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
        public string Beneficio { get; private set; }

        #region Metodos
        public CorporativeClient(string name, string id, decimal balance) : base(name, id, balance)
        {
            //Se verifica si el cliente tiene acceso a línea de crédito
            VerifyAccessCredit();

        }

        public void VerifyAccessCredit()
        {
            //Se verifica si el cliente es corporativo con un balance mayor a 50,000,000
            isCorporativeClient = Balance >= 50000000;
            Beneficio = CalcularBeneficio(); // Guardamos el beneficio

        }

        public override string CalcularBeneficio()
        {
            return isCorporativeClient
                ? "Cliente corporativo con acceso a línea de crédito"
                : "Cliente corporativo sin acceso a línea de crédito";
        }
        #endregion
    }
}
