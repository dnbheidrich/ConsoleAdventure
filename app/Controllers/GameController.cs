using System;
using System.Threading;
using EscapeFromCorona.Interfaces;
using EscapeFromCorona.Services;

namespace EscapeFromCorona.Controllers
{
    class GameController : IGameController
    {
        private IGameService _gs { get; set; }
        private bool _running { get; set; } = true;
        public void Run()
        {
            Console.WriteLine("Hello there what is your name?");
            _gs = new GameService(Console.ReadLine());
            string greeting = "Welcome to my game";
            foreach (char letter in greeting)
            {
                Console.Write(letter);
                Thread.Sleep(100);
            }
            Console.WriteLine();
            Print();
            while (_running)
            {
                GetUserInput();
                Print();
            }
        }
        public void GetUserInput()
        {
            
            Console.WriteLine("What would you like to do?");
            string input = Console.ReadLine().ToLower() + " "; 
            string command = input.Substring(0, input.IndexOf(" "));
            string option = input.Substring(input.IndexOf(" ") + 1).Trim();

            Console.Clear();
            switch (command)
            {
                case "quit":
                    _running = false;
                    break;
                     case "help":
                     _gs.Help();
                    break;
                case "reset":
                    _gs.Reset();
                    break;
                case "look":
                    _gs.Look();
                    break;
                case "inventory":
                    _gs.Inventory();
                    break;
                case "go":
                    _running = _gs.Go(option);
                    break;
                case "take":
                    _gs.Take(option);
                    break;
                case "use":
                    _gs.Use(option);
                    break;
                default:
                    _gs.Messages.Add("Not a recognized command");
                    _gs.Look();
                    break;
            }
        }

        public void Print()
        {
            foreach (string message in _gs.Messages)
            {
                Console.WriteLine(message);
            }
            _gs.Messages.Clear();
        }

    }
}