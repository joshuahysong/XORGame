﻿using System.Data.Entity.ModelConfiguration;
using XORGame.Data.Entities;

namespace XORGame.Data.Maps
{
    public class AbilityMap : EntityTypeConfiguration<Ability>
    {
        public AbilityMap()
        {
            ToTable("Ability");

            HasKey(x => x.ID);

            Property(x => x.ID).HasColumnName("ID");
            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.Description).HasColumnName("Description");
        }
    }
}
