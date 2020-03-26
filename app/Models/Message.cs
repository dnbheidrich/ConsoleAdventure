using System;

namespace EscapeFromCorona.Models
{
    class Message
    {
        public Message(string body, ConsoleColor color = ConsoleColor.Green)
        {
            Body = body;
            Color = color;
        }

        public string Body { get; set; }
        public ConsoleColor Color { get; set; }
    }
}