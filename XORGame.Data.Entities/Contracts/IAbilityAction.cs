using XORGame.Data.DataTransferEntities;

namespace XORGame.Data.Entities.Contracts
{
    public interface IAbilityAction
    {
        bool IsValidTarget(BattleData battleData, CharacterBattleData targetedCharacter);

        void AdjustCharacterStats(BattleData battleData, CharacterBattleData targetCharacter);
    }
}
