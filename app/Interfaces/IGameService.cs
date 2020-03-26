using System.Collections.Generic;

namespace EscapeFromCorona.Interfaces
{
     interface IGameService
    {
        List<string> Messages { get; set; }
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