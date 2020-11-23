using System;
using System.Collections.Generic;

namespace HelenasSpelcenter.HangManGame
{
    class HangMan
    {
        //göra välkommen text till hänga gubbe, och snygga till det lite visuellt!
        public static void PlayHangMan()
        {
            Intro();
            System.Threading.Thread.Sleep(2000);
            bool playAgain = true;
            while (playAgain)
            {
                int guessesLeft = 10;
                //MenuWordChoice();
                //int wordChoice = Input(5);
                bool isWordOK = false;
                string secretWord = "";
                //if (wordChoice == 5)
                //{
                //    secretWord = GetWordFromFile("hangmanscarywords.txt");
                //}
                //if (wordChoice == 4)
                //{
                //    secretWord = GetWordFromFile("hangmanstupidwords.txt");
                //}
                //if (wordChoice == 3)
                //{
                //    secretWord = GetSentenceFromFile();
                //}
                //else if (wordChoice == 2)
                //{
                //    secretWord = GetWordFromFile("hangmanwords.txt");
                //}
                //else if (wordChoice == 1)

                while (!isWordOK)
                {
                    secretWord = InputWord();
                    isWordOK = CheckIfINputIsOK(secretWord);
                }

                int lenghtOfWord = secretWord.Length;
                char[] lettersInArray = PutWordInLetterArray(lenghtOfWord, secretWord);
                List<char> alreadyGuessedLetters = new List<char>();
                Console.Clear();
                Intro();
                Console.WriteLine("\n\n");

                PrintOutHangMan(guessesLeft);

                string[] gameFloor = new string[lettersInArray.Length];
                gameFloor = StringWithRightNumberOfEmptyPlaces(lettersInArray, gameFloor);
                Console.WriteLine();


                PrintOutString(gameFloor);
                Console.WriteLine();
                Console.WriteLine("\t\tTack, ditt ord/mening är sparat.");
                Console.WriteLine("\t\tNu är det dags för en annan person att gissa på en bokstav.");
                Console.WriteLine();
                bool manageToGuessTheWord = false;


                int howManyLettersInWord = 0;
                char guessedLetter = ' ';
                while (!manageToGuessTheWord)
                {
                    guessedLetter = GuessLetter(alreadyGuessedLetters);
                    alreadyGuessedLetters.Add(guessedLetter);
                    Console.Clear();
                    Intro();
                    howManyLettersInWord = CheckHowManyCharInSercretWord(guessedLetter, lettersInArray);
                    if (howManyLettersInWord == 0)
                    {
                        guessesLeft--;
                        Console.WriteLine("\t\tBokstaven fanns inte med!");
                        Console.WriteLine("\n");
                        PrintOutHangMan(guessesLeft);
                        Console.WriteLine();




                        PrintOutString(gameFloor);
                        Console.WriteLine();
                        LettersGuessedAlready(alreadyGuessedLetters);
                        Console.WriteLine();

                        if (guessesLeft == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("\t\tGubben är hängd! Du förlorade. :(");
                            Console.WriteLine();
                            RightAnswer(secretWord);
                            Console.WriteLine();
                            break;
                        }
                        Console.WriteLine();


                    }
                    else
                    {
                        Console.WriteLine("\t\tBokstaven fanns med, grattis.");
                        Console.WriteLine("\n");
                        PrintOutHangMan(guessesLeft);

                        Console.WriteLine();
                        gameFloor = StringWithLetters(lettersInArray, guessedLetter, gameFloor);



                        PrintOutString(gameFloor);
                        manageToGuessTheWord = CheckIfFinnish(gameFloor);
                        Console.WriteLine();
                        LettersGuessedAlready(alreadyGuessedLetters);
                        Console.WriteLine();

                        Console.WriteLine();
                        if (manageToGuessTheWord)
                        {
                            Console.WriteLine();
                            Console.WriteLine("\t\tGRATTIS GRATTIS GRATTIS du klarade ordet!");
                            Console.WriteLine("\t\tGubben klarade sig!!");
                        }

                    }
                }
                Console.WriteLine();
                playAgain = PlayAgain();
            }
        }

