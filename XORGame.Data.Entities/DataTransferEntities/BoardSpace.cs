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
    }
}
