using System;
using System.Collections.Generic;
using System.Linq;
using XORGame.Data.DataTransferEntities;

namespace XORGame.Engines
{
    public static class BattleEngine
    {
        private static int FullTurnMeter = 1000;

        public static CharacterBattleInfo GetNextTurnCharacter(List<CharacterBattleInfo> characters)
        {
            List<CharacterBattleInfo> readyCharacters = CheckForReadyCharacters(characters);
            while (readyCharacters.Count == 0)
            {
                characters.ForEach(character =>
                {
                    character.TurnMeter += character.Speed;
                });

                readyCharacters = CheckForReadyCharacters(characters);
            }

            // Select a random readyCharacter
            characters.ForEach(c => { c.IsSelected = false; });
            CharacterBattleInfo nextCharacter = readyCharacters[new Random().Next(0, readyCharacters.Count)];
            nextCharacter.TurnMeter = 0;
            nextCharacter.IsSelected = true;
            return nextCharacter;
        }

        private static List<CharacterBattleInfo> CheckForReadyCharacters(List<CharacterBattleInfo> characters)
        {
            int maxSpeed = characters.Where(character => character.CurrentHealth > 0 &&
                character.TurnMeter >= FullTurnMeter).Any() ? characters.Where(character => character.CurrentHealth > 0 &&
                character.TurnMeter >= FullTurnMeter).Max(c => c.Speed) : 0;

            return characters
                .Where(character => character.CurrentHealth > 0 &&
                    character.TurnMeter >= FullTurnMeter &&
                    character.Speed == maxSpeed).ToList();
        }
    }
}
