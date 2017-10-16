using System;

namespace Mini_Roguelike
{
    public class MapPrinter
    {
        internal void PrintMap(object sender, GameMapChangedArgs args)
        {
            var i = 0;
            foreach (var line in args.GameMap)
            {
                var j = 0;
                foreach (var symb in line)
                {
                    if (i == args.Player.Y && j == args.Player.X)
                    {
                        Console.Write('@');
                    }
                    else
                    {
                        Console.Write(symb ? '#' : '.');
                    }
                    j++;
                }
                Console.WriteLine();
                i++;
            }
        }
    }
}