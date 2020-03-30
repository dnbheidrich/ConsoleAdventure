using System;
using System.Threading;
using EscapeFromCorona.Interfaces;
using EscapeFromCorona.Models;
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
            var playerName = Console.ReadLine();
            _gs = new GameService(playerName);
            string greeting = $"Welcome to my game {playerName} ";
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
            // how would i pass playerName to the rest of the game
            Console.WriteLine($"What would you like to do ?");
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
                    _gs.Messages.Add(new Message("Not a recognized command"));
                    _gs.Look();
                    break;
            }
        }

        public void Print()
        {
            foreach (Message message in _gs.Messages)
            {

                Console.WriteLine(message.Body);
                // Console.ForegroundColor = ConsoleColor.Red;
                // Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = message.Color;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

    }
}