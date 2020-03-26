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
           
            // NOTE Create all Items

            // NOTE Make Room Relationships
           


            // NOTE put Items in Rooms


            // CurrentRoom = produce;
        }
    }
}