using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XORGame.Data.DataTransferEntities;

namespace XORGame.Data.Entities
{
    public interface IAbility
    {
        bool IsValidTarget(BattleData battleData, int targetCharacterID);

        void AdjustCharacterStats(BattleData battleData);
    }
}
