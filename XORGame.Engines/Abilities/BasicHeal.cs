using System;
using System.Linq;
using XORGame.Data.DataTransferEntities;
using XORGame.Data.Entities;
using XORGame.Data.Entities.Contracts;

namespace XORGame.Engines.Abilities
{
    public class BasicHeal : MustInitialize<Ability>, IAbilityAction
    {
        public Ability Ability { get; private set; }

        public BasicHeal(Ability ability) : base(ability)
        {
            Ability = ability;
        }

        public bool IsValidTarget(BattleData battleData, CharacterBattleData targetedCharacter)
        {
            CharacterBattleData selectedCharacter = battleData.Characters.Where(c => c.IsSelected).FirstOrDefault();
            return (selectedCharacter != null && targetedCharacter != null &&
                selectedCharacter.TeamID == targetedCharacter.TeamID);
        }

        public void AdjustCharacterStats(BattleData battleData, CharacterBattleData targetedCharacter)
        {
            CharacterBattleData selectedCharacter = battleData.Characters.Where(c => c.IsSelected).FirstOrDefault();
            if (int.TryParse(Math.Round(targetedCharacter.TotalHealth * 0.4).ToString(), out int healAmount))
            {
                targetedCharacter.CurrentHealth = targetedCharacter.CurrentHealth + healAmount < targetedCharacter.TotalHealth ? 
                    targetedCharacter.CurrentHealth + healAmount : targetedCharacter.TotalHealth;
            }
        }
    }
}
