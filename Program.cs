using System;
using EscapeFromCorona.Controllers;
using EscapeFromCorona.Interfaces;

namespace EscapeFromCorona
{
    class Program
    {
        static void Main(string[] args)
        {
             Console.Clear();
            IGameController gc = new GameController();
            gc.Run();
        }
    }
}
