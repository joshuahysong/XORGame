using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using XORGame.Data.Entities.Contracts;

namespace XORGame.Engines
{
    [Export]
    public class AbilityFactory
    {
        private static List<IAbility> Abilities { get; set; }

        [ImportingConstructor]
        public AbilityFactory([ImportMany] IEnumerable<IAbility> abilities)
        {
            Abilities = abilities.ToList();
        }

        public static IAbility GetAbility(string abilityName)
        {
            if (Abilities != null)
            {
                return Abilities.Where(a => a.GetType().Name.ToUpper() == abilityName.ToUpper()).FirstOrDefault();
            }
            return null;
        }
    }
}
