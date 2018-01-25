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
    public class Move : AbilityActionBase, IAbilityAction
    {
        public Move(Ability ability) : base(ability) { }

        public bool IsValidTarget(BattleData battleData, Boardspace targetSpace)
        {
            CharacterBattleData selectedCharacter = battleData.Characters.FirstOrDefault(c => c.IsSelected);
            Boardspace selectedCharacterSpace = battleData.Boardspaces.FirstOrDefault(bs => bs.IsEqualCoordinates(selectedCharacter.Coordinates));
            return (selectedCharacter != null &&
                selectedCharacterSpace != null &&
                !IsOnCooldown() &&
                ((!targetSpace.IsObstructed() &&
                selectedCharacterSpace.Neighbors().Contains((Point?)targetSpace.Coordinates)) || 
                    targetSpace.Character?.ID == selectedCharacter.ID));
        }

        public void AdjustCharacterStats(BattleData battleData, Boardspace targetSpace)
        {
            CharacterBattleData selectedCharacter = battleData.Characters.FirstOrDefault(c => c.IsSelected);
            Boardspace currentSpace = battleData.Boardspaces.FirstOrDefault(bs => bs.IsEqualCoordinates(selectedCharacter.Coordinates));
            if (currentSpace != null)
            {
                currentSpace.Character = null;
                selectedCharacter.Coordinates = targetSpace.Coordinates;
                targetSpace.Character = selectedCharacter;
                StartCooldown();
            }
        }
    }
}