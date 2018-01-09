using System.Collections.Generic;

namespace XORGame.Data.Entities
{
    public class Team
    {
        public Team()
        {
            TeamRosters = new HashSet<TeamRoster>();
        }

        public int ID { get; set; }
        public int PlayerID { get; set; }
        public string Name { get; set; }

        public virtual Player Player { get; set; }
        public virtual ICollection<TeamRoster> TeamRosters { get; set; }
    }
}
