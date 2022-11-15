﻿
Console.WriteLine("VÍTEJ VE HŘE HANGMAN\n\nstiskni enter");
Console.ReadLine();
/*
file.readalltext
*/

void hangman(int wrong)
{
    if (wrong == 5)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine("    |");
        Console.WriteLine("    |");
        Console.WriteLine("    |");
        Console.WriteLine("   ===");
    }
    
    else if (wrong == 4)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine("O   |");
        Console.WriteLine("|   |");
        Console.WriteLine("    |");
        Console.WriteLine("   ===");
    }
    else if (wrong == 3)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine(" O  |");
        Console.WriteLine("/|  |");
        Console.WriteLine("    |");
        Console.WriteLine("   ===");
    }
    else if (wrong == 2)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine(" O  |");
        Console.WriteLine("/|\\ |");
        Console.WriteLine("    |");
        Console.WriteLine("   ===");
    }
    else if (wrong == 1)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine(" O  |");
        Console.WriteLine("/|\\ |");
        Console.WriteLine("/   |");
        Console.WriteLine("   ===");
    }
    else if (wrong == 0)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine(" O   |");
        Console.WriteLine("/|\\  |");
        Console.WriteLine("/ \\  |");
        Console.WriteLine("    ===");
    }
}

void menu()
{
    Console.WriteLine("(H)Hrát\n(Z)ebricek\n(S)tatistika\n(N)Nápověda\n(E)Exit");
    Console.Write("->");
}

void wrongGuess()
{
    
}

int printWord(List<char> guessedLetters, String randomWord)
{
    int counter = 0;
    int rightLetters = 0;
    Console.Write("\r\n");
    foreach (char c in randomWord)
    {
        if (guessedLetters.Contains(c))
        {
            Console.Write(c + " ");
            rightLetters += 1;
        }
        else
        {
            Console.Write("  ");
        }
        counter += 1;
    }
    //Console.Write("\r\n");
    return rightLetters;
}

void printLines(String randomWord)
{
    Console.Write("\r");
    foreach (char c in randomWord)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.Write("\u0305 ");
    }
}

Random rnd = new Random();

bool gg = true;
int pokusy = 6;

/*
string path = "C:\\Users\\zizkade20\\source\\repos\\hangman\\hangman\\TextFile1.txt";
string readText = File.ReadAllText(path);
int index = rnd.Next(readText.Length);
string randomWord = readText[index];
*/


string[] words = System.IO.File.ReadAllLines()

List<string> slovnik = new List<string> { "abc", "abcd", "abcde", "abcdef" };
int index = rnd.Next(slovnik.Count);
string randomWord = slovnik[index];


List<char> pouzitaPismena = new List<char>();

string abdceda = "abcdefghijklmnopqrstuvwxyz";

List<char> abc = new List<char>();

abc.AddRange(abdceda);

int CharsRight = 0;

int lengthOfWordToGuess = randomWord.Length;


do
{
    menu();
    string input = Console.ReadLine().ToLower();

    switch (input)
    {
        case "h":

            foreach (char x in randomWord)
            {
                Console.Write("_ ");
            }

            while (pokusy > 0 && CharsRight != lengthOfWordToGuess)
            {
                Console.WriteLine("\nPočet životů: " + pokusy);
                Console.WriteLine();
                Console.Write("pouzita pismena: ");
                
                foreach (char p in pouzitaPismena)
                {
                    Console.Write(p + " ");
                }
                

                Console.WriteLine();
                Console.WriteLine("\nHadej pismenko");
                Console.Write("->");
                char guess = Console.ReadLine()[0];
                
                if (abc.Contains(guess))
                {
                    
                    if (pouzitaPismena.Contains(guess))
                    {
                        Console.WriteLine("toto pismeno jste jiz pouzil");
                        
                        hangman(pokusy);
                        CharsRight = printWord(pouzitaPismena, randomWord);
                        printLines(randomWord);
                    } 
                    else 
                    {
                        bool right = false;

                        for (int i = 0; i < randomWord.Length; i++) 
                        { 
                            if (guess == randomWord[i]) 
                            { 
                                right = true; 
                            } 
                        }

                        if (right)
                        {
                            hangman(pokusy);
                            pouzitaPismena.Add(guess);
                            CharsRight = printWord(pouzitaPismena, randomWord);
                            Console.Write("\r\n");
                            printLines(randomWord);
                            
                        }
                        else
                        {
                            pokusy--;
                            pouzitaPismena.Add(guess);
                            hangman(pokusy);
                            CharsRight = printWord(pouzitaPismena, randomWord);
                            Console.Write("\r\n");
                            printLines(randomWord);
                            /*
                            pokusy--;
                            pouzitaPismena.Add(guess);
                            Console.Write("pouzita pismena: ");

                            foreach (char p in pouzitaPismena)
                            {
                                Console.Write(p + " ");
                            }
                            hangman(pokusy);
                            
                            Console.WriteLine();
                            */
                        }
                    }
                }
            }
            Console.WriteLine("\nKONEC HRY\n");
            CharsRight = 0;
            pouzitaPismena.Clear();
            break;


        case "z":
            break;
        case "s":
            break;
        case "n":
            Console.WriteLine("Toto je nápověda");
            Console.ReadLine();
            break;
        case "e":
            Console.WriteLine("EXITING NOW...");
            gg = false;
            break;
        default:
            Console.WriteLine("vyber z nabídky\n");
            break;
    }

} while (gg);