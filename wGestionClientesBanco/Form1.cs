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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string id = txtID.Text;
            decimal balance = decimal.Parse(txtBalance.Text);

            if (string.IsNullOrEmpty(name)){
                MessageBox.Show("El nombre no puede ser nulo o vacio");
            }
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("La cedula no puede ser nula o vacia");
            }
            if (balance <= 0)
            {
                MessageBox.Show("El saldo no puede ser negativo o cero");
            }
            try
            {
                Person person = PersonFactory.CreatePerson(name, id, balance, false);
                GestorPerson.Instance.agregarPerson(person);
                MessageBox.Show("Persona agregada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
