using System.Collections.Generic;

namespace XORGame.Data.Entities
{
    public class Ability
    {
        public Ability()
        {
            PlayerCharacterAbilities = new HashSet<PlayerCharacterAbility>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PlayerCharacterAbility> PlayerCharacterAbilities { get; set; }
    }
}
