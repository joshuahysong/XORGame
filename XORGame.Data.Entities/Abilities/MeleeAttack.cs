using System;
using System.Collections.Generic;
using System.Drawing;
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
            CharacterBattleData selectedCharacter = battleData.Characters.Where(c => c.IsSelected).FirstOrDefault();
            Boardspace selectedCharacterSpace = battleData.Boardspaces.FirstOrDefault(bs => bs.Character?.ID == selectedCharacter.ID);
            return (selectedCharacter != null &&
                selectedCharacterSpace != null &&
                targetSpace.Character != null &&
                selectedCharacter.ID != targetSpace.Character.ID &&
                selectedCharacter.TeamID != targetSpace.Character.TeamID &&
                !IsOnCooldown() &&
                selectedCharacterSpace.Neighbors().Contains((Point?)targetSpace.Coordinates));
        }

        public void AdjustCharacterStats(BattleData battleData, Boardspace targetSpace)
        {
            CharacterBattleData selectedCharacter = battleData.Characters.Where(c => c.IsSelected).FirstOrDefault();
            int damage = GetDamageModifier(selectedCharacter.Attack, targetSpace.Character.Defense) + BaseDamage;
            int newHealth = targetSpace.Character.CurrentHealth - (damage < 0 ? 0 : damage);
            targetSpace.Character.CurrentHealth = newHealth < 0 ? 0 : newHealth;
            CheckCharacterDeathAtSpace(battleData, targetSpace);
        }
    }
}
