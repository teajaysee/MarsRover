using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MarsRover
{

    
  public  class CommandInterpreter
    {
        public enum TurnDirection
        {
            Left, Right
        }


        // ie the L or R to Enum
        static TurnDirection InterpretTurnDirectionString(char turnDirection)
        {
            if (turnDirection == 'R')
                return TurnDirection.Right;
            else if (turnDirection == 'L')
                return TurnDirection.Left;
            else throw new ArgumentException("Invalid Turn Direction: Expected R or L");
        }

        public static List<Command> InterpretCommandString(string commands)
        {

            // would prob be better to use a regex split, that could also validate the commands string too

            List<Command> Results = new List<Command>();
            
            var commandsCharArray = commands.ToCharArray();

            // find indexes of start of each new command by looking up L and R
            var seperatedCommands = Enumerable.Range(0, commandsCharArray.Count() - 1)
                .Where(x => commandsCharArray[x] == 'R' || commandsCharArray[x] == 'L')
                .Select(x => x).ToList();
                
            // go through and extract each command from the string
            for (int i = 0; i < seperatedCommands.Count(); i ++)
            {
                int startIndex = seperatedCommands[i];
                char turnDirection = commandsCharArray[startIndex];
                string howFarToMoveStr = i == seperatedCommands.Count() - 1 ?
                    commands.Substring(startIndex + 1) :
                    commands.Substring(startIndex + 1, seperatedCommands[i + 1] -1 - startIndex);
                int howFarToMove = int.Parse(howFarToMoveStr);

                Results.Add(
               new Command( InterpretTurnDirectionString (turnDirection), howFarToMove)
              );

            }

            return Results;

        }

    } // class commandproccessor
}
