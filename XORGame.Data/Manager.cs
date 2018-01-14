using System.Collections.Generic;
using XORGame.Data.DataTransferEntities;
using XORGame.Data.Entities;

namespace XORGame.Data
{
    public static class Manager
    {
        public static List<CharacterBattleData> GetCharactersByTeamID(int teamID, bool IsEnemyTeam = false)
        {
            List<CharacterBattleData> characters = new List<CharacterBattleData>();
            CharacterRepository.GetTeamRoster(teamID).ForEach(roster =>
            {
                characters.Add(new CharacterBattleData()
                {
                    ID = roster.PlayerCharacter.ID,
                    TeamID = roster.TeamID,
                    Name = roster.PlayerCharacter.Name,
                    TotalHealth = roster.PlayerCharacter.Health,
                    CurrentHealth = roster.PlayerCharacter.Health,
                    Attack = roster.PlayerCharacter.Attack,
                    Defense = roster.PlayerCharacter.Defense,
                    Speed = roster.PlayerCharacter.Speed,
                    Location = roster.Location,
                    IsEnemy = IsEnemyTeam,
                    Abilities = CharacterRepository.GetPlayerCharacterAbilities(roster.PlayerCharacter)
                });
            });
            return characters;
        }

        public static Ability GetAbility(int abilityID)
        {
            return DataCache.GetAbility(abilityID);
        }

        public static Ability GetAbility(string abilityName)
        {
            return DataCache.GetAbility(abilityName);
        }
    }
}
