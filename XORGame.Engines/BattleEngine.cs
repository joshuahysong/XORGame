using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using XORGame.Data;
using XORGame.Data.DataTransferEntities;
using XORGame.Data.Entities;

namespace XORGame.Engines
{
    public static class BattleEngine
    {        
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
            for (int y = 0; y < Constants.BoardX; y++)
            {
                for (int x = 0; x < Constants.BoardY; x++)
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
            characters.ForEach(character =>
            {
                Point? characterLocation = character.GetStartingCoordinates();
                if (characterLocation != null)
                {
                    Boardspace characterSpace = battleData.Boardspaces
                        .FirstOrDefault(boardspace => (Point?)boardspace.Coordinates == characterLocation);
                    if (characterSpace != null)
                    {
                        characterSpace.Character = character;
                    }
                }
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

            ResetCharacters(battleData);

            // Select a random readyCharacter
            CharacterBattleData nextCharacter = readyCharacters[new Random().Next(0, readyCharacters.Count)];
            SetCharacterReady(battleData, nextCharacter);
        }

        private static List<CharacterBattleData> CheckForReadyCharacters(List<CharacterBattleData> characters)
        {
            int maxSpeed = characters.Where(character => character.CurrentHealth > 0 &&
                character.TurnMeter >= Constants.FullTurnMeter).Any() ? characters.Where(character => character.CurrentHealth > 0 &&
                character.TurnMeter >= Constants.FullTurnMeter).Max(c => c.Speed) : 0;

            return characters
                .Where(character => character.CurrentHealth > 0 &&
                    character.TurnMeter >= Constants.FullTurnMeter &&
                    character.Speed == maxSpeed).ToList();
        }

        private static void SetCharacterReady(BattleData battleData, CharacterBattleData character)
        {
            character.TurnMeter = 0;
            character.IsSelected = true;
            character.Abilities.ForEach(ability =>
            {
                ability.CurrentCooldown = ability.CurrentCooldown > 0 ? ability.CurrentCooldown - 1 : 0;
                ability.ValidTargets.AddRange(battleData.Boardspaces
                    .Where(boardspace => ability.IsValidTarget(battleData, boardspace))
                    .Select(bs => bs.Coordinates).ToList());
            });
        }

        private static void ResetCharacters(BattleData battleData)
        {
            battleData.Characters.ForEach(c => {
                c.IsSelected = false;
                c.Abilities.ForEach(a =>
                {
                    a.ValidTargets = new List<Point>();
                });
            });
        }
    }
}
