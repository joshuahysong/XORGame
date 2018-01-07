using System.Data.Entity.ModelConfiguration;
using XORGame.Data.Entities;

namespace XORGame.Data.Maps
{
    public class PlayerCharacterAbilityMap : EntityTypeConfiguration<PlayerCharacterAbility>
    {
        public PlayerCharacterAbilityMap()
        {
            ToTable("PlayerCharacterAbility");

            HasKey(x => new { x.AbilityID, x.PlayerCharacterID });

            Property(x => x.AbilityID).HasColumnName("TeamID");
            Property(x => x.PlayerCharacterID).HasColumnName("PlayerCharacterID");
            Property(x => x.Level).HasColumnName("Level");

            HasRequired(c => c.Ability)
                .WithMany(o => o.PlayerCharacterAbilities)
                .HasForeignKey(c => c.AbilityID)
                .WillCascadeOnDelete(false);

            HasRequired(c => c.PlayerCharacter)
                .WithMany(o => o.PlayerCharacterAbilities)
                .HasForeignKey(c => c.PlayerCharacterID)
                .WillCascadeOnDelete(false);
        }
    }
}
