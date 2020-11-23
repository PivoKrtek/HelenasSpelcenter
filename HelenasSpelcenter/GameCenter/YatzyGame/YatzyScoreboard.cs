using System.Collections.Generic;

namespace HelenasSpelcenter.YatzyGame
{
    public class YatzyScoreboard : Yatzyboard
    {

        public int Number { get; set; }

        public YatzyScoreboard(int number, string type, List<YatzyPlayer> players)
        {
            Number = number;
            Type = type;
            Players = players;
        }

        
    }

}
