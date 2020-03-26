using EscapeFromCorona.Interfaces;

namespace EscapeFromCorona.Models

{
    class Game : IGame
    {
        public IPlayer CurrentPlayer { get; set; }
        public IRoom CurrentRoom { get; set; }

        ///<summary>Initalizes data and establishes relationships</summary>
        public Game()
        {
            // NOTE ALL THESE VARIABLES ARE REMOVED AT THE END OF THIS METHOD
            // We retain access to the objects due to the linked list


            // NOTE Create all rooms
            Room startRoom = new Room("Hospital Room",Utils.StartRoomLogo + "You wake up with no recollection of your past, You seem to be hooked up to a ventilator in a bed with a flickering light above you");
            Room hallwayRoom = new Room("Hallway",Utils.HallwayLogo +"You stumble into the long hallway it seems like noones been around for days, The calender on the wall says the date is April of 2020");
             Room deadEnd = new Room("Dead-End or so it seems","You come upon a barred doors with big red letters WARNING.");
             Room safeRoom = new Room("Safe Room", "Welcome survivor I thought you had turned into a Rona good to see you safe theres a key here to unlock the way out");
            Room officeRoom = new Room("Frozen Foods",Utils.OfficeRoomLogo +"Office Room");
            EndRoom escapeRoom = new EndRoom("Checkout", "A stressed minimum wage employee stares out you with a thousand yard stare, he has seen too much these last few weeks", true,"You breeze through the checkout with your new found wealth!" +  Utils.WinLogo);
            EndRoom deathRoom = new EndRoom("Toiletries", "A hoarde of people are racing through this aisle with their weapons out", false, "You are trampled under foot and your name is lost to history" + Utils.DeathLogo);

            // NOTE Create all Items
            Item key = new Item("Key", "A Key!");
            Item journal = new Item("Journal", "A Book of words!!");


            // NOTE Make Room Relationships
            // NOTE startRoom exits
            startRoom.Exits.Add("north", hallwayRoom);
            // end

            // NOTE hallwayRoom exits
            hallwayRoom.Exits.Add("north", deadEnd);
            hallwayRoom.Exits.Add("south", startRoom);
            hallwayRoom.Exits.Add("east", deathRoom);
            hallwayRoom.Exits.Add("west", officeRoom);
            // end

            // NOTE officeRoom exits
            officeRoom.Exits.Add("east", hallwayRoom);
            officeRoom.AddLockedRoom(key, "west", escapeRoom);
            // end

            // NOTE deadEnd exits
            deadEnd.AddLockedRoom(journal, "east", safeRoom);
            deadEnd.Exits.Add("south", hallwayRoom);
            // end
           
            // NOTE safeRoom exits
            safeRoom.Exits.Add("west", deadEnd);
        


            // NOTE winRoom exits
            escapeRoom.Exits.Add("east", officeRoom);
            // end


            // NOTE put Items in Rooms
            safeRoom.Items.Add(key);
            officeRoom.Items.Add(journal);




            CurrentRoom = startRoom;
        }
    }
}