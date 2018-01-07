namespace XORGame.Data.Entities
{
    public class TeamRoster
    {
        public int TeamID { get; set; }
        public int PlayerCharacterID { get; set; }
        public int Location { get; set; }

        public virtual Team Team { get; set; }
        public virtual PlayerCharacter PlayerCharacter { get; set; }
    }
}
