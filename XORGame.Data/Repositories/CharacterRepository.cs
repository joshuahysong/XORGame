using System.Collections.Generic;
using System.Linq;
using XORGame.Data.Data;
using XORGame.Data.DataTransferEntities;
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
                return db.TeamRosters.Include(x => x.PlayerCharacter).Include(x => x.Team).Where(tr => tr.TeamID == teamID).ToList();
            }
        }
    }
}
