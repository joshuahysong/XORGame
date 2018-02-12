using System.Collections.Generic;
using System.Drawing;
using XORGame.Data.Entities;

namespace XORGame.Data.DataTransferEntities
{
    public class Boardspace
    {
        public Point Coordinates { get; set; } 

        public CharacterBattleData Character { get; set; }

        public Point? NeighborNorth { get { return Coordinates.Y - 1 < 0 ? null : (Point?)new Point(Coordinates.X, Coordinates.Y - 1); } }

        public Point? NeighborNorthEast { get { return Coordinates.X + 1 < 0 || Coordinates.Y - 1 > Constants.BoardY ? null : (Point?)new Point(Coordinates.X + 1, Coordinates.Y - 1); } }

        public Point? NeighborEast { get { return Coordinates.X + 1 > Constants.BoardX ? null : (Point?)new Point(Coordinates.X + 1, Coordinates.Y); } }

        public Point? NeighborSouthEast { get { return Coordinates.X + 1 > Constants.BoardX || Coordinates.Y + 1 > Constants.BoardY ? null : (Point?)new Point(Coordinates.X + 1, Coordinates.Y + 1); } }

        public Point? NeighborSouth { get { return Coordinates.Y + 1 > Constants.BoardY ? null : (Point?)new Point(Coordinates.X, Coordinates.Y + 1); } }

        public Point? NeighborSouthWest { get { return Coordinates.X - 1 < 0 || Coordinates.Y + 1 > Constants.BoardY ? null : (Point?)new Point(Coordinates.X - 1, Coordinates.Y + 1); } }

        public Point? NeighborWest { get { return Coordinates.X - 1 < 0 ? null : (Point?)new Point(Coordinates.X - 1, Coordinates.Y); } }

        public Point? NeighborNorthWest { get { return Coordinates.X - 1 < 0 || Coordinates.Y - 1 < 0 ? null : (Point?)new Point(Coordinates.X - 1, Coordinates.Y - 1); } }
        
        public List<Point?> Neighbors()
        {
            List<Point?> neighbors = new List<Point?>();
            neighbors.Add(NeighborNorth);
            neighbors.Add(NeighborNorthEast);
            neighbors.Add(NeighborEast);
            neighbors.Add(NeighborSouthEast);
            neighbors.Add(NeighborSouth);
            neighbors.Add(NeighborSouthWest);
            neighbors.Add(NeighborWest);
            neighbors.Add(NeighborNorthWest);
            return neighbors;
        }

        public bool IsEqualCoordinates(Point coordinates)
        {
            return Coordinates.X == coordinates.X && Coordinates.Y == coordinates.Y;
        }

        public bool IsObstructed()
        {
            if (Character != null)
            {
                return true;
            }

            return false;
        }
    }
}
