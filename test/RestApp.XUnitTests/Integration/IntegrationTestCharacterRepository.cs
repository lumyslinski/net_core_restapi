using System;
using System.Collections.Generic;
using System.Linq;
using RestApp.Data.Database;
using RestApp.Data.Models;
using RestApp.Data.Repositories;
using Xunit;

namespace RestApp.XUnitTests.Integration
{
    public class IntegrationTestCharacterRepository
    {
        [Fact]
        public void UnitTestCharacterRepositoryRead()
        {
            IEnumerable<CharacterModelDatabase> readResult = null;
            try
            {
                using (var dbContext = ApplicationDbContextContainer.GetInstance())
                {
                    Assert.NotNull(dbContext);
                    CharacterRepository characterRepository = new CharacterRepository(dbContext);
                    readResult = characterRepository.Read();
                    Assert.NotNull(readResult);
                    var firstCharacter = readResult.FirstOrDefault();
                    Assert.NotNull(firstCharacter);
                    Assert.True(firstCharacter.Name == "Luke Skywalker");
                    Assert.NotNull(firstCharacter);
                    Assert.NotNull(firstCharacter.Episodes);
                    var episodes = new List<string> {"NEWHOPE", "EMPIRE", "JEDI"};
                    foreach (var characterEpisode in firstCharacter.Episodes)
                    {
                        Assert.NotNull(characterEpisode.Episode);
                        Assert.Contains(episodes, f => f == characterEpisode.Episode.Name);
                    }

                    Assert.NotNull(firstCharacter.Friends);
                    var friends = new List<string> {"Han Solo", "Leia Organa", "C-3PO", "R2-D2"};
                    foreach (var characterFriend in firstCharacter.Friends)
                    {
                        Assert.NotNull(characterFriend.Friend);
                        Assert.Contains(friends, f => f == characterFriend.Friend.Name);
                    }
                }
            }
            catch (Exception exp)
            {
                throw;
            }
            finally
            {
               readResult = null;
            }

            //only on creating
            //Assert.True(readResult.Count() == 7);
        }

        [Fact]
        public void UnitTestCharacterRepositoryAddDelete()
        {
            try
            {
                using (var dbContext = ApplicationDbContextContainer.GetInstance())
                {
                    Assert.NotNull(dbContext);
                    CharacterRepository characterRepository = new CharacterRepository(dbContext);
                    var newId = characterRepository.Create(new CharacterModelDatabase()
                    {
                        Name = "JustForTest"
                    });
                    Assert.True(newId > 0);
                    characterRepository.Delete(newId);
                    var testItem = characterRepository.GetItem(newId);
                    Assert.Null(testItem);
                }
            }
            catch (Exception exp)
            {
                throw;
            }  
        }

        [Fact]
        public void UnitTestCharacterRepositoryUpdateNameDelete()
        {
            try
            {
                using (var dbContext = ApplicationDbContextContainer.GetInstance())
                {
                    Assert.NotNull(dbContext);
                    CharacterRepository characterRepository = new CharacterRepository(dbContext);
                    var newItem = new CharacterModelDatabase()
                    {
                        Name = "JustForTest"
                    };
                    var newId = characterRepository.Create(newItem);
                    Assert.True(newId > 0);
                    newItem.Name = "JustForTest2";
                    characterRepository.Update(newItem);
                    var testItem = characterRepository.GetItem(newId);
                    Assert.True(testItem.Name == "JustForTest2");
                    characterRepository.Delete(newId);
                    testItem = characterRepository.GetItem(newId);
                    Assert.Null(testItem);
                }
            }
            catch (Exception exp)
            {
                throw;
            }
        }

