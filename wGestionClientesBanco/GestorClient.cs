using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wGestionClientesBanco
{
    internal class GestorClientes
    {
        private static GestorClientes _instance;
        private List<Client> _clientes;

        private GestorClientes()
        {
            _clientes = new List<Client>();
        }

        public static GestorClientes Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GestorClientes();
                }
                return _instance;
            }
        }

        #region Metodos
        public void agregarPerson(Client person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("La persona no puede ser nula");
            }
            //Validar que la persona no exista en la lista de personas antes de agregarla
            if (_clientes.Exists(x => x.ID == person.ID))
            {
                throw new InvalidOperationException("La persona ya existe");
            }
            //Agregar la persona a la lista de personas
            _clientes.Add(person);

        }
        public void EliminarCliente(string id)
        {
            //Buscar la persona en la lista de personas
            Client cliente = _clientes.FirstOrDefault(c => c.ID == id);

            if (cliente == null)
            {
                throw new InvalidOperationException("No se encontró un cliente con esta identificación.");
            }
            //Eliminar la persona de la lista
            _clientes.Remove(cliente);
        }
        public void EditarCliente(string id, string nuevoNombre, decimal nuevoSaldo)
        {
            //Buscar la persona en la lista de personas
            Client cliente = _clientes.FirstOrDefault(c => c.ID == id);
            //Validar que la persona exista
            if (cliente == null)
            {
                throw new InvalidOperationException("No se encontró un cliente con esta identificación.");
            }
            //Validar que el nombre no sea nulo o vacío y que el saldo sea mayor a 0
            if (string.IsNullOrEmpty(nuevoNombre) || nuevoSaldo <= 0)
            {
                throw new ArgumentException("El nombre no puede estar vacío y el saldo debe ser mayor a 0.");
            }

            cliente.Name = nuevoNombre;
            cliente.Balance = nuevoSaldo;
        }


        #endregion


        public List<Client> getClientes()
        {
            return new List<Client>(_clientes);
        }

    }
}
