using System.Collections.Generic;
using System.Drawing;
using XORGame.Data.DataTransferEntities;
using XORGame.Data.Entities;

namespace XORGame.Data.Entities.Contracts
{
    public abstract class AbilityActionBase
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string EffectArea { get; set; }

        public int Cooldown { get; set; }

        public string Description { get; set; }

        public int CurrentCooldown { get; set; }

        public List<Point> ValidTargets { get; set; }

        public AbilityActionBase(Ability ability)
        {
            ID = ability.ID;
            Name = ability.Name;
            Type = ability.Type;
            EffectArea = ability.EffectArea;
            Cooldown = ability.Cooldown;
            Description = ability.Description;
            CurrentCooldown = 0;
            ValidTargets = new List<Point>();
        }

        public void StartCooldown()
        {
            // We do Cooldown +1 since cooldown is reduced at the BEGINNING of a turn.
            // This way we get a full amount of turns equal to the cooldown before the ability can be used again.
            CurrentCooldown = Cooldown + 1;
        }

        public bool IsOnCooldown()
        {
            return CurrentCooldown > 0;
        }

        public int GetDamageModifier(int attack, int defense)
        {
            return ((attack - defense) / 10) + 1;
        }

        public void CheckCharacterDeathAtSpace(BattleData battleData, Boardspace targetSpace)
        {
            if (targetSpace.Character.CurrentHealth <= 0)
            {
                battleData.DeadCharacters.Add(targetSpace.Character);
                targetSpace.Character = null;
            }
        }
    }
}
