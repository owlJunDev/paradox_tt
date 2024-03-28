using System.ComponentModel.DataAnnotations;

namespace Backend.Entity {
    public class Note {
        public int id {get; set;}
        
        [Required]
        public string? text {get; set;}
        
        [Required]
        public DateTime dateCreate {get; set;}
    }
}