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
    
    public partial class InventoryItem
    {
        public int InventoryItemID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string SerialNumber { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual InventoryCategory InventoryCategory { get; set; }
    }
}
