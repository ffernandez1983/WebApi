using System;

namespace RestTest.Controllers.v1
{
    public class VMUsuario
    {
        public string DNI { get; set; }

        public string Nombre { get; set; }

        public string Apellido1 { get; set; }

        public string Apellido2 { get; set; }

        public string Direccion { get; set; }

        public string Pais { get; set; }

        public string CodigoPostal { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }
}