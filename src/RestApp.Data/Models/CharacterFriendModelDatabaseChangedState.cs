using System.Collections.Generic;

namespace RestApp.Data.Models
{
    public class CharacterFriendModelDatabaseChangedState
    {
        public List<CharacterFriendModelDatabase> CharacterFriends { get; set; }
        public List<CharacterFriendModelDatabase> CharacterFriendsChanged { get; set; }

        public CharacterFriendModelDatabaseChangedState()
        {
            this.CharacterFriends        = new List<CharacterFriendModelDatabase>();
            this.CharacterFriendsChanged = new List<CharacterFriendModelDatabase>();
        }
    }
}
