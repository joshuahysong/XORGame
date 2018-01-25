using System;
using System.Collections.Generic;
using System.Drawing;
using XORGame.Data.Entities;
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

        public Point Coordinates { get; set; }

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

        public bool IsAlive()
        {
            return CurrentHealth > 0;
        }

        public void CalcuateStartingCoordinates()
        {
            if (IsEnemy)
            {
                switch (Location)
                {
                    case 0:
                        Coordinates = new Point(4, 1);
                        break;
                    case 1:
                        Coordinates = new Point(3, 1);
                        break;
                    case 2:
                        Coordinates = new Point(2, 1);
                        break;
                    case 3:
                        Coordinates = new Point(1, 1);
                        break;
                    case 4:
                        Coordinates = new Point(0, 1);
                        break;
                    case 5:
                        Coordinates = new Point(4, 0);
                        break;
                    case 6:
                        Coordinates = new Point(3, 0);
                        break;
                    case 7:
                        Coordinates = new Point(2, 0);
                        break;
                    case 8:
                        Coordinates = new Point(1, 0);
                        break;
                    case 9:
                        Coordinates = new Point(0, 0);
                        break;
                }
            }
            else
            {
                switch (Location)
                {
                    case 0:
                        Coordinates = new Point(0, 3);
                        break;
                    case 1:
                        Coordinates = new Point(1, 3);
                        break;
                    case 2:
                        Coordinates = new Point(2, 3);
                        break;
                    case 3:
                        Coordinates = new Point(3, 3);
                        break;
                    case 4:
                        Coordinates = new Point(4, 3);
                        break;
                    case 5:
                        Coordinates = new Point(0, 4);
                        break;
                    case 6:
                        Coordinates = new Point(1, 4);
                        break;
                    case 7:
                        Coordinates = new Point(2, 4);
                        break;
                    case 8:
                        Coordinates = new Point(3, 4);
                        break;
                    case 9:
                        Coordinates = new Point(4, 4);
                        break;
                }
            }
        }
    }
}
