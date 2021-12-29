using System.Collections.Generic;
using System.Linq;
using RestApp.Data.Database;
using RestApp.Data.Models;

public class CharacterEpisodeRepository : ICharacterEpisodeRepository
{
    private readonly ApplicationDbContext dbContext;

    public CharacterEpisodeRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void Create(int id, List<EpisodeModelDatabase> items)
    {
        var characterEpisodes = new List<CharacterEpisodeModelDatabase>(items.Select(e => new CharacterEpisodeModelDatabase() {CharacterId = id, EpisodeId = e.Id}));
            Create(characterEpisodes);
    }

    public void Create(List<CharacterEpisodeModelDatabase> items)
    {
        dbContext.CharacterEpisodes.AddRange(items);
        dbContext.SaveChanges();
    }

    public void Delete(int characterId) {
    var characterEpisodes = dbContext.CharacterEpisodes.Where(ce => ce.CharacterId == characterId);
        if (characterEpisodes != null) {
            dbContext.CharacterEpisodes.RemoveRange(characterEpisodes);
            dbContext.SaveChanges();
        }
    }

    public void Delete(List<CharacterEpisodeModelDatabase> items)
    {
        bool isAnythingChanged = false;
        foreach(var item in items) {
            var foundCharacterEpisode = dbContext.CharacterEpisodes.FirstOrDefault(c => c.CharacterId == item.CharacterId && c.EpisodeId == item.EpisodeId);
            if (foundCharacterEpisode != null) {
                dbContext.CharacterEpisodes.Remove(foundCharacterEpisode);
                isAnythingChanged = true;
            }
        }
        if(isAnythingChanged)
            dbContext.SaveChanges();
    }

    public void Update(List<CharacterEpisodeModelDatabase> items)
    {
        bool isAnythingChanged = false;
            foreach(var item in items) {
                var foundCharacterEpisode = dbContext.CharacterEpisodes.FirstOrDefault(c => c.CharacterId == item.CharacterId && c.EpisodeId == item.EpisodeId);
                if (foundCharacterEpisode == null)
                {
                    dbContext.CharacterEpisodes.Add(item);
                    isAnythingChanged = true;
                }
            }
        if(isAnythingChanged)
            dbContext.SaveChanges();
    }
}