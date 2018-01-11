using XORGame.Data.DataTransferEntities;

namespace XORGame.Data.Entities.Contracts
{
    public interface IAbility
    {
        bool IsValidTarget(BattleData battleData, int targetCharacterID);

        void AdjustCharacterStats(BattleData battleData, int targetCharacterID);
    }
}
