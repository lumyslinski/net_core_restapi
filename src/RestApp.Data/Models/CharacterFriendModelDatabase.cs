using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RestApp.Data.Models
{
    public class CharacterFriendModelDatabase
    {
        public int CharacterId { get; set; }
        [ForeignKey("CharacterId")]
        public virtual CharacterModelDatabase Character { get; set; }
        public int FriendId { get; set; }
        [ForeignKey("FriendId")]
        public virtual CharacterModelDatabase Friend { get; set; }
    }
}
