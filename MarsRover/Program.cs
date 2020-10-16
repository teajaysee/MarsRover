using System;

namespace MarsRover
{
    class Program
    {
       static void Main(string[] args)
        {

            // notes
            // if try to move outside bounds of perimiter, it will move to the edge in that direction and not throw an error
            // default plateau size is 0,0 to infinity unless set

            var plateau = new Plateau();
            plateau.SetGridSize(40, 30);

            // this needed to handle multiple rovers
            var RoverController = new RoverController(plateau);

            var rover = new Rover(RoverController);
            rover.SetPosition(10, 10, "N");
            rover.Move("R1R3L2L1");

            Console.WriteLine(rover.ToString());
            
            // if uncommented this will throw excepton as robots crash
           // var rover2 = new Rover(RoverController);
           // rover2.SetPosition(10, 10, "N");
           // rover2.Move("R1R3L2L3");
           // Console.WriteLine(rover2.ToString());

            Console.ReadLine();


        }
    }
}
