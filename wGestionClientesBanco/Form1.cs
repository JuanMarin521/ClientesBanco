using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wGestionClientesBanco
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region buttons
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string id = txtID.Text;
            decimal balance = decimal.Parse(txtBalance.Text);

            if (string.IsNullOrEmpty(name)) {
                MessageBox.Show("El nombre no puede ser nulo o vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("La cedula no puede ser nula o vacia");
            }
            //Validar que el saldo sea un número positivo mayor a 0 
            if (!decimal.TryParse(txtBalance.Text, out balance) || balance <= 0)
            {
                MessageBox.Show("El saldo debe ser un número positivo");

            }

            try
            {
                Client person = ClientFactory.CrearCliente(name, id, balance); // Crear la persona
                GestorClientes.Instance.agregarPerson(person); // Agregar la persona a la lista de personas
                MessageBox.Show($"Cliente agregado correctamente como {person.GetType().Name}");
                ActualizarListaClientes(); // Actualizar la lista de clientes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string id = txtID.Text;
            decimal balance = decimal.Parse(txtBalance.Text);

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("El nombre no puede ser nulo o vacio");
            }
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("La cedula no puede ser nula o vacia");
            }
            if (!decimal.TryParse(txtBalance.Text, out balance) || balance <= 0)
            {
                MessageBox.Show("El saldo debe ser un número positivo");

            }
            try
            {

                GestorClientes.Instance.EliminarCliente(id); // Agregar la persona a la lista de personas 
                MessageBox.Show("Persona eliminada correctamente"); // Mostrar mensaje de éxito
                ActualizarListaClientes(); // Actualizar la lista de clientes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string id = txtID.Text;
            decimal balance = decimal.Parse(txtBalance.Text);
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("El nombre no puede ser nulo o vacio");
            }
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("La cedula no puede ser nula o vacia");
            }
            if (!decimal.TryParse(txtBalance.Text, out balance) || balance <= 0)
            {
                MessageBox.Show("El saldo debe ser un número positivo");

            }
            try
            {
                GestorClientes.Instance.EditarCliente(id, name, balance); // Agregar la persona a la lista de personas
                MessageBox.Show("Persona editada correctamente"); // Mostrar mensaje de éxito
                ActualizarListaClientes(); // Actualizar la lista de clientes

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ListarClientes();
        }

        #endregion

        #region Voids
        private void ListarClientes()
        {
            listBoxUsers.Items.Clear(); // Limpiar la lista antes de actualizar

            List<Client> clientes = GestorClientes.Instance.getClientes(); // Obtener la lista
            // Validar que existan personas en la lista
            if (clientes.Count == 0)
            {
                MessageBox.Show("No hay clientes registrados.");
                return;
            }

            // Recorrer la lista de personas
            foreach (Client cliente in clientes)
            {
                listBoxUsers.Items.Add($"{cliente.ID} - {cliente.Name} - Saldo: {cliente.Balance:C}");
            }
        }
        private void ActualizarListaClientes()
        {
            listBoxUsers.Items.Clear(); // Limpiar la lista antes de actualizar

            List<Client> clientes = GestorClientes.Instance.getClientes(); // Obtener la lista de personas

            foreach (var cliente in clientes) // Recorrer la lista de personas
            {
                // Agregar la persona a la lista de personas en el ListBox 
                listBoxUsers.Items.Add($"{cliente.ID} - {cliente.Name} - Saldo: {cliente.Balance:C}");
            }

        }

        #endregion
    }
}


    