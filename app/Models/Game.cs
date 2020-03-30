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
             Room deadEndRoom = new Room("Dead-End or so it seems",Utils.DeadEndRoomLogo + "You come upon a barred doors with big red letters WARNING.");
             Room safeRoom = new Room("Safe Room", Utils.SafeRoomLogo + "Welcome survivor I thought you had turned into a Rona good to see you safe, heres a key here to unlock a secret tunnel in the bathroom to escape safely the front door is much too dangerous, but do you by chance have any toilet paper? You will be rewarded");
            Room lockedHallwayRoom = new Room("Hallway",Utils.HallwayLogo +"You press forward the smell of conorona in the air, travel with caution");
            Room officeRoom = new Room("Office",Utils.OfficeRoomLogo +"Office");
            Room supplyRoom = new Room("Supply Room",Utils.OfficeRoomLogo +"Office");
            Room bathRoom = new Room("Bathroom",Utils.BathRoomLogo +"Seems like the tp has been looted");
            EndRoom tunnelRoom = new EndRoom("Tunnel", Utils.TunnelRoomLogo + "A stressed minimum wage employee stares out you with a thousand yard stare, he has seen too much these last few weeks", true,"You breeze through the checkout with your new found wealth!" +  Utils.WinLogo);
             EndRoom escapeRoom = new EndRoom("Tunnel", "A stressed minimum wage employee stares out you with a thousand yard stare, he has seen too much these last few weeks", true,"You breeze through the checkout with your new found wealth!" +  Utils.WinLogo);
            EndRoom deathRoom = new EndRoom("!!!!!!!!!!", "You are surrounded by a hoarde of Ronas", false, "They charge" + Utils.DeathLogo);

            // NOTE Create all Items
            Item key = new Item("Key", "A Key!");
            Item journal = new Item("Journal", "A Book of words!! it has some sort of morse code?");
            Item note = new Item("Note", "Its me Dr. Jro,  I have taken refuge in the E.R. knock in the code we always did to gain entry");
            Item tp = new Item("Toilet Paper", "One single roll of precious toilet paper stashed behind the toilet, it must be hidden away");
            Item rations = new Item("Rations", "Plenty of food for a couple days at least");
            Item mask = new Item("Mask", "A high-qiality face-mask to protect from infection, maybe I could use this to escape through the frontdoor?");




            // NOTE Make Room Relationships

            // startRoom exits/items
            startRoom.Exits.Add("north", hallwayRoom);
            startRoom.Items.Add(note);
            // end

            // bathRoom exits/items
            bathRoom.Exits.Add("north", deathRoom);
            bathRoom.Exits.Add("south", officeRoom);
            bathRoom.AddLockedRoom(key, "west", tunnelRoom);
            bathRoom.Items.Add(tp);
            // end

            // hallwayRoom exits/items
            hallwayRoom.Exits.Add("north", deadEndRoom);
            hallwayRoom.Exits.Add("south", startRoom);
            hallwayRoom.AddLockedRoom(mask, "east", lockedHallwayRoom);
            hallwayRoom.Exits.Add("west", officeRoom);
            // end

             // lockedHallwayRoom exits/items
            lockedHallwayRoom.Exits.Add("north", deathRoom);
            lockedHallwayRoom.Exits.Add("south", escapeRoom);
            lockedHallwayRoom.Exits.Add("east", deathRoom);
            lockedHallwayRoom.Exits.Add("west", hallwayRoom);
            // end

            // officeRoom exits/items
            officeRoom.Exits.Add("north", bathRoom);
            officeRoom.Exits.Add("south", deathRoom);
            officeRoom.Exits.Add("east", hallwayRoom);
            officeRoom.Items.Add(journal);
            // end

            // deadEndRoom exits/items
            deadEndRoom.AddLockedRoom(journal, "east", safeRoom);
            deadEndRoom.Exits.Add("south", hallwayRoom);
            // end
           
            // safeRoom exits
            safeRoom.AddLockedRoom(tp, "north", supplyRoom);
            safeRoom.Exits.Add("west", deadEndRoom);
            safeRoom.Items.Add(key);
            // end

            // supplyRoom exits/items
            supplyRoom.Exits.Add("south", safeRoom );
            supplyRoom.Items.Add(mask);
            supplyRoom.Items.Add(rations);
            // end 



           




            CurrentRoom = startRoom;
        }
    }
}