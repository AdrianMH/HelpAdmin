using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpAdminWeb.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime NextMedicalExam { get; set; }
    }
}