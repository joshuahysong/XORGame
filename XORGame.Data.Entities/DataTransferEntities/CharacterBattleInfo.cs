﻿using System;

namespace XORGame.Data.DataTransferEntities
{
    public class CharacterBattleInfo
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Class { get; set; }

        public int TotalHealth { get; set; }

        public int CurrentHealth { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int Speed { get; set; }

        public int TurnMeter { get; set; }

        public bool IsEnemy { get; set; }

        public bool IsSelected { get; set; }

        public int Location { get; set; }

        public decimal HealthPercentage
        {
            get
            {
                return (Convert.ToDecimal(CurrentHealth) / Convert.ToDecimal(TotalHealth)) * 100;
            }
        }

        public decimal TurnMeterPercentage
        {
            get
            {
                return (Convert.ToDecimal(TurnMeter) / Convert.ToDecimal(1000)) * 100;
            }
        }
    }
}
