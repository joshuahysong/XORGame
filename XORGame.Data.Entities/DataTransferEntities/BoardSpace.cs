using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XORGame.Data.DataTransferEntities;

namespace XORGame.Data.DataTransferEntities
{
    public class Boardspace
    {
        public Point Coordinates { get; set; } 

        public CharacterBattleData Character { get; set; }

        public bool IsEqualCoordinates(Point coordinates)
        {
            return Coordinates.X == coordinates.X && Coordinates.Y == coordinates.Y;
        }
    }
}
