using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpAdminWeb.Models
{
    public class ProjectInformationViewModel
    {
        public int ProjectInformationID { get; set; }
        public int ProjectID { get; set; }
        public string Description { get; set; }
    }
}