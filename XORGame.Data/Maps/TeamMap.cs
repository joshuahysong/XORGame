using System.Data.Entity.ModelConfiguration;
using XORGame.Data.Entities;

namespace XORGame.Data.Maps
{
    public class TeamMap : EntityTypeConfiguration<Team>
    {
        public TeamMap()
        {
            ToTable("Team");

            HasKey(x => x.ID);

            Property(x => x.ID).HasColumnName("ID");
            Property(x => x.PlayerID).HasColumnName("PlayerID");
            Property(x => x.Name).HasColumnName("Name");

            HasRequired(c => c.Player)
                .WithMany(o => o.Teams)
                .HasForeignKey(c => c.PlayerID)
                .WillCascadeOnDelete(false);
        }
    }
}
