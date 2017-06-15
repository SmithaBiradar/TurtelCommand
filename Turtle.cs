using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurtleSim
{
    /// <summary>
    /// Turtle class receives instructions from the driver.
    /// </summary>
    public class Turtle
    {
        public Turtle()
        {
            LastError = "";
        }

        private const int TABLE_SIZE = 5;
        private int? xAxis;
        private int? yAxis;
        private Facing _facing;

        public string LastError { get; set; }

        public bool Place(int x, int y, Facing facing)
        {            
            if (TurtleInActionOnTable(x, y, "placed"))
            {
                xAxis = x;
                yAxis = y;
                _facing = facing;
                return true;
            }
            return false;
        }

        public bool Move()
        { 
            if (TurtleIsPlaced("move"))
            {
                int newx = GetXAxisAfterMove();
                int newy = GetYAxisfterMove();
                if (TurtleInActionOnTable(newx, newy, "moved"))
                {
                    xAxis = newx;
                    yAxis = newy;
                    return true;
                }                
            }
            return false;
        }

        private int GetXAxisAfterMove()
        {
            if (_facing == Facing.East)
            {
                return xAxis.Value + 1;
            }
            else 
            {
                if (_facing == Facing.West) 
                {
                    return xAxis.Value - 1;
                }
            }
            return xAxis.Value;
        }

        private int GetYAxisfterMove()
        {
            if (_facing == Facing.North)
            {
                return yAxis.Value + 1;
            }
            else
            {
                if (_facing == Facing.South)
                {
                    return yAxis.Value - 1;
                }
            }
            return yAxis.Value;
        }

        public bool Left()
        {
            return Turn(Direction.Left);
        }

        public bool Right()
        {
            return Turn(Direction.Right);
        }

        private bool Turn(Direction direction)
        {
            if (TurtleIsPlaced("turn"))
            {
                var facingValue = (int)_facing;
                facingValue += 1 * (direction == Direction.Right ? 1 : -1);
                if (facingValue == 5) facingValue = 1;
                if (facingValue == 0) facingValue = 4;
                _facing = (Facing)facingValue;
                return true;
            }
            return false;
        }

        public string Report()
        {
            if (TurtleIsPlaced("report it's position"))
            {
                return String.Format("{0},{1},{2}", xAxis.Value, yAxis.Value, _facing.ToString().ToUpper());
            }
            return "";
        }

        private bool TurtleIsPlaced(string action)
        {
            if (!xAxis.HasValue || !yAxis.HasValue)
            {
                LastError = String.Format("Turtle cannot {0} until it has been placed on the table.", action);
                return false;
            }
            return true;
        }

        private bool TurtleInActionOnTable(int x, int y, string action)
        {
            if (x < 0 || y < 0 || x >= TABLE_SIZE || y >= TABLE_SIZE)
            {
                LastError = String.Format("Turtle cannot be {0} there.", action);
                return false;
            }
            return true;
        }
    }
}