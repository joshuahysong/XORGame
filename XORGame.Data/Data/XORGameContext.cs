using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XORGame.Data.Entities;
using System.Runtime.Serialization;
using XORGame.Data.Maps;

namespace XORGame.Data
{
    public class XORGameContext : DbContext
    {
        public virtual DbSet<Ability> Abilities { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<PlayerCharacterAbility> PlayerCharacterAbilities { get; set; }
        public virtual DbSet<PlayerCharacter> PlayerCharacters { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamRoster> TeamRosters { get; set; }

        public XORGameContext() : base("name=XORGameContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<XORGameContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();

            modelBuilder.Configurations.Add(new AbilityMap());
            modelBuilder.Configurations.Add(new CharacterMap());
            modelBuilder.Configurations.Add(new PlayerCharacterAbilityMap());
            modelBuilder.Configurations.Add(new PlayerCharacterMap());
            modelBuilder.Configurations.Add(new PlayerMap());
            modelBuilder.Configurations.Add(new TeamMap());
            modelBuilder.Configurations.Add(new TeamRosterMap());
        }
    }
}
