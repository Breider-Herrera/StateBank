//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BancoEstatal.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class sedes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sedes()
        {
            this.empleados = new HashSet<empleados>();
        }
    
        public int seID { get; set; }
        public string seNombre { get; set; }
        public string seDireccion { get; set; }
        public string seTelefono { get; set; }
        public int seCiudad_fk { get; set; }
    
        public virtual ciudades ciudades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empleados> empleados { get; set; }
    }
}
