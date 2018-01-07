using System.Data.Entity.ModelConfiguration;
using XORGame.Data.Entities;

namespace XORGame.Data.Maps
{
    public class PlayerCharacterMap : EntityTypeConfiguration<PlayerCharacter>
    {
        public PlayerCharacterMap()
        {
            ToTable("PlayerCharacter");

            HasKey(x => x.ID);

            Property(x => x.ID).HasColumnName("ID");
            Property(x => x.PlayerID).HasColumnName("PlayerID");
            Property(x => x.CharacterID).HasColumnName("CharacterID");
            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.Health).HasColumnName("Health");
            Property(x => x.Attack).HasColumnName("Attack");
            Property(x => x.Defense).HasColumnName("Defense");
            Property(x => x.Speed).HasColumnName("Speed");
            Property(x => x.Experience).HasColumnName("Experience");
            Property(x => x.Level).HasColumnName("Level");

            HasRequired(c => c.Player)
                .WithMany(o => o.PlayerCharacters)
                .HasForeignKey(c => c.PlayerID)
                .WillCascadeOnDelete(false);

            HasRequired(c => c.Character)
                .WithMany(o => o.PlayerCharacters)
                .HasForeignKey(c => c.CharacterID)
                .WillCascadeOnDelete(false);
        }
    }
}
