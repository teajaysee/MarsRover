using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace MarsRover
{

    // this enables handling multiple rovers
    public class RoverController
    {

        public List<Rover> ActiveRovers { get; } = new List<Rover>();
        public Plateau Plateau { get; private set; }

        public RoverController(Plateau plateau)
        {
            Plateau = plateau;
        }

        public void AddRover (Rover rover)
        {
            ActiveRovers.Add(rover);
        }

        // check Rover wont crash into another
        public void CheckRoverMoveIsPossible(Rover rover, Direction moveDirection, int steps)
        {
            var otherRoverQuery = ActiveRovers.Where(x => x != rover);
            if (moveDirection == Direction.East || moveDirection == Direction.West)
            {
                // if moving horizontally, for there to be a crash must be on same Y positin
                otherRoverQuery = otherRoverQuery.Where(x => x.Y == rover.Y);
                if (moveDirection == Direction.East)
                    otherRoverQuery = otherRoverQuery.Where(x => x.X > rover.X && x.X <= (rover.X + steps));
                else
                    otherRoverQuery = otherRoverQuery.Where(x => x.X < rover.X && x.X >= (rover.X - steps));

             }
            else
            {
                otherRoverQuery = otherRoverQuery.Where(x => x.X == rover.X);
                if (moveDirection == Direction.North)
                    otherRoverQuery = otherRoverQuery.Where(x => x.Y > rover.Y && x.Y <= (rover.Y + steps));
                else
                    otherRoverQuery = otherRoverQuery.Where(x => x.Y < rover.Y && x.Y >= (rover.Y - steps));


            }

            var anyRovers = otherRoverQuery.Count();
            if (anyRovers > 0)
                throw new Exception("CRASH");

        }



    }
}
