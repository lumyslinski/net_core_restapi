using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Data.Models
{
    public class CharacterEpisodeModelDatabaseChangedState
    {
        public List<CharacterEpisodeModelDatabase> CharacterEpisodes { get; set; }
        public List<CharacterEpisodeModelDatabase> CharacterEpisodesChanged { get; set; }

        public CharacterEpisodeModelDatabaseChangedState()
        {
            this.CharacterEpisodes = new List<CharacterEpisodeModelDatabase>();
            this.CharacterEpisodesChanged = new List<CharacterEpisodeModelDatabase>();
        }
    }
}