        //public static string GetWordFromFile(string path)
        //{
        //    Random random = new Random();
        //    string word = File.ReadAllText(path);
        //    string[] words = word.Split(' ');
        //    int randomNumber = random.Next(0, words.Length);
        //    string secretWord = words[randomNumber];
        //    return secretWord;
        //}
        //public static string GetSentenceFromFile()
        //{
        //    Random random = new Random();
        //    string[] sentences = File.ReadAllLines("hangmansentences.txt");
        //    int randomNumber = random.Next(0, sentences.Length);
        //    string secretWord = sentences[randomNumber];
        //    return secretWord;
        //}
        //public static void MenuWordChoice()
        //{
        //    Console.WriteLine("\t\tTryck på önskat val:");
        //    Console.WriteLine("\t\t[1] Mata in ett eget ord/mening.");
        //    Console.WriteLine("\t\t[2] Be datorn ta fram ett ord.");
        //    Console.WriteLine("\t\t[3] Be datorn ta fram en mening");
        //    Console.WriteLine("\t\t[4] Be datorn ta fram ett ord på temat \"trams\"");
        //    Console.WriteLine("\t\t[5] Be datorn ta fram ett ord på temat \"läskigt\"");
        //}
        public static int Input(int numberOfChoices)
        {
            int number = 0;
            bool ok = false;
            while (!ok)
            {
                ok = int.TryParse(Console.ReadLine(), out number);
                if (!ok || number > numberOfChoices || number < 0)
                { Console.WriteLine("\t\tFörsök igen."); }
            }

            return number;
        }

