using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    [Table("tag")]
    public class Tag
    {
        [Key]
        [Column("id")]
        public long id { get; set; }

        [Required]
        [Column("name_tag")]
        public string? nameTag { get; set; }

        [JsonIgnore]
        public List<Note> notes { get; set; } = new List<Note>();
    }
}