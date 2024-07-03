using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("note")]
    public class Note
    {
        [Key]
        [Column("id")]
        public long id { get; set; }
        
        [Required]
        [Column("title")]
        public string? title { get; set; }
        
        [Required]
        [Column("content")]
        public string? content { get; set; }
        
        [Column("date-create")]
        public DateTime createAt { get; set; }
        
        public List<Tag> tags{ get; set; } = new List<Tag>();
    }
}