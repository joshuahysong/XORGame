using System.Collections.Generic;

namespace XORGame.Data.Entities
{
    public class Player
    {
        public Player()
        {
            PlayerCharacters = new HashSet<PlayerCharacter>();
            Teams = new HashSet<Team>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }

        public virtual ICollection<PlayerCharacter> PlayerCharacters { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
