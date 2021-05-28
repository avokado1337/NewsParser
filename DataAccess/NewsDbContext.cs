using DataAccess.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace News_Parser
{
    public class NewsDbContext : IdentityDbContext<ApplicationUser>
    {
        public NewsDbContext()
        {
        }

        public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options)
        {

        }
        public DbSet<NewsModel> News { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=NewsApiDb;Trusted_Connection=True;");
        //}


    }
}
