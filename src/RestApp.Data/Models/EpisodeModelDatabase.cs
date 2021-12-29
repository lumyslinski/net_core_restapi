using System.ComponentModel.DataAnnotations;

namespace RestApp.Data.Models
{
    public class EpisodeModelDatabase
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
