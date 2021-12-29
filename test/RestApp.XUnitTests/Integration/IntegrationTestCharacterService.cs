using System;
using System.Collections.Generic;
using System.Linq;
using RestApp.Data.Contracts;
using RestApp.Data.Database;
using RestApp.Data.Models;
using RestApp.Data.Repositories;
using RestApp.Data.Services;
using Xunit;

namespace RestApp.XUnitTests.Integration
{
    public class IntegrationTestCharacterService
    {
        [Fact]
        public void UnitTestCharacterServiceRead()
        {
            IEnumerable<ICharacterModel> readResult = null;
            try
            {
                using (var dbContext = ApplicationDbContextContainer.GetInstance())
                {
                    Assert.NotNull(dbContext);
                    CharacterRepository characterRepository = new CharacterRepository(dbContext);
                    EpisodeRepository episodeRepository = new EpisodeRepository(dbContext);
                    CharacterEpisodeRepository characterEpisodeRepository = new CharacterEpisodeRepository(dbContext);
                    CharacterFriendRepository characterFriendRepository = new CharacterFriendRepository(dbContext);
                    CharacterService characterService = new CharacterService(characterRepository, episodeRepository, characterFriendRepository, characterEpisodeRepository);
                    readResult = characterService.Read();
                    Assert.NotNull(readResult);
                    var firstCharacter = readResult.FirstOrDefault();
                    Assert.NotNull(firstCharacter);
                    Assert.True(firstCharacter.Name == "Luke Skywalker");
                    Assert.NotNull(firstCharacter);
                    Assert.NotNull(firstCharacter.Episodes);
                    var episodes = new List<string> {"NEWHOPE", "EMPIRE", "JEDI"};
                    foreach (var characterEpisode in firstCharacter.Episodes)
                    {
                        Assert.NotNull(characterEpisode);
                        Assert.Contains(episodes, f => f == characterEpisode);
                    }
                    Assert.NotNull(firstCharacter.Friends);
                    var friends = new List<string> {"Han Solo", "Leia Organa", "C-3PO", "R2-D2"};
                    foreach (var characterFriend in firstCharacter.Friends)
                    {
                        Assert.NotNull(characterFriend);
                        Assert.Contains(friends, f => f == characterFriend);
                    }
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
               readResult = null;
            }

            //only on creating
            //Assert.True(readResult.Count() == 7);
        }

        [Fact]
        public void UnitTestCharacterServiceCreate()
        {
            try
            {
                using (var dbContext = ApplicationDbContextContainer.GetInstance())
                {
                    Assert.NotNull(dbContext);
                    CharacterRepository characterRepository = new CharacterRepository(dbContext);
                    EpisodeRepository episodeRepository = new EpisodeRepository(dbContext);
                    CharacterEpisodeRepository characterEpisodeRepository = new CharacterEpisodeRepository(dbContext);
                    CharacterFriendRepository characterFriendRepository = new CharacterFriendRepository(dbContext);
                    CharacterService characterService = new CharacterService(characterRepository, episodeRepository, characterFriendRepository, characterEpisodeRepository);
                    var getTestItem = characterService.GetItemByName("Kylo");
                    var newId = 0;
                    if (getTestItem == null)
                    {
                        var createResult = characterService.Create(new CharacterModelBase()
                        {
                            Name = "Kylo",
                            Episodes = new List<string>() {"NEWHOPE", "EMPIRE", "JEDI", "FORCE"},
                            Friends = new List<string>() {"Darth Vader", "Rey"}
                        });
                        Assert.True(createResult.ResultIsOk);
                        newId = createResult.ResultId;
                    }
                    else
                    {
                        newId = getTestItem.Id;
                    }
                    var deleteResult = characterService.Delete(newId);
                    Assert.True(deleteResult.ResultIsOk);
                    var getItem = characterService.GetItemById(newId);
                    Assert.Null(getItem);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }  
        }

        [Fact]
        public void UnitTestCharacterServiceUpdate()
        {
            try
            {
                using (var dbContext = ApplicationDbContextContainer.GetInstance())
                {
                    Assert.NotNull(dbContext);
                    CharacterRepository characterRepository = new CharacterRepository(dbContext);
                    EpisodeRepository episodeRepository = new EpisodeRepository(dbContext);
                    CharacterEpisodeRepository characterEpisodeRepository = new CharacterEpisodeRepository(dbContext);
                    CharacterFriendRepository characterFriendRepository = new CharacterFriendRepository(dbContext);
                    CharacterService characterService = new CharacterService(characterRepository, episodeRepository, characterFriendRepository, characterEpisodeRepository);
                    var getTestItem = characterService.GetItemByName("Kylo");
                    var newId = 0;
                    if (getTestItem == null)
                    {
                        getTestItem = new CharacterModelBase()
                        {
                            Name = "Kylo",
                            Episodes = new List<string>() { "NEWHOPE", "EMPIRE", "JEDI", "FORCE" },
                            Friends = new List<string>() { "Darth Vader", "Rey" }
                        };
                        var createResult = characterService.Create(getTestItem);
                        newId = createResult.ResultId;
                        Assert.True(createResult.ResultIsOk);
                        var getItemCreated = characterService.GetItemById(newId);
                        Assert.True(getItemCreated.Episodes.Count() == 4);
                        Assert.True(getItemCreated.Episodes.LastOrDefault() == "FORCE");
                        Assert.True(getItemCreated.Friends.Count() == 2);
                        Assert.True(getItemCreated.Friends.FirstOrDefault() == "Darth Vader");
                    }
                    else
                    {
                        newId = getTestItem.Id;
                    }
                    getTestItem.Id = newId;
                    getTestItem.Name = "Kyle";
                    getTestItem.Episodes = new List<string>() { "OLDHOPE", "JEDI", "FORCE" };
                    getTestItem.Friends = new List<string>()  { "Rey", "Junior Vader" };
                    var updateResult = characterService.Update(getTestItem);
                    Assert.True(updateResult.ResultIsOk);
                    var getItem = characterService.GetItemById(newId);
                    Assert.True(getItem.Episodes.Count() == 3);
                    Assert.Contains("OLDHOPE", getItem.Episodes);
                    Assert.True(getItem.Friends.Count() == 2);
                    Assert.Contains("Junior Vader", getItem.Friends);
                    characterService.Delete(newId);
                    getItem = characterService.GetItemById(newId);
                    Assert.Null(getItem);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
