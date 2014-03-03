using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpAdminWeb.Models
{
    public class ContactViewModel
    {
        public int ContactID { get; set; }
        public int ClientID { get; set; }

        [Required]
        public string Surname { get; set; }
        [Required]
        public string Forename { get; set; }

        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Details { get; set; }
    }
}