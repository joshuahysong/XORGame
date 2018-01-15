using System;
using System.Collections.Generic;
using System.Linq;
using XORGame.Data.DataTransferEntities;
using XORGame.Data.Entities;
using XORGame.Data.Entities.Contracts;

namespace XORGame.Data
{
    public static class Manager
    {
        private static List<Type> AbilityActionAssemblies { get; set; }

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
                    Abilities = GetBattleAbilities(roster.PlayerCharacter)
                });
            });
            return characters;
        }

        private static List<IAbilityAction> GetBattleAbilities(PlayerCharacter character)
        {
            if (AbilityActionAssemblies == null)
            {
                AbilityActionAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IAbilityAction).IsAssignableFrom(p)).ToList();
            }

            List<IAbilityAction> abilities = new List<IAbilityAction>();
            CharacterRepository.GetPlayerCharacterAbilities(character).ForEach(ability =>
            {
                Type abilityActionAssembly = AbilityActionAssemblies.FirstOrDefault(t => t.Name.ToUpper() == ability.Name.ToUpper().Replace(" ", string.Empty));
                if (abilityActionAssembly != null)
                {
                    IAbilityAction abilityAction = (IAbilityAction)Activator.CreateInstance(abilityActionAssembly, ability);
                    abilities.Add(abilityAction);
                }
            });
            return abilities;
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
