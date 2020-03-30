using System;
using System.Collections.Generic;
using System.Linq;
using EscapeFromCorona.Interfaces;
using EscapeFromCorona.Models;

namespace EscapeFromCorona.Services

{
    class GameService : IGameService
    {
        public List<Message> Messages { get; set; }
        private IGame _game { get; set; }

        public GameService(string playerName)
        {
            Messages = new List<Message>();
            _game = new Game();
            _game.CurrentPlayer = new Player(playerName);
            Look();
        }


    public bool Go(string direction)
        {
            //if the current room has that direction on the exits dictionary
            if (_game.CurrentRoom.Exits.ContainsKey(direction))
            {
                // set current room to the exit room
                _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
                // populate messages with room description
                Messages.Add(new Message($"You Travel {direction}, and discover: ", ConsoleColor.White));
                Look();

                EndRoom end = _game.CurrentRoom as EndRoom;
                if (end != null)
                {
                    Messages.Add(new Message(end.Narrative, ConsoleColor.Red));
                    return false;
                }
                return true;
            }
            //no exit in that direction
            Messages.Add(new Message("No Room in that direction", ConsoleColor.Red));
            Console.Clear();
            Look();
            return true;
        }

        public void Help()
        {
            Messages.Add(new Message("This is help", ConsoleColor.Blue));
            Messages.Add(new Message("(go) to go in direction (go weast)", ConsoleColor.Blue));
            Messages.Add(new Message("(look) to see room", ConsoleColor.Blue));
            Messages.Add(new Message("(take) to take item", ConsoleColor.Blue));
            Messages.Add(new Message("(inv) to use inventory", ConsoleColor.Blue));
            Messages.Add(new Message("(use) to use item", ConsoleColor.Blue));
            Console.Clear();


        }

        public void Inventory()
        {
            Console.Clear();
            Messages.Clear();
            Messages.Add(new Message("Current Inventory: ", ConsoleColor.Blue));
            foreach (var item in _game.CurrentPlayer.Inventory)
            {
                Messages.Add(new Message($"{item.Name} - {item.Description}", ConsoleColor.Blue));
            }
        }

        public void Look()
        {
            Console.Clear();
            Messages.Clear();
            Messages.Add(new Message(_game.CurrentRoom.Name, ConsoleColor.White));
            Messages.Add(new Message(_game.CurrentRoom.Description, ConsoleColor.Blue));
            if (_game.CurrentRoom.Items.Count > 0)
            {
                Messages.Add(new Message("There Are a few things in this room:"));
                foreach (var item in _game.CurrentRoom.Items)
                {
                    Messages.Add(new Message("     " + item.Name));
                }
            }
            string exits = string.Join(", ", _game.CurrentRoom.Exits.Keys);
            Messages.Add(new Message("There are exits to the " + exits));

            string lockedExits = "";
            foreach (var lockedRoom in _game.CurrentRoom.LockedExits.Values)
            {
                lockedExits += lockedRoom.Key;
            }
            Messages.Add(new Message("There are locked exits to the " + lockedExits, ConsoleColor.Red));

        }

        public void Reset()
        {
            string name = _game.CurrentPlayer.Name;
            _game = new Game();
            _game.CurrentPlayer = new Player(name);
        }

        public void Take(string itemName)
        {
            IItem found = _game.CurrentRoom.Items.Find(i => i.Name.ToLower() == itemName);
            if (found != null)
            {
                _game.CurrentPlayer.Inventory.Add(found);
                _game.CurrentRoom.Items.Remove(found);
                Messages.Add(new Message($"You have taken the {found.Name}"));
                Messages.Add(new Message($"{found.Description}"));

                return;
            }
            Messages.Add(new Message("Cannot find item by that name", ConsoleColor.Red));
        }

        public void Use(string itemName)
        {
            var found = _game.CurrentPlayer.Inventory.Find(i => i.Name.ToLower() == itemName);
            if (found != null)
            {
                Messages.Add(new Message(_game.CurrentRoom.Use(found)));
                return;
            }
            // check if item is in room
            Messages.Add(new Message("You don't have that Item", ConsoleColor.Red));
        }



    }
}