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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasMany(x => x.Tags)
                .WithMany(x => x.Items)
                .Map(x => 
                    {
                        x.ToTable("ItemTagMaps");
                        x.MapLeftKey("ItemId");
                        x.MapRightKey("TagId");
                    });               
        }
    }
}
