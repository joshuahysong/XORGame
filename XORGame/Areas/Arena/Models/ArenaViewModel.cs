using System.Collections.Generic;
using XORGame.Data.DataTransferEntities;

namespace XORGame.Areas.Arena.Models
{
    public class ArenaViewModel
    {
        public List<CharacterBattleInfo> Characters { get; set; }

        public CharacterBattleInfo NextCharacter { get; set; }

        public List<string> CombatLog { get; set; }
    }
}