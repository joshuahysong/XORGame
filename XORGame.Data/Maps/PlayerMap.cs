using System.Data.Entity.ModelConfiguration;
using XORGame.Data.Entities;

namespace XORGame.Data.Maps
{
    public class PlayerMap : EntityTypeConfiguration<Player>
    {
        public PlayerMap()
        {
            ToTable("Player");

            HasKey(x => x.ID);

            Property(x => x.ID).HasColumnName("ID");
            Property(x => x.Level).HasColumnName("Level");
            Property(x => x.Experience).HasColumnName("Experience");
            Property(x => x.Name).HasColumnName("Name");
        }
    }
}
