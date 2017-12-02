using System;
using NUnit.Framework;

namespace Mini_Roguelike.Tests
{
    [TestFixture]
    public class GameTests
    {   
        [Test]
        public void CorrectConstructor()
        {
            Assert.DoesNotThrow(() => 
                new Game(new CharGameMapReader(FileFromTestsReader.GetFile("GameBoundedMapTest.txt"))));
        }
        
        [Test]
        public void CorrectPlayerSet()
        {
            var game = new Game(
                new CharGameMapReader(FileFromTestsReader.GetFile("GameBoundedMapTest.txt")));
            game.MapChanged += (sender, args) =>
            {
                Assert.AreEqual(args.Player.X, 1);
                Assert.AreEqual(args.Player.Y, 1);
            };
            game.Start();
        }

        [Test]
        public void CorrectPlayerNoMove()
        {
            var game = new Game(
                new CharGameMapReader(FileFromTestsReader.GetFile("GameBoundedMapTest.txt")));
            game.MapChanged += (sender, args) =>
            {
                Assert.AreEqual(args.Player.X, 1);
                Assert.AreEqual(args.Player.Y, 1);
            };
            game.Start();
            game.NewGameIteration(null, new KeyPressedArgs(ConsoleKey.LeftArrow));
            game.NewGameIteration(null, new KeyPressedArgs(ConsoleKey.DownArrow));
            game.NewGameIteration(null, new KeyPressedArgs(ConsoleKey.UpArrow));
            game.NewGameIteration(null, new KeyPressedArgs(ConsoleKey.RightArrow));
        }

        [Test]
        public void CorrectPlayerMove()
        {
            var game = new Game(
                new CharGameMapReader(FileFromTestsReader.GetFile("GameFreeMapTest.txt")));
            int[] x = {0};
            int[] y = {0};
            game.MapChanged += (sender, args) =>
            {
                Assert.AreEqual(args.Player.X, x[0]);
                Assert.AreEqual(args.Player.Y, y[0]);
            };
            game.Start();
            x[0] = 1;
            game.NewGameIteration(null, new KeyPressedArgs(ConsoleKey.RightArrow));
            x[0] = 0;
            game.NewGameIteration(null, new KeyPressedArgs(ConsoleKey.LeftArrow));
            y[0] = 1;
            game.NewGameIteration(null, new KeyPressedArgs(ConsoleKey.DownArrow));
            y[0] = 0;
            game.NewGameIteration(null, new KeyPressedArgs(ConsoleKey.UpArrow));
        }
    }
}