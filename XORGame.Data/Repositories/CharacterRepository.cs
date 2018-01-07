using System.Collections.Generic;
using System.Linq;
using XORGame.Data.DataTransferEntities;

namespace XORGame.Data
{
    internal static class CharacterRepository
    {
        private static List<CharacterBattleInfo> Characters { get; set; }

        internal static List<CharacterBattleInfo> GetCharacter()
        {
            if (Characters == null)
            {
                PopulateMockCharacters();
            }
            return Characters;
        }

        internal static CharacterBattleInfo GetCharacter(int ID)
        {
            if (Characters == null)
            {
                PopulateMockCharacters();
            }
            return GetCharacter().Where(h => h.ID == ID).FirstOrDefault();
        }

        internal static void PopulateMockCharacters()
        {
            Characters = new List<CharacterBattleInfo>();
            Characters.Add(new CharacterBattleInfo()
            {
                ID = 1,
                Name = "Tanky McTankerson",
                Class = "Tank",
                TotalHealth = 200,
                CurrentHealth = 200,
                Attack = 10,
                Defense = 50,
                Speed = 300,
                IsEnemy = false,
                Location = 1
            });

            Characters.Add(new CharacterBattleInfo()
            {
                ID = 2,
                Name = "Pew Pew",
                Class = "DPS",
                TotalHealth = 50,
                CurrentHealth = 50,
                Attack = 50,
                Defense = 10,
                Speed = 500,
                IsEnemy = false,
                Location = 2
            });

            Characters.Add(new CharacterBattleInfo()
            {
                ID = 3,
                Name = "Healzlol",
                Class = "Support",
                TotalHealth = 50,
                CurrentHealth = 50,
                Attack = 10,
                Defense = 20,
                Speed = 400,
                IsEnemy = false,
                Location = 3
            });

            Characters.Add(new CharacterBattleInfo()
            {
                ID = 4,
                Name = "Mr Average",
                Class = "DPS",
                TotalHealth = 100,
                CurrentHealth = 100,
                Attack = 25,
                Defense = 25,
                Speed = 400,
                IsEnemy = false,
                Location = 4
            });

            Characters.Add(new CharacterBattleInfo()
            {
                ID = 5,
                Name = "Mr Irrelevant",
                Class = "DPS",
                TotalHealth = 50,
                CurrentHealth = 50,
                Attack = 20,
                Defense = 20,
                Speed = 300,
                IsEnemy = false,
                Location = 7
            });


            Characters.Add(new CharacterBattleInfo()
            {
                ID = 6,
                Name = "Evil Tanky McTankerson",
                Class = "Tank",
                TotalHealth = 200,
                CurrentHealth = 200,
                Attack = 10,
                Defense = 50,
                Speed = 300,
                IsEnemy = true,
                Location = 1
            });

            Characters.Add(new CharacterBattleInfo()
            {
                ID = 7,
                Name = "Pew Pew Die",
                Class = "DPS",
                TotalHealth = 50,
                CurrentHealth = 50,
                Attack = 50,
                Defense = 10,
                Speed = 500,
                IsEnemy = true,
                Location = 2
            });

            Characters.Add(new CharacterBattleInfo()
            {
                ID = 8,
                Name = "Emo Healzlol",
                Class = "Support",
                TotalHealth = 50,
                CurrentHealth = 50,
                Attack = 10,
                Defense = 20,
                Speed = 400,
                IsEnemy = true,
                Location = 3
            });

            Characters.Add(new CharacterBattleInfo()
            {
                ID = 9,
                Name = "Mr Darkly Average",
                Class = "DPS",
                TotalHealth = 100,
                CurrentHealth = 100,
                Attack = 25,
                Defense = 25,
                Speed = 400,
                IsEnemy = true,
                Location = 4
            });

            Characters.Add(new CharacterBattleInfo()
            {
                ID = 10,
                Name = "Mr Irrelevantly Angry",
                Class = "DPS",
                TotalHealth = 50,
                CurrentHealth = 50,
                Attack = 20,
                Defense = 20,
                Speed = 300,
                IsEnemy = true,
                Location = 7
            });
        }
    }
}
