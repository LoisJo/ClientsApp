//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientsApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientsTable
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Nullable<int> Age { get; set; }
        public string Gender { get; set; }
        public Movy movy;
    }
}