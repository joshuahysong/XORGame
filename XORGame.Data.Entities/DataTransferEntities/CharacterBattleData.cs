using System;
using System.Collections.Generic;
using System.Drawing;
using XORGame.Data.Entities.Contracts;

namespace XORGame.Data.DataTransferEntities
{
    public class CharacterBattleData
    {
        public int ID { get; set; }

        public int TeamID { get; set; }

        public string Name { get; set; }

        public int TotalHealth { get; set; }

        public int CurrentHealth { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int Speed { get; set; }

        public int Location { get; set; }

        public string SpritesPath { get; set; }

        public string Facing { get; set; }

        public int TurnMeter { get; set; }

        public bool IsEnemy { get; set; }

        public bool IsSelected { get; set; }

        public List<IAbilityAction> Abilities { get; set;}

        public decimal HealthPercentage
        {
            get
            {
                return TotalHealth > 0 ? (Convert.ToDecimal(CurrentHealth) / Convert.ToDecimal(TotalHealth)) * 100 : 1;
            }
        }

        public decimal TurnMeterPercentage
        {
            get
            {
                return (Convert.ToDecimal(TurnMeter) / Convert.ToDecimal(1000)) * 100;
            }
        }

        public Point? GetStartingCoordinates()
        {
            if (IsEnemy)
            {
                switch (Location)
                {
                    case 0:
                        return new Point(4, 1);
                    case 1:
                        return new Point(3, 1);
                    case 2:
                        return new Point(2, 1);
                    case 3:
                        return new Point(1, 1);
                    case 4:
                        return new Point(0, 1);
                    case 5:
                        return new Point(4, 0);
                    case 6:
                        return new Point(3, 0);
                    case 7:
                        return new Point(2, 0);
                    case 8:
                        return new Point(1, 0);
                    case 9:
                        return new Point(0, 0);
                }
            }
            else
            {
                switch (Location)
                {
                    case 0:
                        return new Point(0, 3);
                    case 1:
                        return new Point(1, 3);
                    case 2:
                        return new Point(2, 3);
                    case 3:
                        return new Point(3, 3);
                    case 4:
                        return new Point(4, 3);
                    case 5:
                        return new Point(0, 4);
                    case 6:
                        return new Point(1, 4);
                    case 7:
                        return new Point(2, 4);
                    case 8:
                        return new Point(3, 4);
                    case 9:
                        return new Point(4, 4);
                }
            }

            return null;
        }
    }
}
