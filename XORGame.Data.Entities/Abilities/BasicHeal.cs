using System;
using System.Linq;
using XORGame.Data.DataTransferEntities;
using XORGame.Data.Entities.Contracts;

namespace XORGame.Data.Entities.Abilities
{
    public class BasicHeal : AbilityActionBase, IAbilityAction
    {
        public BasicHeal(Ability ability) : base(ability) { }

        public bool IsValidTarget(BattleData battleData, CharacterBattleData targetedCharacter)
        {
            CharacterBattleData selectedCharacter = battleData.Characters.Where(c => c.IsSelected).FirstOrDefault();
            return (selectedCharacter != null && targetedCharacter != null &&
                selectedCharacter.TeamID == targetedCharacter.TeamID &&
                !IsOnCooldown());
        }

        public void AdjustCharacterStats(BattleData battleData, CharacterBattleData targetedCharacter)
        {
            CharacterBattleData selectedCharacter = battleData.Characters.Where(c => c.IsSelected).FirstOrDefault();
            int healAmount;
            if (int.TryParse(Math.Round(targetedCharacter.TotalHealth * 0.4).ToString(), out healAmount))
            {
                targetedCharacter.CurrentHealth = targetedCharacter.CurrentHealth + healAmount < targetedCharacter.TotalHealth ? 
                    targetedCharacter.CurrentHealth + healAmount : targetedCharacter.TotalHealth;
                StartCooldown();
            }
        }
    }
}
