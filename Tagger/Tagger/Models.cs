using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaggerNamespace.Model
{
    public class Item
    {
        public Item()
        {
            Tags = new List<Tag>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public String Path { get; set; }
        public String Name { get; set; }
        public int? ParentId { get; set; }
        public string Hash { get; set; }

        public virtual IList<Tag> Tags { get; set; }
    }

    public class Tag
    {
        public Tag()
        {
            Items = new List<Item>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public virtual IList<Item> Items { get; set; }
    }
}
