//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Raktar
{
    using System;
    using System.Collections.Generic;
    
    public partial class Felhasznalok
    {
        public int id { get; set; }
        public string vezeteknev { get; set; }
        public string keresztnev { get; set; }
        public System.DateTime szulido { get; set; }
        public string adoazon { get; set; }
        public string taj { get; set; }
        public string irsz { get; set; }
        public string anyjaneve { get; set; }
        public decimal fizetes { get; set; }
    
        public virtual Város Város { get; set; }
    }
}
