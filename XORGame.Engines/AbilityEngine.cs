using System;
using System.Collections.Generic;
using System.Linq;
using XORGame.Data.Entities.Contracts;

namespace XORGame.Engines
{
    public static class AbilityEngine
    {
        private static List<IAbilityAction> Abilities { get; set; }

        public static void Init()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IAbilityAction).IsAssignableFrom(p) && p.IsClass).ToList();
            Abilities = new List<IAbilityAction>();
            types.ForEach(t =>
            {
                Abilities.Add((IAbilityAction)Activator.CreateInstance(t));
            });
        }

        public static IAbilityAction GetAbility(string abilityName)
        {
            if (Abilities != null)
            {
                return Abilities.Where(a => a.GetType().Name.ToUpper() == abilityName.ToUpper().Replace(" ", string.Empty)).FirstOrDefault();
            }
            return null;
        }

        public static int GetDamageModifier(int attack, int defense)
        {
            return ((attack - defense) / 10) + 1;
        }
    }
}
