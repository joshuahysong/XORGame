using System.Collections.Generic;

namespace XORGame.Data.Entities
{
    public class PlayerCharacter
    {
        public PlayerCharacter()
        {
            PlayerCharacterAbilities = new HashSet<PlayerCharacterAbility>();
            TeamRosters = new HashSet<TeamRoster>();
        }

        public int ID { get; set; }
        public int PlayerID { get; set; }
        public int CharacterID { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set;}
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }

        public virtual Player Player { get; set; }
        public virtual Character Character { get; set; }

        public ICollection<TeamRoster> TeamRosters { get; set; }
        public ICollection<PlayerCharacterAbility> PlayerCharacterAbilities { get; set; }
    }
}
