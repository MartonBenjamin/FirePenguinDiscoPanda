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
    
    public partial class Termék
    {
        public int id { get; set; }
        public string Megnevezés { get; set; }
        public int Súly_gramm { get; set; }
        public byte Raktáron { get; set; }
        public int Raktár { get; set; }
        public System.DateTime Beszállítva { get; set; }
        public Nullable<System.DateTime> Szavatosság { get; set; }
    }
}
