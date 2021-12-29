using System.Collections.Generic;
using System.Linq;
using RestApp.Data.Database;
using RestApp.Data.Models;

public class CharacterFriendRepository : ICharacterFriendRepository
{
    private readonly ApplicationDbContext dbContext;

    public CharacterFriendRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void Create(int id, List<CharacterModelDatabase> items)
    {
        var CharacterFriends = new List<CharacterFriendModelDatabase>(items.Select(e => new CharacterFriendModelDatabase() {CharacterId = id, FriendId = e.Id}));
            Create(CharacterFriends);
    }

    public void Create(List<CharacterFriendModelDatabase> items)
    {
        dbContext.CharacterFriends.AddRange(items);
        dbContext.SaveChanges();
    }
    public void Delete(int characterId) {
    var characterFriends = dbContext.CharacterFriends.Where(ce => ce.CharacterId == characterId);
        if (characterFriends != null) {
            dbContext.CharacterFriends.RemoveRange(characterFriends);
            dbContext.SaveChanges();
        }
    }
    public void Delete(List<CharacterFriendModelDatabase> items)
    {
        bool isAnythingChanged = false;
        foreach(var item in items) {
            var foundCharacterFriend = dbContext.CharacterFriends.FirstOrDefault(c => c.CharacterId == item.CharacterId && c.FriendId == item.FriendId);
            if (foundCharacterFriend != null) {
                dbContext.CharacterFriends.Remove(foundCharacterFriend);
                isAnythingChanged = true;
            }
        }
        if(isAnythingChanged)
            dbContext.SaveChanges();
    }

    public void Update(List<CharacterFriendModelDatabase> items)
    {
        bool isAnythingChanged = false;
            foreach(var item in items) {
                var foundCharacterFriend = dbContext.CharacterFriends.FirstOrDefault(c => c.CharacterId == item.CharacterId && c.FriendId == item.FriendId);
                if (foundCharacterFriend == null)
                {
                    dbContext.CharacterFriends.Add(item);
                    isAnythingChanged = true;
                }
            }
        if(isAnythingChanged)
            dbContext.SaveChanges();
    }
}