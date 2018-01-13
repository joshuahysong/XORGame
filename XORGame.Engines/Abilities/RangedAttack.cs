using System.Linq;
using XORGame.Data.DataTransferEntities;
using XORGame.Data.Entities.Contracts;

namespace XORGame.Engines.Abilities
{
    public class RangedAttack : IAbilityAction, IAttack
    {
        public int BaseDamage { get; set; }

        public RangedAttack()
        {
            BaseDamage = 10;
        }

        public bool IsValidTarget(BattleData battleData, CharacterBattleData targetedCharacter)
        {
            CharacterBattleData selectedCharacter = battleData.Characters.Where(c => c.IsSelected).FirstOrDefault();
            return (selectedCharacter != null &&
                targetedCharacter != null &&
                selectedCharacter.ID != targetedCharacter.ID &&
                targetedCharacter.IsEnemy);
        }

        public void AdjustCharacterStats(BattleData battleData, CharacterBattleData targetedCharacter)
        {
            CharacterBattleData selectedCharacter = battleData.Characters.Where(c => c.IsSelected).FirstOrDefault();
            int damage = AbilityEngine.GetDamageModifier(selectedCharacter.Attack, targetedCharacter.Defense) + BaseDamage;
            int newHealth = targetedCharacter.CurrentHealth - (damage < 0 ? 0 : damage);
            targetedCharacter.CurrentHealth = newHealth < 0 ? 0 : newHealth;
        }
    }
}