        /* Update scenarios
         * scenario1:
         *         |  Episode |  Friend  |
         * input---|---null---|---null---|
         * output1-|---null---|-not null-|
         * output2-|-not null-|---null---|
         * output3-|-not null-|-not null-|
         *
         * scenario2:
         * input---|-not null-|---null---|
         * output1-|---null---|-not null-|
         * output2-|-not null-|-not null-|
         * output3-|---null---|---null---|
         *
         * scenario3:
         * input---|---null---|-not null-|
         * output1-|---null---|---null---|
         * output2-|-not null-|---null---|
         * output3-|-not null-|-not null-|
         *
         * scenario4:
         * input---|-not null-|-not null-|
         * output1-|---null---|---null---|
         * output2-|-not null-|---null---|
         * output3-|---null---|-not null-|
         */

        [Fact]
        public void UnitTestCharacterRepositoryUpdateDeleteEpisodesFriends_Scenario1()
        {
            try
            {
                using (var dbContext = ApplicationDbContextContainer.GetInstance())
                {
                    Assert.NotNull(dbContext);
                    CharacterRepository characterRepository = new CharacterRepository(dbContext);
                    CharacterFriendRepository characterFriendRepository = new CharacterFriendRepository(dbContext);
                    CharacterEpisodeRepository characterEpisodeRepository = new CharacterEpisodeRepository(dbContext);
                    var newItem = new CharacterModelDatabase()
                    {
                        Name = "JustForTest"
                    };
                    var newId = characterRepository.Create(newItem);
                    Assert.True(newId > 0);
                    newItem.Name = "JustForTest2";
                    #region output2
                    newItem.Episodes = new List<CharacterEpisodeModelDatabase>()
                    {
                        new CharacterEpisodeModelDatabase()
                        {
                            CharacterId = newId,
                            EpisodeId = 3
                        }
                    };
                    characterRepository.Update(newItem);
                    var updatedItemEpisode = characterRepository.GetItem(newId);
                    Assert.True(updatedItemEpisode.Name == "JustForTest2");
                    Assert.NotNull(updatedItemEpisode.Episodes);
                    Assert.True(updatedItemEpisode.Episodes.FirstOrDefault().Episode.Name == "JEDI");
                    #endregion
                    #region output1
                    newItem.Friends = new List<CharacterFriendModelDatabase>()
                    {
                        new CharacterFriendModelDatabase()
                        {
                            CharacterId = newId,
                            FriendId = 2
                        }
                    };
                    characterRepository.Update(newItem);
                    var updatedItemFriend = characterRepository.GetItem(newId);
                    Assert.True(updatedItemFriend.Name == "JustForTest2");
                    Assert.NotNull(updatedItemFriend.Friends);
                    Assert.True(updatedItemFriend.Friends.FirstOrDefault().Friend.Name == "Darth Vader");
                    #endregion
                    #region output4
                    newItem.Episodes = new List<CharacterEpisodeModelDatabase>()
                    {
                        new CharacterEpisodeModelDatabase()
                        {
                            CharacterId = newId,
                            EpisodeId = 3
                        }
                    };
                    newItem.Friends = new List<CharacterFriendModelDatabase>()
                    {
                        new CharacterFriendModelDatabase()
                        {
                            CharacterId = newId,
                            FriendId = 2
                        }
                    };
                    characterRepository.Update(newItem);
                    var updatedItemEpisodeFriend = characterRepository.GetItem(newId);
                    Assert.True(updatedItemEpisodeFriend.Name == "JustForTest2");
                    Assert.NotNull(updatedItemEpisodeFriend.Episodes);
                    Assert.True(updatedItemEpisodeFriend.Episodes.FirstOrDefault().Episode.Name == "JEDI");
                    Assert.NotNull(updatedItemFriend.Friends);
                    Assert.True(updatedItemFriend.Friends.FirstOrDefault().Friend.Name == "Darth Vader");
                    #endregion
                    characterEpisodeRepository.Delete(newId);
                    characterFriendRepository.Delete(newId);
                    characterRepository.Delete(newId);
                    var testItem = characterRepository.GetItem(newId);
                    Assert.Null(testItem);
                }
            }
            catch (Exception exp)
            {
                throw;
            }
        }
    }
}
