//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HelpAdminData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        public Client()
        {
            this.Contact = new HashSet<Contact>();
            this.InventoryItem = new HashSet<InventoryItem>();
        }
    
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Nullable<int> ContactID { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Details { get; set; }
    
        public virtual ICollection<Contact> Contact { get; set; }
        public virtual ICollection<InventoryItem> InventoryItem { get; set; }
    }
}
