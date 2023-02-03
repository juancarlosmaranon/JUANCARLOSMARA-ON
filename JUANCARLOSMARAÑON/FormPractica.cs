using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JUANCARLOSMARAÑON.Repositorios;
using JUANCARLOSMARAÑON.Model;

namespace JUANCARLOSMARAÑON
{
    public partial class FormPractica : Form
    {
        public RepositorioCliente RepositorioCliente;
        public FormPractica()
        {
            InitializeComponent();
            RepositorioCliente = new RepositorioCliente();
            var clientes = this.RepositorioCliente.GetClientes();
            this.LoadClientes();
        }

        private void cmbclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadDatosCliente();
            this.LoadPedidos();
        }

        private void LoadClientes()
        {
            List<string> clientes = this.RepositorioCliente.GetClientes();
            foreach (var cliente in clientes)
            {
                this.cmbclientes.Items.Add(cliente);
            }
        }

        private void LoadDatosCliente()
        {
            if(this.cmbclientes.SelectedIndex != -1)
            {
                string nombreEmpresa  = this.cmbclientes.SelectedItem.ToString();
                Cliente cliente = RepositorioCliente.GetDatosClientes(nombreEmpresa);
                this.txtempresa.Text = cliente.Empresa.ToString();
                this.txtcontacto.Text = cliente.Contacto;
                this.txtcargo.Text = cliente.Cargo;
                this.txtciudad.Text = cliente.Ciudad;
                this.txttelefono.Text = cliente.Telefono.ToString();
                this.txtCodigoCliente.Text = cliente.CodigoCliente;
            }
        }

        private void LoadPedidos()
        {
            //string codpedido = this.txtcodigopedido.Text;
            //List<string> pedido = this.RepositorioCliente.GetPedido();
            //foreach (var pedid in pedido)
            //{
            //    this.lstpedidos.Items.Add(pedid);
            //}
        }

        private void txtempresa_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void lstpedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
