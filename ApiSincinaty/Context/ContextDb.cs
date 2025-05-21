using ApiSincinaty.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ApiSincinaty.Context
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }

    }
}
