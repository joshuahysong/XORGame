using System.Collections.Generic;
using System.Linq;

namespace XORGame.Data.DataTransferEntities
{
    public class BattleData
    {
        public List<Boardspace> Boardspaces { get; set; }

        public List<CharacterBattleData> Characters
        {
            get
            {
                return Boardspaces?.Where(bs => bs.Character != null).Select(bs => bs.Character).ToList();
            }
        }

        public int FriendlyTeamID { get; set; }

        public int EnemyTeamID { get; set; }
    }
}