using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudForm
{
    public partial class CrudForm : System.Windows.Forms.Form
    {
        public Boolean Adding = false;
        List<Contact> Contacts = new List<Contact>();
        public CrudForm()
        {
            InitializeComponent();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            EmptyControls();
            EnableControls(true);
            Adding = true;
            txtID.Text = Guid.NewGuid().ToString();
            btnAñadir.Enabled = false;
            btnBorrar.Enabled = false;
            btnCargar.Enabled = false;
        }

        private void EmptyControls()
        {
            txtID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtID.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtPais.Text = string.Empty;
        }

        private void EnableControls(bool enabled)
        {
            txtNombre.Enabled = enabled;
            txtApellido.Enabled = enabled;
            txtID.Enabled = enabled;
            txtDireccion.Enabled = enabled;
            txtCiudad.Enabled = enabled;
            txtCorreo.Enabled = enabled;
            txtCelular.Enabled = enabled;
            txtPais.Enabled = enabled;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (Adding == true)
            {
                //Se añade un nuevo registro
                var contact = new Contact
                {
                    ID = txtID.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Dirrecion = txtDireccion.Text,
                    Ciudad = txtCiudad.Text,
                    Pais = txtPais.Text,
                    Celular = txtCelular.Text,
                    Correo = txtCorreo.Text,
                };

                Contacts.Add(contact);

                MessageBox.Show("Contacto Registrado.");

                EmptyControls();
                EnableControls(false);

                btnAñadir.Enabled = true;
                btnBorrar.Enabled = true;
                btnActualizar.Enabled = true;

                GetContacts();

            }
            else
            {
                //se actualiza un registro ya existente
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            GetContacts();
        }

        private void GetContacts()
        {
            DGVContacts.DataSource = null;
            DGVContacts.DataSource = Contacts;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Contacts.RemoveAt(0);
            DGVContacts.DataSource = null;
            MessageBox.Show("Registro Borrado.");
            DGVContacts.DataSource = Contacts;
        }
    }

    public class Contact
    {
        public string ID { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Dirrecion { get; set; }

        public string Pais { get; set; }

        public string Ciudad { get; set; }

        public string Celular { get; set; }

        public string Correo { get; set; }

    }
}
