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
        [Key]
        public int Id { get; set; }
        [Required]
        public String Path { get; set; }
        public String Name { get; set; }
        public int? ParentId { get; set; }
        public bool IsFolder { get; set; }
        [NotMapped]
        public List<Tag> Tags { get; set; }
    }

    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
    }

    public class ItemTagMap
    {
        [Key]
        public int ItemTagId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int TagId { get; set; }
    }
}
