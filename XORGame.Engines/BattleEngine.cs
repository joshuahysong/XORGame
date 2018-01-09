using System;
using System.Collections.Generic;
using System.Linq;
using XORGame.Data;
using XORGame.Data.DataTransferEntities;

namespace XORGame.Engines
{
    public static class BattleEngine
    {
        // TODO Move to config
        private static int FullTurnMeter = 1000;

        public static BattleData GenerateBattleData(int friendlyTeamID, int enemyTeamID)
        {
            List<CharacterBattleData> characters = new List<CharacterBattleData>();
            characters.AddRange(Manager.GetCharactersByTeamID(friendlyTeamID, false));
            characters.AddRange(Manager.GetCharactersByTeamID(enemyTeamID, true));
            AdvanceTurnMeters(characters);
            return new BattleData
            {
                Characters = characters,
                FriendlyTeamID = friendlyTeamID,
                EnemyTeamID = enemyTeamID,
                CombatLog = new List<string>()                
            };
        }

        public static void AdvanceTurnMeters(List<CharacterBattleData> characters)
        {
            List<CharacterBattleData> readyCharacters = CheckForReadyCharacters(characters);
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
            CharacterBattleData nextCharacter = readyCharacters[new Random().Next(0, readyCharacters.Count)];
            nextCharacter.TurnMeter = 0;
            nextCharacter.IsSelected = true;
        }

        private static List<CharacterBattleData> CheckForReadyCharacters(List<CharacterBattleData> characters)
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
