using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wGestionClientesBanco
{
    internal class GestorPerson
    {
        private static GestorPerson _isntance;
        private List<Person> _clientes;

        private GestorPerson()
        {
            _clientes = new List<Person>();
        }

        public static GestorPerson Instance
        {
            get
            {
                if (_isntance == null)
                {
                    _isntance = new GestorPerson();
                }
                return _isntance;
            }
        }

        public void agregarPerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("La persona no puede ser nula");
            }
            _clientes.Add(person);
        }

        public List<Person> getClientes()
        {
            return _clientes;
        }
    }
}
