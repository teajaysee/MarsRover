using System;
using System.Collections.Generic;
using System.Text;
using static MarsRover.CommandInterpreter;

namespace MarsRover
{
    public class Rover
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Direction Direction { get; private set; }

        public RoverController RoverController { get; private set; }
        public Plateau Plateau => RoverController.Plateau;

        public Rover (RoverController roverController)
        {
            RoverController = roverController;
            roverController.AddRover(this);
            //Plateau = plateau;
        }

        public void SetPosition(int x, int y, string direction)
        {
            if (x < 0)
                throw new ArgumentException("Invalid x value");

            if (y < 0)
                throw new ArgumentException("Invalid y value");

            if (Plateau.GridMaxX > 0 && x >  Plateau.GridMaxX)
                throw new ArgumentException("Invalid x value");

            if (Plateau.GridMaxY > 0 && y > Plateau.GridMaxY)
                throw new ArgumentException("Invalid y value");


            X = x;
            Y = y;
            Direction = DirectionParser.ParseString(direction);
        }

        public void Move (string commands)
        {
          var interpretedCommands =    CommandInterpreter.InterpretCommandString(commands);
            foreach (var c in interpretedCommands)
            {
                if (c.TurnDirection == TurnDirection.Right)
                    TurnRight();
                else if (c.TurnDirection == TurnDirection.Left)
                    TurnLeft();
                else throw new Exception("Invalid turn direction somehow");

                MoveInDirectionFacing(c.StepsToMove);
            }
        }

        public void MoveInDirectionFacing(int steps) 
        {

            // check wont crash
            RoverController.CheckRoverMoveIsPossible(this, this.Direction, steps);

            switch (this.Direction)
            {
                case Direction.North:
                    if (Plateau.GridMaxY > 0 && Y + steps > Plateau.GridMaxY)
                        Y = Plateau.GridMaxY;
                    else
                        Y += steps;
                    break;
                case Direction.East:
                    if (Plateau.GridMaxX > 0 &&  X + steps > Plateau.GridMaxX)
                        X = Plateau.GridMaxX;
                    else
                        X += steps;
                    break;
                case Direction.South:
                    if (Y - steps < 0)
                        Y = 0;
                    else
                         Y -= steps;
                    break;
                case Direction.West:
                    if (X - steps < 0)
                        X = 0;
                    else
                        X -= steps;
                    break;
            };

        }

        public void TurnRight ()
        {

            this.Direction=
            this.Direction switch
            {
                 Direction.North =>  Direction.East,
                 Direction.East => Direction.South,
                 Direction.South => Direction.West,
                 Direction.West => Direction.North,
               _ => throw new ArgumentException(message: "invalid enum value")
            };
            
        }

        public void TurnLeft()
        {

            this.Direction =
            this.Direction switch
            {
                Direction.North => Direction.West,
                Direction.East => Direction.North,
                Direction.South => Direction.East,
                Direction.West => Direction.South,
                _ => throw new ArgumentException(message: "invalid enum value")
            };

        }

        public override string ToString()
        {
            return $"{X} {Y} {DirectionParser.GetString(Direction)}";
        }


    }
}
