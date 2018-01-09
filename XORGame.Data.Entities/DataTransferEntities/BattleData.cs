using System.Collections.Generic;
using XORGame.Data.DataTransferEntities;

namespace XORGame.Data.DataTransferEntities
{
    public class BattleData
    {
        public List<CharacterBattleData> Characters { get; set; }

        public List<string> CombatLog { get; set; }
    }
}