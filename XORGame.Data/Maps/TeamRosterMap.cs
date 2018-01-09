using System.Data.Entity.ModelConfiguration;
using XORGame.Data.Entities;

namespace XORGame.Data.Maps
{
    public class TeamRosterMap : EntityTypeConfiguration<TeamRoster>
    {
        public TeamRosterMap()
        {
            ToTable("TeamRoster");

            HasKey(x => new { x.TeamID, x.PlayerCharacterID });

            Property(x => x.TeamID).HasColumnName("TeamID");
            Property(x => x.PlayerCharacterID).HasColumnName("PlayerCharacterID");
            Property(x => x.Location).HasColumnName("Location");

            HasRequired(c => c.Team)
                .WithMany(o => o.TeamRosters)
                .HasForeignKey(c => c.TeamID)
                .WillCascadeOnDelete(false);

            HasRequired(c => c.PlayerCharacter)
                .WithMany(o => o.TeamRosters)
                .HasForeignKey(c => c.PlayerCharacterID)
                .WillCascadeOnDelete(false);
        }
    }
}
