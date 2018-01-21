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

        public bool IsValidTarget(BattleData battleData, Boardspace targetSpace)
        {
            // TODO Change to account for characters blocking melee targets
            CharacterBattleData selectedCharacter = battleData.Characters.Where(c => c.IsSelected).FirstOrDefault();
            return (selectedCharacter != null &&
                targetSpace.Character != null &&
                selectedCharacter.ID != targetSpace.Character.ID &&
                selectedCharacter.TeamID != targetSpace.Character.TeamID &&
                targetSpace.Character.IsAlive() &&
                !IsOnCooldown());
        }

        public void AdjustCharacterStats(BattleData battleData, Boardspace targetSpace)
        {
            CharacterBattleData selectedCharacter = battleData.Characters.Where(c => c.IsSelected).FirstOrDefault();
            int damage = GetDamageModifier(selectedCharacter.Attack, targetSpace.Character.Defense) + BaseDamage;
            int newHealth = targetSpace.Character.CurrentHealth - (damage < 0 ? 0 : damage);
            targetSpace.Character.CurrentHealth = newHealth < 0 ? 0 : newHealth;
        }
    }
}
