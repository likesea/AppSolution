//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SysLog
    {
        public string Id { get; set; }
        public string Operator { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string Type { get; set; }
        public string Module { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
    }
}
