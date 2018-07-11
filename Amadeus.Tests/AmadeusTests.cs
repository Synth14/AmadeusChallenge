using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amadeus;
using System;
using System.Collections.Generic;

namespace Amadeus.Tests
{
    [TestClass]
    public class AmadeusTests
    {
        Game game;

        [TestInitialize]
        public void SetUp() {
            game = new Game();
            game.Edges = new List<Edge>();
            game.Planets = new List<Planet>();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Init("Test1.txt");
            var retour = game.Loop();
            int i = 0;
            Assert.AreEqual(6, retour.Count);
            Assert.IsTrue( int.TryParse(retour[0],out i));
            Assert.IsTrue( int.TryParse(retour[1],out i));
            Assert.IsTrue( int.TryParse(retour[2],out i));
            Assert.IsTrue( int.TryParse(retour[3],out i));
            Assert.IsTrue( int.TryParse(retour[4],out i));
            Assert.AreEqual(retour[5], "NONE");
        }
        [TestMethod]
        public void TestMethod2()
        {
            Init("Test2.txt");
            var retour = game.Loop();
            int i = 0;
            Assert.AreEqual(6, retour.Count);
            Assert.IsTrue( int.TryParse(retour[0],out i));
            Assert.IsTrue( int.TryParse(retour[1],out i));
            Assert.IsTrue( int.TryParse(retour[2],out i));
            Assert.IsTrue( int.TryParse(retour[3],out i));
            Assert.IsTrue( int.TryParse(retour[4],out i));
            Assert.AreEqual(retour[5], "NONE");
        }

        private void Init(string fileName)
        {
            int counter = 0;  
            string line;
            string[] inputs;  
            System.IO.StreamReader file =   
                new System.IO.StreamReader(@"..\..\..\..\Amadeus.Tests\" + fileName);  
            while((line = file.ReadLine()) != null)  
            {
                if(counter == 0)
                {
                    inputs = line.Split(' ');
                    game.PlanetCount = int.Parse(inputs[0]);
                    game.EdgeCount = int.Parse(inputs[1]);
                }  else if (counter < game.EdgeCount + 1) {
                    inputs = line.Split(' ');
                    game.Edges.Add( new Edge { PlanetA = int.Parse(inputs[0]),
                        PlanetB = int.Parse(inputs[1])});
                } else {
                    inputs = line.Split(' ');
                    game.Planets.Add( new Planet {
                        ID = counter - game.EdgeCount,
                        MyUnits = int.Parse(inputs[0]),
                        MyTolerance = int.Parse(inputs[1]),
                        OtherUnits = int.Parse(inputs[2]),
                        OtherTolerance = int.Parse(inputs[3]),
                        CanAssign = int.Parse(inputs[4])
                    });
                }
                counter++;
            }
            file.Close();  
        }
    }
}
