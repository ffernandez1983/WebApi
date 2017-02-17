using Backend.Entities.Facturacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities.DatosCliente
{
    public class Empresa
    {
        public Empresa()
        {
            Presupuestos = new HashSet<Presupuesto>();
            Pedidos = new HashSet<Pedido>();
            Facturas = new HashSet<Factura>();
            Albaranes = new HashSet<Albaran>();
        }

        [Key]
        public int IDEmpresa { get; set; }       

        public string CIF { get; set; }

        public string RazonSocial { get; set; }

        public string Direccion { get; set; }

        public string Pais { get; set; }

        public string CodigoPostal { get; set; }

        public string FormaJuridica { get; set; }

        public string Nombre { get; set; }

        public string Apellido1 { get; set; }

        public string Apellido2 { get; set; }

        public string DNI { get; set; }

        public DateTime FechaNacimiento { get; set; } 

        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Presupuesto> Presupuestos { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Albaran> Albaranes { get; set; }
    }
}
