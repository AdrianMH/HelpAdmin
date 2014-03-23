using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpAdminWeb.Models
{
    public class ClientContractViewModel
    {
        public int ClientContractID { get; set; }
        public int ClientID { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public Nullable <decimal> Ammount { get; set; }
        public Nullable <decimal> AdditionalAmmount { get; set; }
    }
}