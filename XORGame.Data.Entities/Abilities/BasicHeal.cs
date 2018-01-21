using System;
using System.Linq;
using XORGame.Data.DataTransferEntities;
using XORGame.Data.Entities.Contracts;

namespace XORGame.Data.Entities.Abilities
{
    public class BasicHeal : AbilityActionBase, IAbilityAction
    {
        public BasicHeal(Ability ability) : base(ability) { }

        public bool IsValidTarget(BattleData battleData, Boardspace targetSpace)
        {
            CharacterBattleData selectedCharacter = battleData.Characters.Where(c => c.IsSelected).FirstOrDefault();
            return (selectedCharacter != null &&
                targetSpace.Character != null &&
                selectedCharacter.TeamID == targetSpace.Character.TeamID &&
                targetSpace.Character.IsAlive() && 
                !IsOnCooldown());
        }

        public void AdjustCharacterStats(BattleData battleData, Boardspace targetSpace)
        {
            CharacterBattleData selectedCharacter = battleData.Characters.Where(c => c.IsSelected).FirstOrDefault();
            int healAmount;
            if (int.TryParse(Math.Round(targetSpace.Character.TotalHealth * 0.4).ToString(), out healAmount))
            {
                targetSpace.Character.CurrentHealth = targetSpace.Character.CurrentHealth + healAmount < targetSpace.Character.TotalHealth ?
                    targetSpace.Character.CurrentHealth + healAmount : targetSpace.Character.TotalHealth;
                StartCooldown();
            }
        }
    }
}
