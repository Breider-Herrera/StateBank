using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoEstatal.Model
{
    public class EmpleadosDTO
    {
        public string emCedula { get; set; }
        public string emNombre { get; set; }
        public string emApellido { get; set; }
        public string emCorreo { get; set; }
        public string emDireccion { get; set; }
        public string emTelefono { get; set; }
        public byte[] emFoto { get; set; }


        public string geGenero { get; set; }
        public string caCargo { get; set; }
        public string seSedes { get; set; }
    }
}
