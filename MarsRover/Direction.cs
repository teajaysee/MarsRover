using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
   public enum Direction
    {
        North, East, South, West
    };

    public class DirectionParser
    {

        public static string GetString(Direction direction)
        {
            return direction switch
            {
                Direction.North => "N",
                Direction.South => "S",
                Direction.East => "E",
                Direction.West => "W",
                _ => throw new Exception()
            };

        }

    public static Direction ParseString(string direction)
        {
            switch (direction) {
                case "N":
                    return Direction.North;
                case "S":
                    return Direction.South;
                case "E":
                    return Direction.East;
                case "W":
                    return Direction.West;
                default:
                    throw new ArgumentException("Invalid Direction given: Acceptable values are N,S,W,E");

            }
        }
    }

}
