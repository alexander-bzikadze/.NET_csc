using System;
using System.IO;

namespace Mini_Roguelike
{
    internal class ConsoleApplication
    {
        public static void Main(string[] args)
        {
            Game game;
            try
            {
                game = new Game(args.Length != 0 ? new CharGameMapReader(args[1]) : new CharGameMapReader());
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Please, mark a gamemap file or add gameMap.txt file in the directory of the executable and restart.");
                return;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            var keyGetter = new KeyGetter();
            var mapPrinter = new MapPrinter();

            keyGetter.GotChar += game.NewGameIteration;
            game.GameContinues += keyGetter.GetKey;
            game.MapChanged += mapPrinter.PrintMap;
            
            game.Start();
            
            keyGetter.GotChar -= game.NewGameIteration;
            game.GameContinues -= keyGetter.GetKey;
            game.MapChanged -= mapPrinter.PrintMap;
        }
    }
}