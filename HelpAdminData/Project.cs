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
    
    public partial class Project
    {
        public Project()
        {
            this.ProjectInformation = new HashSet<ProjectInformation>();
        }
    
        public int ProjectID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<ProjectInformation> ProjectInformation { get; set; }
    }
}