using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PedidoCigarro.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoCigarro.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("PedidosPAR") {}

        public DbSet<Cigarro> Cigarro { get; set; }
        public DbSet<Corredor> Corredor { get; set; }
        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<PedidoCigarro.Models.Login> Logins { get; set; }


        // Muda todos os nvarchar pra varchar pra não fica lento pra caralho,
        // só Deus sabe o que isso faz isso tudo faz 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties().Where(x => x.PropertyType.FullName.Equals("System.String") &&
                !x.GetCustomAttributes(false).OfType<ColumnAttribute>().Where(q => q.TypeName != null && q.TypeName.Equals("varchar", StringComparison.InvariantCultureIgnoreCase)).Any())
                .Configure(c => c.HasColumnType("varchar").HasMaxLength(255));
        }


    }
}