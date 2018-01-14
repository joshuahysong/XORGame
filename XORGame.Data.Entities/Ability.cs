using System.Collections.Generic;

namespace XORGame.Data.Entities
{
    public class Ability
    {
        public Ability()
        {
            PlayerCharacterAbilities = new HashSet<PlayerCharacterAbility>();
            CurrentCooldown = 0;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string EffectArea { get; set; }
        public int Cooldown { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PlayerCharacterAbility> PlayerCharacterAbilities { get; set; }

        public int CurrentCooldown { get; set; }

        public bool IsOnCooldown(Ability ability)
        {
            return CurrentCooldown > 0;
        }
    }
}
