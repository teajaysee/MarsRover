using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RoverTests
{
    [TestClass]
    public class When_Moving_Rover
    {
        [TestMethod]
        public void Valid_Command_Sequence_Movement_Is_Successful()
        {
            var plateau = new Plateau();
            var RoverController = new RoverController(plateau);

            var rover = new Rover(RoverController);
            rover.SetPosition(10, 10, "N");
            rover.Move("R1R3L2L1");
            Assert.AreEqual<int>(rover.X, 13);
            Assert.AreEqual<int>(rover.Y, 8);
            Assert.AreEqual<Direction>(rover.Direction, Direction.North);
        }

        // i implemented it so if tries to go beyond plateau, it sticks to edge rather than falls off
        [TestMethod]
        public void Command_Sequence_Doesnt_Move_Off_Plateau()
        {

            var plateau = new Plateau();
            plateau.SetGridSize(40, 40);

            var RoverController = new RoverController(plateau);

            var rover = new Rover(RoverController);
            rover.SetPosition(10, 10, "N");
            rover.Move("R100");
            Assert.AreEqual<int>(rover.X, 40);

        }

        [TestMethod]
        public void Command_Sequence_Causes_Two_Rovers_Crash()
        {
            var plateau = new Plateau();
            plateau.SetGridSize(40, 30);

            // this needed to handle multiple rovers
            var RoverController = new RoverController(plateau);

            var rover = new Rover(RoverController);
            rover.SetPosition(10, 10, "N");
            rover.Move("R1R3L2L1");

            
             var rover2 = new Rover(RoverController);
             rover2.SetPosition(10, 10, "N");



            Assert.ThrowsException<Exception>(() => { rover2.Move("R1R3L2L3"); });

        }
    }
}

        


    

