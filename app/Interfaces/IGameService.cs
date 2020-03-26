using System.Collections.Generic;
using EscapeFromCorona.Models;

namespace EscapeFromCorona.Interfaces
{
    interface IGameService
    {
        //go, look, take, use, inventory, Rest, setup, help
         List<Message> Messages { get; set; }
        void Reset();

        #region Console Commands
        bool Go(string direction);
        void Look();
        void Take(string itemName);
        void Use(string itemName);
        void Inventory();
        void Help();
        #endregion
    }
}