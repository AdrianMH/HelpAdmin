using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpAdminWeb.Models
{
    public class InventoryItemViewModel
    {
        public int InventoryItemID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Details { get; set; }
        public string SerialNumber { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string Code { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        public int GuaranteeID { get; set; }
    }
}