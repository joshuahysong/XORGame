using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XORGame.Data.Entities;

namespace XORGame.Data.Repositories
{
    public static class AbilityRepository
    {
        internal static List<Ability> GetAbilities()
        {
            using (XORGameContext db = new XORGameContext())
            {
                return db.Abilities.ToList();
            }
        }
    }
}
