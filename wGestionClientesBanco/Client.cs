using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wGestionClientesBanco
{
    public abstract class Client {
        //Nombre de la persona, se puede acceder y modificar
        public string Name { get; set; }

        //Cedula de la persona, se puede acceder y modificar
        public string ID { get; set; }

        //Saldo de la persona, se puede acceder y modificar
        public decimal Balance { get; set; }

        #region Metodos
        //Constructor de la clase
        protected Client(string name, string id, decimal balance)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("El nombre no puede ser nulo o vacio");
            }
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("La cedula no puede ser nula o vacia");
            }
            if (balance <= 0)
            {
                throw new ArgumentOutOfRangeException("El saldo no puede ser negativo");
            }
            Name = name;
            ID = id;
            Balance = balance;


        }

        public virtual void ActualizarSaldo(decimal monto)
        {
            if (monto <= 0)
            {
                throw new ArgumentOutOfRangeException("El monto no puede ser negativo o cero");
            }
            Balance = monto;
        }

        public abstract string CalcularBeneficio();

        #endregion
    }
}
