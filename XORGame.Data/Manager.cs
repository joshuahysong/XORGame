using System.Collections.Generic;
using XORGame.Data.DataTransferEntities;

namespace XORGame.Data
{
    public static class Manager
    {
        public static List<CharacterBattleInfo> GetCharacters()
        {
            return CharacterRepository.GetCharacter();
        }

        public static CharacterBattleInfo GetCharacter(int ID)
        {
            return CharacterRepository.GetCharacter(ID);
        }
    }
}
