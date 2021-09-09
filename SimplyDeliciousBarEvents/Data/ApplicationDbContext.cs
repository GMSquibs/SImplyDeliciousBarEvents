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
        public DbSet<SimplyDeliciousBarEvents.Models.ClientViewModel> ClientViewModel { get; set; }
        public DbSet<SimplyDeliciousBarEvents.Models.MenuViewModel> MenuViewModel { get; set; }
        public DbSet<SimplyDeliciousBarEvents.Models.EmployeeViewModel> EmployeeViewModel { get; set; }
        public DbSet<SimplyDeliciousBarEvents.Models.EventSheetViewModel> EventSheetViewModel { get; set; }
        public DbSet<SimplyDeliciousBarEvents.Models.EventViewModel> EventViewModel { get; set; }
    }
}
