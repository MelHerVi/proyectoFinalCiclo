//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gestion_Documental.Modelo.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class empresa
    {
        public empresa()
        {
            this.centrotrabajo = new HashSet<centrotrabajo>();
            this.documentos = new HashSet<documentos>();
        }
    
        public int id_empresa { get; set; }
        public string razon_social { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string CIF { get; set; }
        public string localidad { get; set; }
        public string provincia { get; set; }
        public Nullable<int> fax { get; set; }
        public Nullable<int> cp { get; set; }
        public Nullable<int> id_responsable { get; set; }
    
        public virtual ICollection<centrotrabajo> centrotrabajo { get; set; }
        public virtual ICollection<documentos> documentos { get; set; }
        public virtual responsable responsable { get; set; }
    }
}
