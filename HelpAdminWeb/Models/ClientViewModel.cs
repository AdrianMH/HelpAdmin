using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpAdminWeb.Models
{
    public class ClientViewModel
    {
        public int ClientID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Url { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Details { get; set; }
    }
}