using System;
using System.Collections.Generic;
using System.Linq;
using XORGame.Data.Entities.Contracts;

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
        public string Type { get; set; }
        public string EffectArea { get; set; }
        public int Cooldown { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PlayerCharacterAbility> PlayerCharacterAbilities { get; set; }
    }
}
