using XORGame.Data.Entities;

namespace XORGame.Data.DataTransferEntities
{
    public abstract class DefaultAbilityAction
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string EffectArea { get; set; }

        public int Cooldown { get; set; }

        public string Description { get; set; }

        public int CurrentCooldown { get; set; }

        public DefaultAbilityAction(Ability ability)
        {
            ID = ability.ID;
            Name = ability.Name;
            Type = ability.Type;
            EffectArea = ability.EffectArea;
            Cooldown = ability.Cooldown;
            Description = ability.Description;
            CurrentCooldown = 0;
        }

        public void StartCooldown()
        {
            CurrentCooldown = Cooldown;
        }

        public bool IsOnCooldown()
        {
            return CurrentCooldown > 0;
        }

        public static int GetDamageModifier(int attack, int defense)
        {
            return ((attack - defense) / 10) + 1;
        }
    }
}
