using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XORGame.Data.DataTransferEntities;
using XORGame.Data.Entities.Contracts;

namespace XORGame.Data.Entities.Abilities
{
    public class MeleeAttack : AbilityActionBase, IAbilityAction, IAttack
    {
        public int BaseDamage { get; set; }

        public MeleeAttack(Ability ability) : base(ability)
        {
            BaseDamage = 10;
        }

        public bool IsValidTarget(BattleData battleData, CharacterBattleData targetedCharacter)
        {
            // TODO Change to account for characters blocking melee targets
            CharacterBattleData selectedCharacter = battleData.Characters.Where(c => c.IsSelected).FirstOrDefault();
            return (selectedCharacter != null &&
                targetedCharacter != null &&
                selectedCharacter.ID != targetedCharacter.ID &&
                selectedCharacter.TeamID != targetedCharacter.TeamID);
        }

        public void AdjustCharacterStats(BattleData battleData, CharacterBattleData targetedCharacter)
        {
            CharacterBattleData selectedCharacter = battleData.Characters.Where(c => c.IsSelected).FirstOrDefault();
            int damage = GetDamageModifier(selectedCharacter.Attack, targetedCharacter.Defense) + BaseDamage;
            int newHealth = targetedCharacter.CurrentHealth - (damage < 0 ? 0 : damage);
            targetedCharacter.CurrentHealth = newHealth < 0 ? 0 : newHealth;
        }
    }
}
