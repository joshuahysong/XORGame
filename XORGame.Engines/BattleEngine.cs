using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using XORGame.Data;
using XORGame.Data.DataTransferEntities;

namespace XORGame.Engines
{
    public static class BattleEngine
    {
        public const int FullTurnMeter = 1000;
        public const int BoardX = 5;
        public const int BoardY = 5;

        public static BattleData GenerateBattleData(int friendlyTeamID, int enemyTeamID)
        {
            BattleData battleData = new BattleData();
            GenerateBoard(battleData);

            List<CharacterBattleData> characters = new List<CharacterBattleData>();
            characters.AddRange(Manager.GetCharactersByTeamID(friendlyTeamID, false));
            characters.AddRange(Manager.GetCharactersByTeamID(enemyTeamID, true));
            PopulateBoard(battleData, characters);

            AdvanceTurnMeters(battleData);

            return battleData;
        }

        private static void GenerateBoard(BattleData battleData)
        {
            battleData.Boardspaces = new List<Boardspace>();
            for (int y = 0; y < BoardX; y++)
            {
                for (int x = 0; x < BoardY; x++)
                {
                    battleData.Boardspaces.Add(new Boardspace
                    {
                        Coordinates = new Point(x, y),
                        Character = null
                    });
                }
            }
        }

        private static void PopulateBoard(BattleData battleData, List<CharacterBattleData> characters)
        {
            characters.ForEach(character => character.CalcuateStartingCoordinates());

            battleData.Boardspaces.ForEach(boardSpace =>
            {
                boardSpace.Character = characters.FirstOrDefault(character =>
                    boardSpace.IsEqualCoordinates(character.Coordinates));
            });
        }

        public static void AdvanceTurnMeters(BattleData battleData)
        {
            List<CharacterBattleData> readyCharacters = CheckForReadyCharacters(battleData.Characters);
            while (readyCharacters.Count == 0)
            {
                battleData.Characters.ForEach(character =>
                {
                    character.TurnMeter += character.Speed;
                });

                readyCharacters = CheckForReadyCharacters(battleData.Characters);
            }

            // Select a random readyCharacter
            battleData.Characters.ForEach(c => { c.IsSelected = false; });
            CharacterBattleData nextCharacter = readyCharacters[new Random().Next(0, readyCharacters.Count)];
            SetCharacterReady(nextCharacter);
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

        private static void SetCharacterReady(CharacterBattleData character)
        {
            character.TurnMeter = 0;
            character.IsSelected = true;
            character.Abilities.ForEach(ability =>
            {
                ability.CurrentCooldown = ability.CurrentCooldown > 0 ? ability.CurrentCooldown - 1 : 0;
            });
        }
    }
}
