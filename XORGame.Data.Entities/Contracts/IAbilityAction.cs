using System.Collections.Generic;
using System.Drawing;
using XORGame.Data.DataTransferEntities;

namespace XORGame.Data.Entities.Contracts
{
    public interface IAbilityAction
    {
        int ID { get; set; }

        string Name { get; set; }

        string Type { get; set; }

        string EffectArea { get; set; }

        int Cooldown { get; set; }

        string Description { get; set; }

        int CurrentCooldown { get; set; }

        List<Point> ValidTargets { get; set; }

        bool IsOnCooldown();

        void StartCooldown();

        bool IsValidTarget(BattleData battleData, Boardspace targetSpace);

        void AdjustCharacterStats(BattleData battleData, Boardspace targetSpace);
    }
}
