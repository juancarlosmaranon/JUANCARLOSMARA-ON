﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JUANCARLOSMARAÑON.Model
{
    public class Cliente
    {
        public List<Pedido> Pedidos { get; set; }
        public string CodigoCliente { get; set; }
        public string Empresa { get; set; }
        public string Contacto { get; set; }
        public string Cargo { get; set; }
        public string Ciudad { get; set; }
        public int Telefono { get; set; }
    }
}
