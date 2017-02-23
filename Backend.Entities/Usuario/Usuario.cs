using Backend.Entities.DatosEmpresa;
using Backend.Entities.Facturacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities.DatosUsuario
{
    public class Usuario
    {
        public Usuario()
        {           
            Empresas = new HashSet<Empresa>();
        }

        [Key]
        [Column("IDUsuario", Order = 0)]
        public int IDUsuario { get; set; }       

        public string DNI { get; set; }

        public string Nombre { get; set; }

        public string Apellido1 { get; set; }

        public string Apellido2 { get; set; }

        public string Direccion { get; set; }

        public string Pais { get; set; }

        public string CodigoPostal { get; set; }


        public DateTime FechaNacimiento { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }

    }
}
