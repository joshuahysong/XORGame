namespace XORGame.Data.Entities
{
    public class PlayerCharacterAbility
    {
        public int AbilityID { get; set; }
        public int PlayerCharacterID { get; set; }
        public int Level { get; set; }

        public virtual Ability Ability { get; set; }
        public virtual PlayerCharacter PlayerCharacter { get; set; }
    }
}
