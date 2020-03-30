using System.Collections.Generic;
using EscapeFromCorona.Interfaces;

namespace EscapeFromCorona.Models
{
    class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IItem> Items { get; set; }
        public Dictionary<string, IRoom> Exits { get; set; }
        public Dictionary<IItem, KeyValuePair<string, IRoom>> LockedExits { get; set; }

        public void AddLockedRoom(IItem key, string direction, IRoom room)
        {
            var lockedRoom = new KeyValuePair<string, IRoom>(direction, room);
            LockedExits.Add(key, lockedRoom);
        }

// !NOTE Need how items work explained again
        public string Use(IItem item)
        {
            if (LockedExits.ContainsKey(item))
            {
                Exits.Add(LockedExits[item].Key, LockedExits[item].Value);
                LockedExits.Remove(item);

                if (item.Name.ToLower() == "key" )
                {
                    return "You unlock the secret passage exposing a tunnel for escape!";
                } 
                else if(item.Name.ToLower() == "journal")
                {
                    return "You use the morse code in the book to knock on the door, you hear movement behind the door!";
                }
                 else if(item.Name.ToLower() == "toilet paper" || item.Name.ToLower() == "tp" )
                {
                    return "You give the tp to Dr. Jro and he unlocks the room to the north!";
                }
                
                return "You have unlocked a room";
                
            }
            return "No use for that here";
        }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<IItem>();
            Exits = new Dictionary<string, IRoom>();
            LockedExits = new Dictionary<IItem, KeyValuePair<string, IRoom>>();
        }
    }
}