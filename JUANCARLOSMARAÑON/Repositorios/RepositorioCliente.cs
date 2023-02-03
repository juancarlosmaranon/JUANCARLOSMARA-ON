using JUANCARLOSMARAÑON.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JUANCARLOSMARAÑON.Model;

#region SP_CLIENTES
//CREATE PROCEDURE SP_CLIENTES
//AS
//	SELECT DISTINCT EMPRESA FROM CLIENTES
//GO
#endregion

#region SP_DATOS_CLIENTES
//CREATE PROCEDURE SP_DATOS_CLIENTES
//(@CLIENTE NVARCHAR(50))
//AS
//	SELECT * FROM CLIENTES
//	WHERE @CLIENTE = Empresa
//GO
#endregion

#region SP_PEDIDOS
//CREATE PROCEDURE SP_PEDIDOS
//(@CODCLIENTE NVARCHAR(50))
//AS
//	SELECT * FROM pedidos
//	WHERE @CODCLIENTE = CodigoCliente
//GO
#endregion

namespace JUANCARLOSMARAÑON.Repositorios
{
    public class RepositorioCliente
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader reader;

        public RepositorioCliente()
        {
            string connectionString = HelperConfiguration.GetConnectionString();
            this.cn = new SqlConnection(connectionString);
            this.cmd = new SqlCommand();
            this.cmd.Connection = this.cn;
        }

        //RECOGEMOS LOS CLIENTES
        public List<string> GetClientes()
        {
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_CLIENTES";
            List<string> clientes = new List<string>();
            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();
            while (this.reader.Read())
            {
                string cliente = this.reader["EMPRESA"].ToString();
                clientes.Add(cliente);
            }
            this.reader.Close();
            this.cn.Close();
            return clientes;
        }

        public Cliente GetDatosClientes(string cliente)
        {
            SqlParameter pamcliente = new SqlParameter("@CLIENTE", cliente);
            this.cmd.Parameters.Add(pamcliente);
            Cliente client = new Cliente();
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_DATOS_CLIENTES";
            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();
            while (this.reader.Read())
            {
                string clientenom = this.reader["EMPRESA"].ToString();
                string contacto = this.reader["CONTACTO"].ToString();
                string cargo = this.reader["CARGO"].ToString();
                string ciudad = this.reader["CIUDAD"].ToString();
                int telefono = int.Parse(this.reader["TELEFONO"].ToString());
                client = new Cliente(){ Empresa = clientenom, Contacto = contacto, Cargo = cargo, Ciudad = ciudad, Telefono = telefono };
            }
            this.cmd.Parameters.Clear();
            this.reader.Close();
            this.cn.Close();
            return client;
        }

        public List<Pedido> GetPedido(string codcliente)
        {
            SqlParameter pamcodcliente = new SqlParameter("@CODCLIENTE", codcliente);
            this.cmd.Parameters.Add(pamcodcliente);
            List<string> pedidos = new List<string>();
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_PEDIDOS";
            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();
            while (this.reader.Read())
            {
                //string codigopedidos = this.reader["CodigoPedido"].ToString();
                string codigocliente = this.reader["CodigoCliente"].ToString();
                //string fechaentrega = this.reader["FechaEntrega"].ToString();
                //string formaenvio = this.reader["FormaEnvio"].ToString();
                //int importe = int.Parse(this.reader["Importe"].ToString());
                pedidos.Add(codigocliente);
            }
            this.cmd.Parameters.Clear();
            this.reader.Close();
            this.cn.Close();
            return pedidos;
        }
    }
    
}
