using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("tag")]
    public class Tag
    {
        [Key]
        [Column("id")]
        public long id { get; set; }

        [Column("name_tag")]
        public string? nameTag { get; set; }
    }
}