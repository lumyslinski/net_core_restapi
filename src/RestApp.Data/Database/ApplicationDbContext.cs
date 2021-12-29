using Microsoft.EntityFrameworkCore;
using RestApp.Data.Models;

namespace RestApp.Data.Database
{
    public class ApplicationDbContext : DbContext
    {
        #region Properties
        public DbSet<CharacterModelDatabase> Characters { get; set; }
        public DbSet<CharacterEpisodeModelDatabase> CharacterEpisodes { get; set; }
        public DbSet<CharacterFriendModelDatabase> CharacterFriends { get; set; }
        public DbSet<EpisodeModelDatabase> Episodes { get; set; }
        #endregion Properties

        #region Constructor

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        #endregion Constructor

        #region Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         #if DEBUG
            optionsBuilder.EnableSensitiveDataLogging();
         #endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            var generator = new ApplicationDbContextDataGenerator();
                generator.Init();

            modelBuilder.Entity<EpisodeModelDatabase>().ToTable("Episode");
            modelBuilder.Entity<EpisodeModelDatabase>().HasData(generator.GetEpisodes());
            modelBuilder.Entity<EpisodeModelDatabase>().Property(i => i.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<CharacterModelDatabase>().ToTable("Character");
            modelBuilder.Entity<CharacterModelDatabase>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CharacterModelDatabase>().HasData(generator.GetCharacters());
            modelBuilder.Entity<CharacterModelDatabase>().HasMany(i => i.Episodes).WithOne(i => i.Character).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CharacterModelDatabase>().HasMany(i => i.Friends).WithOne(i => i.Character).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CharacterEpisodeModelDatabase>().ToTable("CharacterEpisode");
            modelBuilder.Entity<CharacterEpisodeModelDatabase>().HasKey(ce => new { ce.CharacterId, ce.EpisodeId });
            modelBuilder.Entity<CharacterEpisodeModelDatabase>().HasOne(ce => ce.Character).WithMany(c => c.Episodes).OnDelete(DeleteBehavior.Restrict);
            generator.AddCharacterEpisodes(1, 1, 2, 3); // Luke Skywalker
            generator.AddCharacterEpisodes(2, 1, 2, 3); // Darth Vader
            generator.AddCharacterEpisodes(3, 1, 2, 3); // Han Solo
            generator.AddCharacterEpisodes(4, 1, 2, 3); // Leia Organa
            generator.AddCharacterEpisodes(5, 1);       // Wilhuff Tarkin
            generator.AddCharacterEpisodes(6, 1, 2, 3); // C-3PO
            generator.AddCharacterEpisodes(7, 1, 2, 3); // R2-D2
            modelBuilder.Entity<CharacterEpisodeModelDatabase>().HasData(generator.GetCharacterEpisodes());

            modelBuilder.Entity<CharacterFriendModelDatabase>().ToTable("CharacterFriend");
            modelBuilder.Entity<CharacterFriendModelDatabase>().HasKey(cf => new { cf.CharacterId, cf.FriendId });
            modelBuilder.Entity<CharacterFriendModelDatabase>().HasOne(cf => cf.Character).WithMany(c => c.Friends).OnDelete(DeleteBehavior.Restrict);
            generator.AddCharacterFriends(1, 3, 4, 6, 7);  // Luke Skywalker
            generator.AddCharacterFriends(2, 5);           // Darth Vader
            generator.AddCharacterFriends(3, 1, 4, 7);     // Han Solo
            generator.AddCharacterFriends(4, 1, 3, 6, 7);  // Leia Organa
            generator.AddCharacterFriends(5, 2);           // Wilhuff Tarkin
            generator.AddCharacterFriends(6, 1, 3, 4, 7);  // C-3PO
            generator.AddCharacterFriends(7, 1, 3, 4);     // R2-D2
            modelBuilder.Entity<CharacterFriendModelDatabase>().HasData(generator.GetCharacterFriends());
        }


        #endregion Methods
    }
}
