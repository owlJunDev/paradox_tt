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
        
        [Column("title")]

        public string? title { get; set; }
        
        [Column("content")]
        public string? content { get; set; }
        
        [Column("date-create")]
        public DateTime dateCreate { get; set; }
    }
}