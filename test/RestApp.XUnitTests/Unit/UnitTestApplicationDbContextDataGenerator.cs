using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestApp.Data.Database;
using Xunit;

namespace RestApp.XUnitTests.Unit
{
    public class UnitTestApplicationDbContextDataGenerator
    {
        ApplicationDbContextDataGenerator applicationDbContextDataGenerator = new ApplicationDbContextDataGenerator();

        [Fact]
        public void TestInit()
        {
            applicationDbContextDataGenerator.Init();
            Assert.True(applicationDbContextDataGenerator.GetEpisodes().Length == 3);
        }

        [Fact]
        public void TestEpisodes()
        {
            applicationDbContextDataGenerator.Init();
            var episodes = applicationDbContextDataGenerator.GetEpisodes();
            Assert.True(episodes.Length == 3);
            Assert.True(episodes.LastOrDefault().Name == "JEDI");
        }

        [Fact]
        public void TestCharacters()
        {
            applicationDbContextDataGenerator.Init();
            var characters = applicationDbContextDataGenerator.GetCharacters();
            Assert.True(characters.Length == 7);
            Assert.True(characters.FirstOrDefault().Name == "Luke Skywalker");
        }

        [Fact]
        public void TestAddCharacterEpisodes()
        {
            applicationDbContextDataGenerator.Init();
            try
            {
                applicationDbContextDataGenerator.AddCharacterEpisodes(1, 1, 2, 3); // Luke Skywalker
                applicationDbContextDataGenerator.AddCharacterEpisodes(2, 1, 2, 3); // Darth Vader
                applicationDbContextDataGenerator.AddCharacterEpisodes(3, 1, 2, 3); // Han Solo
                applicationDbContextDataGenerator.AddCharacterEpisodes(4, 1, 2, 3); // Leia Organa
                applicationDbContextDataGenerator.AddCharacterEpisodes(5, 1);       // Wilhuff Tarkin
                applicationDbContextDataGenerator.AddCharacterEpisodes(6, 1, 2, 3); // C-3PO
                applicationDbContextDataGenerator.AddCharacterEpisodes(7, 1, 2, 3); // R2-D2
            }
            catch (Exception exp)
            {
                throw exp;
            }

            var episodes = applicationDbContextDataGenerator.GetCharacterEpisodes();
            Assert.True(episodes.Length == 19);
        }

        [Fact]
        public void TestAddCharacterFriends()
        {
            applicationDbContextDataGenerator.Init();
            try
            {
                applicationDbContextDataGenerator.AddCharacterFriends(1, 3, 4, 6, 7);  // Luke Skywalker
                applicationDbContextDataGenerator.AddCharacterFriends(2, 5);           // Darth Vader
                applicationDbContextDataGenerator.AddCharacterFriends(3, 1, 4, 7);     // Han Solo
                applicationDbContextDataGenerator.AddCharacterFriends(4, 1, 3, 6, 7);  // Leia Organa
                applicationDbContextDataGenerator.AddCharacterFriends(5, 2);           // Wilhuff Tarkin
                applicationDbContextDataGenerator.AddCharacterFriends(6, 1, 3, 4, 7);  // C-3PO
                applicationDbContextDataGenerator.AddCharacterFriends(7, 1, 3, 4);     // R2-D2
            }
            catch (Exception exp)
            {
                throw exp;
            }

            var friends = applicationDbContextDataGenerator.GetCharacterFriends();
            Assert.True(friends.Length == 20);
        }
    }
}
