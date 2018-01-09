using System.Collections.Generic;

namespace XORGame.Data.Entities
{
    public class Character
    {
        public Character()
        {
            PlayerCharacters = new HashSet<PlayerCharacter>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PlayerCharacter> PlayerCharacters { get; set; }
    }
}
