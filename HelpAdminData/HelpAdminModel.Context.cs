﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HelpAdminEntities : DbContext
    {
        public HelpAdminEntities()
            : base("name=HelpAdminEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<InventoryItem> InventoryItem { get; set; }
        public virtual DbSet<InventoryCategory> InventoryCategory { get; set; }
        public virtual DbSet<ItemGuarantee> ItemGuarantee { get; set; }
        public virtual DbSet<ClientContract> ClientContract { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectInformation> ProjectInformation { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
    }
}
