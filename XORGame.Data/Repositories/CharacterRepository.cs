using System.Collections.Generic;
using System.Linq;
using XORGame.Data.Entities;
using System.Data.Entity;

namespace XORGame.Data
{
    internal static class CharacterRepository
    {
        internal static List<TeamRoster> GetTeamRoster(int teamID)
        {
            using (XORGameContext db = new XORGameContext())
            {
                return db.TeamRosters.Include(x => x.PlayerCharacter.Character).Include(x => x.Team).Where(tr => tr.TeamID == teamID).ToList();
            }
        }

        internal static List<Ability> GetPlayerCharacterAbilities(PlayerCharacter playerCharacter)
        {
            using (XORGameContext db = new XORGameContext())
            {
                return db.PlayerCharacterAbilities.Where(pc => pc.PlayerCharacterID == playerCharacter.ID).Select(a => a.Ability).ToList();
            }
        }
    }
}
