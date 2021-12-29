using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApp.Data.Models
{
    public class CharacterEpisodeModelDatabase
    {
        public int CharacterId { get; set; }
        [ForeignKey("CharacterId")]
        public virtual CharacterModelDatabase Character { get; set; }
        public int EpisodeId { get; set; }
        [ForeignKey("EpisodeId")]
        public virtual EpisodeModelDatabase Episode { get; set; }
    }
}
