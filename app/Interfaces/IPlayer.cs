using System.Collections.Generic;

namespace EscapeFromCorona.Interfaces
{
        interface IPlayer
    {
        string Name { get; set; }
        List<IItem> Inventory { get; set; }
    }
}