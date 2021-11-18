using System.Collections.Generic;
using KinopoiskAPI.Hubs.Model;

namespace KinopoiskAPI.Hubs.Messages
{
    public class AdminInformationMessage
    {
        public List<Connection> Connections { get; set; }
    }
}