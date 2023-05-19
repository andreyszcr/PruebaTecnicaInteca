using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntities
{
    public class EPersona
    {
        // Propiedad para almacenar la cédula de la persona
        public int CedulaPersona { get; set; }

        // Propiedad para almacenar la dirección de la persona
        public string Direccion { get; set; }

        // Propiedad para almacenar el teléfono de la persona
        public int Telefono { get; set; }

        // Propiedad para almacenar la fecha de nacimiento de la persona
        public DateTime FechaNacimiento { get; set; }

        // Propiedad para almacenar el género de la persona
        public string Genero { get; set; }

        // Propiedad para almacenar el nombre de la persona
        public string Nombre { get; set; }

        // Propiedad para almacenar el primer apellido de la persona
        public string PrimerApellido { get; set; }

        // Propiedad para almacenar el segundo apellido de la persona
        public string SegundoApellido { get; set; }

        // Propiedad para almacenar el correo electrónico de la persona
        public string CorreoElectronico { get; set; }
    }
}
