using System.Data.Entity.ModelConfiguration;
using XORGame.Data.Entities;

namespace XORGame.Data.Maps
{
    public class CharacterMap : EntityTypeConfiguration<Character>
    {
        public CharacterMap()
        {
            ToTable("Character");

            HasKey(x => x.ID);

            Property(x => x.ID).HasColumnName("ID");
            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.Health).HasColumnName("Health");
            Property(x => x.Attack).HasColumnName("Attack");
            Property(x => x.Defense).HasColumnName("Defense");
            Property(x => x.Speed).HasColumnName("Speed");
            Property(x => x.Description).HasColumnName("Description");
        }
    }
}
