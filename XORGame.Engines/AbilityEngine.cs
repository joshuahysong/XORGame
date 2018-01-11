namespace XORGame.Engines
{
    public static class AbilityEngine
    {
        public static int GetDamageModifier(int attack, int defense)
        {
            return ((attack - defense) / 10) + 1;
        }
    }
}
