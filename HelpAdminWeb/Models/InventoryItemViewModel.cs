using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpAdminWeb.Models
{
    public class InventoryItemViewModel
    {
        public int InventoryItemID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string SerialNumber { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
    }
}