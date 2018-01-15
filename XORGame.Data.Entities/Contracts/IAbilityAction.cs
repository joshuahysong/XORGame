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

        bool IsValidTarget(BattleData battleData, CharacterBattleData targetedCharacter);

        void AdjustCharacterStats(BattleData battleData, CharacterBattleData targetCharacter);
    }
}
