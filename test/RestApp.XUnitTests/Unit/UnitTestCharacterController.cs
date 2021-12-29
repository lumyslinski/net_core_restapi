using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RestApp.Controllers;
using RestApp.Data.Contracts;
using RestApp.Data.Database;
using RestApp.Data.Models;
using RestApp.Data.Repositories;
using RestApp.Data.Services;
using RestApp.Models;
using Xunit;

namespace RestApp.XUnitTests.Unit
{
    public class UnitTestCharacterController
    {
        [Fact]
        public void TestGetListOfCharacters()
        {
            using (var dbContext = ApplicationDbContextContainer.GetInstance())
            {
                Assert.NotNull(dbContext);
                CharacterRepository characterRepository = new CharacterRepository(dbContext);
                EpisodeRepository episodeRepository = new EpisodeRepository(dbContext);
                CharacterEpisodeRepository characterEpisodeRepository = new CharacterEpisodeRepository(dbContext);
                CharacterFriendRepository characterFriendRepository = new CharacterFriendRepository(dbContext);
                CharacterService characterService = new CharacterService(characterRepository, episodeRepository, characterFriendRepository, characterEpisodeRepository);
                // Arrange
                var controller = new CharacterController(characterService);
                // Act
                var result = controller.GetListOfCharacters("",null,null);

                // Assert
                var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
                var characters = okResult.Value.Should().BeAssignableTo<IEnumerable<ICharacterModel>>().Subject;
                characters.Should().NotBeEmpty();
            }
        }

        [Fact]
        public void TestGetListOfCharacters_MoqService()
        {
            try
            {
                // Arrange
                var applicationDbContextDataGenerator = new ApplicationDbContextDataGenerator();
                applicationDbContextDataGenerator.Init();
                var resultCharacters = new List<ICharacterModel>();
                foreach (var character in applicationDbContextDataGenerator.GetCharacters())
                {
                    resultCharacters.Add(new CharacterModelBase() {Id = character.Id, Name = character.Name});
                }

                var serviceMock = new Mock<ICharacterService>();
                serviceMock.Setup(x => x.Read(null,null,null)).Returns(() => resultCharacters.AsEnumerable());
                // Arrange
                var controller = new CharacterController(serviceMock.Object);
                // Act
                var result = controller.GetListOfCharacters("", null, null);
                // Assert
                var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
                var characters = okResult.Value.Should().BeAssignableTo<IEnumerable<ICharacterModel>>().Subject;
                characters.Count().Should().Be(5);
            }
            catch (Exception exp)
            {

            }
        }

        [Fact]
        public void TestAddDeleteCharacter()
        {
            using (var dbContext = ApplicationDbContextContainer.GetInstance())
            {
                Assert.NotNull(dbContext);
                CharacterRepository characterRepository = new CharacterRepository(dbContext);
                EpisodeRepository episodeRepository = new EpisodeRepository(dbContext);
                CharacterEpisodeRepository characterEpisodeRepository = new CharacterEpisodeRepository(dbContext);
                CharacterFriendRepository characterFriendRepository = new CharacterFriendRepository(dbContext);
                CharacterService characterService = new CharacterService(characterRepository, episodeRepository, characterFriendRepository, characterEpisodeRepository);
                // Arrange
                var controller = new CharacterController(characterService);
                // act create
                var newCharacter = new CharacterModelDataContract()
                {
                    Name = "TestChar",
                    Episodes = new List<string>() { "Epi1", "Epi2" },
                    Friends = new List<string>() { "Friend1", "Friend2" }
                };
                var addCharacterResult = controller.AddCharacter(newCharacter);
                // Assert
                var addOkObjectResult = addCharacterResult.Should().BeOfType<OkObjectResult>().Subject;
                var addCharacterServiceResult = addOkObjectResult.Value.Should().BeAssignableTo<CharacterServiceResult>().Subject;
                addCharacterServiceResult.ResultIsOk.Should().BeTrue();
                addCharacterServiceResult.Error.Should().BeNullOrEmpty();
                addCharacterServiceResult.ResultId.Should().BeGreaterThan(0);
                // act delete
                var deleteCharacterResult = controller.DeleteCharacter(addCharacterServiceResult.ResultId);
                // Assert
                var deleteOkObjectResult = deleteCharacterResult.Should().BeOfType<OkObjectResult>().Subject;
                var deleteCharacterServiceResult = deleteOkObjectResult.Value.Should().BeAssignableTo<CharacterServiceResult>().Subject;
                deleteCharacterServiceResult.ResultIsOk.Should().BeTrue();
                deleteCharacterServiceResult.Error.Should().BeNullOrEmpty();
                deleteCharacterServiceResult.ResultId.Should().BeGreaterThan(0);
            }
        }
    }
}
