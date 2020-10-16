using System;
using System.Collections.Generic;
using System.Text;
using static MarsRover.CommandInterpreter;

namespace MarsRover
{
    // could be in seperate file but for sake of clairty left here
    public class Command
    {
        public TurnDirection TurnDirection { get; set; }
        public int StepsToMove { get; set; }

        public Command(TurnDirection turnDirection, int stepsToMove)
        {
            TurnDirection = turnDirection;
            StepsToMove = stepsToMove;
        }

    }

}
