using System.Collections.Generic;

namespace HelenasSpelcenter.YatzyGame
{
    class YatzyResultboard : Yatzyboard
    {
        public YatzyResultboard(string type, List<YatzyPlayer> players)
        {
            Type = type;

            Players = players;
        }

        
    }
}
