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
             Room safeRoom = new Room("Safe Room", Utils.SafeRoomLogo + "Welcome survivor I thought you had turned into a Rona good to see you safe heres a key here to unlock the way out in the office, but do you by chance have any toilet paper? You will be rewarded");
            Room officeRoom = new Room("Office",Utils.OfficeRoomLogo +"Office");
            Room supplyRoom = new Room("Supply Room",Utils.OfficeRoomLogo +"Office");
            Room bathRoom = new Room("Bathroom",Utils.BathRoomLogo +"Seems like the tp has been looted");
            EndRoom escapeRoom = new EndRoom("Tunnel", Utils.EscapeRoomLogo + "A stressed minimum wage employee stares out you with a thousand yard stare, he has seen too much these last few weeks", true,"You breeze through the checkout with your new found wealth!" +  Utils.WinLogo);
            EndRoom deathRoom = new EndRoom("Trap!", "A hoarde of people are racing through this aisle with their weapons out", false, "You are surrounded by a bunch of Ronas, they charge" + Utils.DeathLogo);

            // NOTE Create all Items
            Item key = new Item("Key", "A Key!");
            Item journal = new Item("Journal", "A Book of words!! it has some sort of morse code?");
            Item note = new Item("Note", "Its me Dr. Jro,  I have taken refuge in the E.R. knock in the code we always did to gain entry");
            Item tp = new Item("Toilet Paper", "One single roll of precious toilet paper stashed behind the toilet, it must be hidden away");
            Item rations = new Item("Rations", "Plenty of food for a couple days at least");
            Item mask = new Item("Mask", "A high-qiality face-mask to protect from infection");




            // NOTE Make Room Relationships
            // NOTE startRoom exits
            startRoom.Exits.Add("north", hallwayRoom);
            startRoom.Items.Add(note);

            // end

            // NOTE bathRoom exits/items

            bathRoom.Exits.Add("south", officeRoom);
            bathRoom.Items.Add(tp);


            // hallwayRoom exits/items
            hallwayRoom.Exits.Add("north", deadEndRoom);
            hallwayRoom.Exits.Add("south", startRoom);
            hallwayRoom.Exits.Add("east", deathRoom);
            hallwayRoom.Exits.Add("west", officeRoom);
            // end

            // NOTE officeRoom exits
            officeRoom.Exits.Add("north", bathRoom);
            officeRoom.Exits.Add("east", hallwayRoom);
            officeRoom.Exits.Add("south", deathRoom);
            officeRoom.AddLockedRoom(key, "west", escapeRoom);
            officeRoom.Items.Add(journal);
            // end

            // NOTE deadEndRoom exits/items
            deadEndRoom.AddLockedRoom(journal, "east", safeRoom);
            deadEndRoom.Exits.Add("south", hallwayRoom);
            // end
           
            // NOTE safeRoom exits
            safeRoom.Exits.Add("west", deadEndRoom);
            safeRoom.Items.Add(key);
            safeRoom.AddLockedRoom(tp, "north", supplyRoom);

        // NOTE supplyRoom exits
        supplyRoom.Exits.Add("south", safeRoom );
        supplyRoom.Items.Add(mask);
        supplyRoom.Items.Add(rations);




            // NOTE winRoom exits
            escapeRoom.Exits.Add("east", officeRoom);
            // end




            CurrentRoom = startRoom;
        }
    }
}