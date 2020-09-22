using System;
using Id.Overview.Mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Id.Overview.Mvc.Data {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid> {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) {

        }
    }
}