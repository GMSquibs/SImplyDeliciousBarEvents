using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SimplyDeliciousBarEvents.Models;

namespace SimplyDeliciousBarEvents.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public ApplicationDbContext()
        {

        }
        public DbSet<SimplyDeliciousBarEvents.Models.ClientModel> ClientViewModel { get; set; }
        public DbSet<SimplyDeliciousBarEvents.Models.MenuModel> MenuViewModel { get; set; }
        public DbSet<SimplyDeliciousBarEvents.Models.EmployeeModel> EmployeeViewModel { get; set; }
        public DbSet<SimplyDeliciousBarEvents.Models.EventSheetModel> EventSheetViewModel { get; set; }
        public DbSet<SimplyDeliciousBarEvents.Models.EventModel> EventViewModel { get; set; }     
        public DbSet<SimplyDeliciousBarEvents.Models.LocationModel> LocationModel { get; set; }
        public DbSet<SimplyDeliciousBarEvents.Models.AddressModel> AddressModel { get; set; }
        public DbSet<SimplyDeliciousBarEvents.Models.Invoice> Invoice { get; set; }
    }
}
