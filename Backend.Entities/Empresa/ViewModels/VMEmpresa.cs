using Backend.Entities.Facturacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities.DatosEmpresa
{
    public class VMEmpresa
    {      

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
     
    }
}
