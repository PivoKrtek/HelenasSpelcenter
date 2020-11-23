using System;
using HelenasSpelcenter.YatzyGame;
using HelenasSpelcenter.HangManGame;


namespace HelenasSpelcenter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(110, 45);
            
            Menu.ShowIntro();
            
            
            bool playAgain = true;

            while (playAgain)
            {
                Console.Clear();
                Menu.ShortIntro();
                
                Menu.ShowMenu();
                int choiceOfGame = Menu.Input(8);
                Console.Clear();
                switch (choiceOfGame)
                {
                    case 0:
                        Console.WriteLine("Tack för den här gången. Välkommen åter!");
                        playAgain = false;
                        break;
                    case 1:
                        BattleShipGame.PlayBattleShip();
                        break;
                    case 2:
                        Yatzy.PlayYatzy();
                        break;
                    case 3:
                        HangMan.PlayHangMan();
                        break;
                    case 4:
                        SecretCodeGame.PlaySecretCode();
                        break;
                    case 5:
                        FlappyBirdGame.PlayFlappyBird();
                        break;
                    case 6:
                        SnakeGame.PlaySnake();
                        break;
                    case 7:
                        Highscore.RunHighscore();
                        break;
                    default:
                        break;
                }
            }
            Console.ReadLine();

           
        }
    }
}
