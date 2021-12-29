using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApp.Data.Models
{
    public class CharacterModelDatabase
    {
        [Key]
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<CharacterEpisodeModelDatabase> Episodes { get; set; }
        public virtual ICollection<CharacterFriendModelDatabase> Friends { get; set; }
    }
}
