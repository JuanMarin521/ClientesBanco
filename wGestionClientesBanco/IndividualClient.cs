using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wGestionClientesBanco
{
    public class IndividualClient : Client
    {
        //Numero de cuentas activas del cliente, inicia con 1 cuenta activa
        public int cuentasActivas { get; set; } = 1;

        #region Metodos
        public IndividualClient(string name, string id, decimal balance, int cuentasActivas= 1) : base(name, id, balance)
        {
            if (cuentasActivas > 3)
            {
                throw new ArgumentOutOfRangeException("No se pueden tener mas de 3 cuentas activas");
            }
           
                this.cuentasActivas = cuentasActivas;

        }
        //Metodo para calcular el beneficio del cliente, este metodo es sobreescrito de la clase padre Person
        public override string CalcularBeneficio()
        {
            //Si el cliente tiene menos de 3 cuentas activas, puede abrir mas cuentas
            return cuentasActivas < 3 ? "Cliente puede abrir mas cuentas" : "Limite de cuentas alcanzadas";
        }

        //Metodo para agregar una cuenta
        public void AgregarCuenta()
        {
            if (cuentasActivas >= 3)
            {
                throw new InvalidOperationException("No se pueden tener mas de 3 cuentas activas");
            }
            cuentasActivas++;
        }
        //Metodo para cerrar una cuenta
        public void CerrarCuenta()
        {
            if (cuentasActivas <= 1)
            {
                throw new InvalidOperationException("No se pueden tener menos de 1 cuenta activa");
            }
            cuentasActivas--;
        }
        #endregion

    }


}
