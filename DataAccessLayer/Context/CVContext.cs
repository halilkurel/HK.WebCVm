using EntityLayer.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class CVContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public CVContext(DbContextOptions<CVContext> options) : base(options)
        {
            
        }
        public DbSet<Header> Headers { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