        static void Intro()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t ██░ ██ █ ▄▄▄ █     ███▄    █   ▄████  ▄▄▄           ▄████  █    ██  ▄▄▄▄    ▄▄▄▄   ▓█████ ");
            Console.WriteLine("\t▓██░ ██▒▒████▄     ██ ▀█   █  ██▒ ▀█▒▒████▄        ██▒ ▀█▒ ██  ▓██▒▓█████▄ ▓█████▄ ▓█   ▀ ");
            Console.WriteLine("\t▒██▀▀██░▒██  ▀█▄  ▓██  ▀█ ██▒▒██░▄▄▄░▒██  ▀█▄     ▒██░▄▄▄░▓██  ▒██░▒██▒ ▄██▒██▒ ▄██▒███   ");
            Console.WriteLine("\t░▓█ ░██ ░██▄▄▄▄██ ▓██▒  ▐▌██▒░▓█  ██▓░██▄▄▄▄██    ░▓█  ██▓▓▓█  ░██░▒██░█▀  ▒██░█▀  ▒▓█  ▄ ");
            Console.WriteLine("\t░▓█▒░██  ▓█   ▓██▒▒██░   ▓██░░▒▓███▀▒ ▓█   ▓██▒   ░▒▓███▀▒▒▒█████▓ ░▓█  ▀█▓░▓█  ▀█▓░▒████▒");
            Console.WriteLine("\t ▒ ░░▒   ░▒   ▓▒█░░▒░ ▒░   ▒ ▒  ░▒  ▒ ▒▒   ▓▒█░    ░▒   ▒ ░▒▓▒ ▒ ▒ ░▒▓███▀▒░▒▓███▀▒░░ ▒░ ░");
            Console.WriteLine("\t▒ ░▒░ ░░  ▒   ▒▒ ░  ░░   ░ ▒░  ░   ░   ▒   ▒▒ ░     ░   ░ ░░▒░ ░ ░ ▒░▒   ░ ▒░▒   ░  ░ ░  ░");
            Console.WriteLine("\t░  ░░ ░   ░   ▒         ░   ░ ░ ░ ░   ░   ░   ▒      ░ ░   ░  ░░░ ░ ░  ░    ░  ░    ░    ░   ");
            Console.WriteLine("\t░  ░  ░      ░  ░          ░       ░       ░  ░         ░    ░      ░       ░         ░  ░");
            Console.WriteLine("\t                           ░       ░        ");
            Console.ForegroundColor = ConsoleColor.White;


        }
        static void RightAnswer(string secretWord)
        {
            Console.Write("\t\tRÄTT SVAR SKULLE VARA: " + secretWord.ToUpper());

        }
        static void LettersGuessedAlready(List<char> alreadyGuessed)
        {


            Console.WriteLine();
            Console.Write("\t\tDu har redan gissat på: ");
            for (int i = 0; i < alreadyGuessed.Count; i++)
            {
                if (i == alreadyGuessed.Count - 1)
                { Console.Write(alreadyGuessed[i].ToString().ToUpper()); }
                else { Console.Write(alreadyGuessed[i].ToString().ToUpper() + ", "); }
            }
        }
        static bool PlayAgain()
        {

            Console.WriteLine("\t\tVill du spela igen?");
            Console.WriteLine("\t\tTryck J för JA och N för nej");
            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.J)
            { return true; }
            else { return false; }
        }

        static bool CheckIfFinnish(string[] stringArray)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (stringArray[i] == "___ " || stringArray[i] == " . ")
                { return false; }

            }
            return true;
        }
        static void PrintGameName()
        {
            Console.WriteLine("\t\tHÄNGA GUBBE");
            Console.WriteLine("\t\t------------");
            Console.WriteLine();
        }

        static int CheckHowManyCharInSercretWord(char letter, char[] letterArray)
        {
            int countLetters = 0;

            for (int i = 0; i < letterArray.Length; i++)
            {
                if (letter == letterArray[i])
                {
                    countLetters++;
                }

            }
            return countLetters;
        }



        static string[] StringWithRightNumberOfEmptyPlaces(char[] letters, string[] gameFloor)
        {

            for (int i = 0; i < letters.Length; i++)
            {

                if (char.IsWhiteSpace(letters[i]))
                { gameFloor[i] = "   "; }
                else if (char.IsPunctuation(letters[i]))
                { gameFloor[i] = " . "; }

                else
                { gameFloor[i] = "___ "; }
            }
            return gameFloor;
        }
        static string[] StringWithLetters(char[] letters, char guessedLetter, string[] gameFloor)
        {

            for (int i = 0; i < letters.Length; i++)
            {

                if (letters[i] == guessedLetter)
                    gameFloor[i] = " " + guessedLetter.ToString().ToUpper() + " ";

            }
            return gameFloor;
        }

        static void PrintOutString(string[] stringWithLetters)
        {
            Console.WriteLine("\n");
            Console.Write("\t\t");
            for (int i = 0; i < stringWithLetters.Length; i++)
            {
                Console.Write(stringWithLetters[i]);
            }
            Console.WriteLine("\n\n");
        }

        static char GuessLetter(List<char> alreadyGuessed)
        {
            bool tryAgain = true;
            char guess = ' ';
            while (tryAgain)
            {
                tryAgain = false;
                bool tryAgain2 = true;
                string guessedLetter = "";
                while (tryAgain2)
                {
                    tryAgain2 = false;
                    Console.WriteLine("\t\tGissa en bokstav. Tryck bokstaven och sedan enter.");
                    Console.Write("\t\t"); guessedLetter = Console.ReadLine().ToLower();
                    if (string.IsNullOrEmpty(guessedLetter))
                    { tryAgain2 = true; }
                }
                guess = guessedLetter[0];
                if (!char.IsLetter(guess))
                {
                    Console.WriteLine("\t\tFelaktig inmatning. Försök igen.");
                    Console.WriteLine();
                    tryAgain = true;
                }

                for (int i = 0; i < alreadyGuessed.Count; i++)
                {
                    if (alreadyGuessed[i] == guess)
                    {
                        Console.WriteLine("\t\tDu har redan gissat på den bokstaven, försök igen.");
                        Console.WriteLine();
                        tryAgain = true;

                    }
                }
            }
            return guess;
        }
        static string InputWord()
        {
            Console.WriteLine("\t\tMata in ett ord eller mening som blir det hemliga ordet.");
            Console.WriteLine("\t\tOm du skriver en mening går det bra att använda mellanslag samt punkt.");
            Console.WriteLine("\t\tTryck enter när du är klar.");
            Console.Write("\t\tHemligt ord: ");
            string secretWord = Console.ReadLine().ToLower();
            return secretWord;
        }

        static bool CheckIfINputIsOK(string secretWord)
        {
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (!char.IsLetter(secretWord[i]) && !char.IsWhiteSpace(secretWord[i]) && !char.IsPunctuation(secretWord[i]))
                {
                    Console.WriteLine("\t\tDu matade in ett ogiltigt ord/mening. Vänligen använd bara bokstäver, mellanslag samt punkt.");
                    Console.WriteLine();
                    return false;
                }
            }
            return true;
        }
        static char[] PutWordInLetterArray(int lenghtOfWord, string secretWord)
        {
            char[] letterArray = new char[lenghtOfWord];

            for (int i = 0; i < lenghtOfWord; i++)
            {
                letterArray[i] = secretWord[i];
            }
            return letterArray;
        }
        static void PrintOutHangMan(int guessesLeft)
        {
            switch (guessesLeft)
            {
                case 10:
                    Console.WriteLine("\t\t\t");
                    Console.WriteLine("\t\t\t");
                    Console.WriteLine("\t\t\t");
                    Console.WriteLine("\t\t\t");
                    Console.WriteLine("\t\t\t");
                    Console.WriteLine("\t\t\t");
                    Console.WriteLine("\t\t\t");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\t///////////////////////");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 9:
                    Console.WriteLine("\t\t\t");
                    Console.WriteLine("\t\t\t");
                    Console.WriteLine("\t\t\t");
                    Console.WriteLine("\t\t\t");
                    Console.WriteLine("\t\t\t");
                    Console.WriteLine("\t\t\t");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\t\t\t\t______");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\t\t///////////////////////");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 8:
                    Console.WriteLine("\t\t\t");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\t\t\t\t   |");
                    Console.WriteLine("\t\t\t\t   |");
                    Console.WriteLine("\t\t\t\t   |");
                    Console.WriteLine("\t\t\t\t   |");
                    Console.WriteLine("\t\t\t\t___|___");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\t\t///////////////////////");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\t\t\t\t   _________");
                    Console.WriteLine("\t\t\t\t   |");
                    Console.WriteLine("\t\t\t\t   |");
                    Console.WriteLine("\t\t\t\t   |");
                    Console.WriteLine("\t\t\t\t   |");
                    Console.WriteLine("\t\t\t\t___|___");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\t\t///////////////////////");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\t\t\t\t   _________");
                    Console.WriteLine("\t\t\t\t   |       |");
                    Console.WriteLine("\t\t\t\t   |");
                    Console.WriteLine("\t\t\t\t   |");
                    Console.WriteLine("\t\t\t\t   |");
                    Console.WriteLine("\t\t\t\t___|___");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\t\t///////////////////////");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\t\t\t\t   _________");
                    Console.WriteLine("\t\t\t\t   |       |");
                    Console.Write("\t\t\t\t   |       ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("o");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\t\t\t\t   |");
                    Console.WriteLine("\t\t\t\t   |");
                    Console.WriteLine("\t\t\t\t___|___");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\t\t///////////////////////");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\t\t\t\t   _________");
                    Console.WriteLine("\t\t\t\t   |       |");
                    Console.Write("\t\t\t\t   |       ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("o");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\t\t\t\t   |       ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("| ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\t\t\t\t   |");
                    Console.WriteLine("\t\t\t\t___|___");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\t\t///////////////////////");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\t\t\t\t   _________");
                    Console.WriteLine("\t\t\t\t   |       |");
                    Console.Write("\t\t\t\t   |       ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("o");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\t\t\t\t   |      ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("/| ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\t\t\t\t   |");
                    Console.WriteLine("\t\t\t\t___|___");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\t\t///////////////////////");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\t\t\t\t   _________");
                    Console.WriteLine("\t\t\t\t   |       |");
                    Console.Write("\t\t\t\t   |       ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("o");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\t\t\t\t   |      ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("/|\\");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\t\t\t\t   |");
                    Console.WriteLine("\t\t\t\t___|___");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\t\t///////////////////////");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\t\t\t\t   _________");
                    Console.WriteLine("\t\t\t\t   |       |");
                    Console.Write("\t\t\t\t   |       ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("o");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\t\t\t\t   |      ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("/|\\");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\t\t\t\t   |      ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("/");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\t\t\t\t___|___");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\t\t///////////////////////");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;
                case 0:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\t\t\t\t   _________");
                    Console.WriteLine("\t\t\t\t   |       |");
                    Console.Write("\t\t\t\t   |       ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("o");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\t\t\t\t   |      ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("/|\\");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\t\t\t\t   |      ");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(" /\\");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("\t\t\t\t___|___"); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(" _'__'__");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\t\t///////////////////////");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;

            }
        }

    }
}
