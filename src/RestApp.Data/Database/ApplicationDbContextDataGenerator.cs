using System;
using System.Collections.Generic;
using RestApp.Data.Models;

namespace RestApp.Data.Database
{
    public class ApplicationDbContextDataGenerator: IDisposable
    {
        private string[] characters;
        private string[] episodes;
        private List<object> characterEpisodes;
        private List<object> characterFriends;

        public void Init()
        {
            characters = new string[7] { "Luke Skywalker", "Darth Vader", "Han Solo", "Leia Organa", "Wilhuff Tarkin", "C-3PO", "R2-D2" };
            episodes = new string[3] { "NEWHOPE", "EMPIRE", "JEDI" };
            characterEpisodes = new List<object>();
            characterFriends = new List<object>();
        }

        public CharacterModelDatabase[] GetCharacters()
        {
            CharacterModelDatabase[] result = new CharacterModelDatabase[7];
            for (int i = 0; i < characters.Length; i++)
            {
                result[i] = new CharacterModelDatabase()
                {
                    Id = i + 1,
                    Name = characters[i]
                };
            }
            return result;
        }

        public EpisodeModelDatabase[] GetEpisodes()
        {
            EpisodeModelDatabase[] result = new EpisodeModelDatabase[3];
            for (int i = 0; i < episodes.Length; i++)
            {
                result[i] = new EpisodeModelDatabase()
                {
                    Id = i + 1,
                    Name = episodes[i]
                };
            }
            return result;
        }

        /// <summary>
        /// characterId is always at first (zero) index
        /// </summary>
        /// <param name="data"></param>
        public void AddCharacterEpisodes(params object[] data)
        {
            for (int i = 1; i < data.Length; i++)
            {
                characterEpisodes.Add(new { CharacterId = data[0], EpisodeId = data[i] });
            }
        }

        public object[] GetCharacterEpisodes()
        {
            return characterEpisodes.ToArray();
        }

        /// <summary>
        /// characterId is always at first (zero) index
        /// </summary>
        /// <param name="data"></param>
        public void AddCharacterFriends(params object[] data)
        {
            for (int i = 1; i < data.Length; i++)
            {
                characterFriends.Add(new { CharacterId = data[0], FriendId = data[i] });
            }
        }

        public object[] GetCharacterFriends()
        {
            return characterFriends.ToArray();
        }

        public void Dispose()
        {
            this.characters = null;
            this.episodes = null;
            if(this.characterEpisodes != null)
                this.characterEpisodes.Clear();
            this.characterEpisodes = null;
            if (this.characterFriends != null)
                this.characterFriends.Clear();
            this.characterFriends = null;
        }
    }
}
