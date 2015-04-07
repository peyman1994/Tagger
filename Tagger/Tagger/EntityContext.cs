using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TaggerNamespace.Model;

namespace TaggerNamespace.DAL
{
    public class EntityContext : DbContext
    {
        static EntityContext()
        {
            Database.SetInitializer<EntityContext>(new DropCreateDatabaseIfModelChanges<EntityContext>());
            using (EntityContext db = new EntityContext())
                db.Database.Initialize(false);
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ItemTagMap> ItemTagMap { get; set; }
    }
}
