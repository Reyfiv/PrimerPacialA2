using Entities;
using System.Data.Entity;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Deposito> Deposito { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
