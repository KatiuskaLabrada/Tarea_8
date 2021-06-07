using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Tarea_8
{
    public partial class Form1 : Form
    {
        long document, searchValue;
        string name, lastName;
        Boolean insert, update;
        public Form1()
        {
            InitializeComponent();
            groupBoxNewUser.Visible = false;
            txtSearch.Visible = false;
            pbSearch.Visible = false;
        }

        private void usuarioBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usuarioBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.usuariosDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'usuariosDataSet.Usuario' table. You can move, or remove it, as needed.
            this.usuarioTableAdapter.Fill(this.usuariosDataSet.Usuario);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            this.clearData();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            groupBoxNewUser.Visible = true;
            insert = true;
            update = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.clearData();
            groupBoxNewUser.Visible = false;
        }

        public void clearData() 
        {
            txtDocumentNumber.Clear();
            txtUserName.Clear();
            txtUserLastName.Clear();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            txtSearch.Visible = true;
            pbSearch.Visible = true;
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            searchValue = Convert.ToInt64(txtSearch.Text);
            this.usuarioTableAdapter.Consulta(this.usuariosDataSet.Usuario, searchValue);
            groupBoxNewUser.Visible = true;
            insert = false;
            update = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            document = Convert.ToInt64(txtDocumentNumber.Text);
            name = txtUserName.Text;
            lastName = txtUserLastName.Text;

            if (insert)
            {
                this.usuarioTableAdapter.Insertar(document, name, lastName);
                this.usuarioTableAdapter.Fill(this.usuariosDataSet.Usuario);
            }
            else if (update)
            {
                this.usuarioTableAdapter.Actualizar(document, name, lastName);
                this.usuarioTableAdapter.Fill(this.usuariosDataSet.Usuario);
            }


        }
    }
}
