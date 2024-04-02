using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("note_tag")]
    public class NoteTag
    {
        [Key]
        [Column("id")]
        public long id { get; set; }

        [Column("tag_id")]
        [ForeignKey("Tag")]
        public long tagId { get; set; }

        [Column("note_id")]
        [ForeignKey("Note")]
        public long noteId { get; set; }
    }
}