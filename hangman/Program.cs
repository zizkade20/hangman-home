
using System.Runtime.InteropServices;

Console.WriteLine("VÍTEJ VE HŘE HANGMAN\n\nstiskni enter");
Console.ReadLine();
/*
file.readalltext
*/

void hangman(int wrong)
{
    if (wrong == 7)
    {
        Console.WriteLine("\n");
        Console.WriteLine("    ");
        Console.WriteLine("    ");
        Console.WriteLine("    ");
        Console.WriteLine("   ===");
    }
    else if (wrong == 6)
    {
        Console.WriteLine("\n");
        Console.WriteLine("    |");
        Console.WriteLine("    |");
        Console.WriteLine("    |");
        Console.WriteLine("   ===");
    }
    else if (wrong == 5)
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
    Console.WriteLine("(H)Hrát\n(Z)ebricek\n(S)tatistika\n(P)ravidla\n(E)xit");
    Console.Write("->");
}


void hra(string randomWord, int pokusy)
{
    Random rnd = new Random();

    bool gg = true;



    List<string> slovnik = new List<string> { "abc", "abcd", "abcde", "abcdef" };
    int index = rnd.Next(slovnik.Count);
    //string randomWord = slovnik[index];


    List<char> pouzitaPismena = new List<char>();

    string abdceda = "abcdefghijklmnopqrstuvwxyz";

    List<char> abc = new List<char>();

    abc.AddRange(abdceda);

    int CharsRight = 0;

    int charSum = randomWord.Length;

    int vyhraneHry = 0;



    while (pokusy > 0)
    {
        while (CharsRight != charSum)
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

                    }
                }
            } else
            {
                Console.WriteLine("Invalid input");
                printLines(randomWord);
            }
            /*
            if (CharsRight == randomWord.Length)
            {
                vyhraneHry++;
                Console.WriteLine("\nMáš " + vyhraneHry + " bod/ů");
                gg = true;

            }
            */
        }

    }
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


string[] wordsE = System.IO.File.ReadAllLines("C:\\Users\\Dendos\\source\\repos\\hangman\\hangman\\TextFile1.txt");
int startS = rnd.Next(0, wordsE.Length);
string randomWordE = wordsE[startS];

string[] wordsH = System.IO.File.ReadAllLines("C:\\Users\\Dendos\\source\\repos\\hangman\\hangman\\TextFile2.txt");
int startH = rnd.Next(0, wordsH.Length);
string randomWordH = wordsH[startS];


bool gg = true;
int pokusy = 6;


List<char> pouzitaPismena = new List<char>();

string abdceda = "abcdefghijklmnopqrstuvwxyz";

List<char> abc = new List<char>();

abc.AddRange(abdceda);

int CharsRight = 0;



//StreamWriter statistic = new StreamWriter("statistika.txt");
do
{
    menu();
    string input = Console.ReadLine().ToLower();

    switch (input)
    {
        case "h":
            Console.WriteLine("Vyber is obtížnost:\n(L)ehka\n(T)ezka");
            Console.Write("->");

            string diff = Console.ReadLine().ToLower();

            switch (diff)
            {
                case "l":
                    if (randomWordE.Length == 0)
                    {
                        Console.WriteLine("problém se slovníkem!");
                    }
                    else
                    {
                        foreach (char x in randomWordE)
                        {
                            Console.Write("_ ");
                        }
                        hra(randomWordH, 6);
                    }
                    break;
                case "t":
                    
                    if (randomWordH.Length == 0)
                    {
                        Console.WriteLine("problém se slovníkem!");
                    }
                    else
                    { 
                        foreach (char x in randomWordH)
                        {
                            Console.Write("_ ");
                        }
                        hra(randomWordH, 8); 
                    }
                   

                    
                  
                    break;
                default:
                    Console.WriteLine("Vyber z nabídky!");
                    break;
            }
            
            
            
            Console.WriteLine("\nKONEC HRY\n");
            CharsRight = 0;
            pouzitaPismena.Clear();
            break;


        case "z":
            Console.WriteLine("\nBorci s nejvyšším skóre:\n\n\n");
            break;
        case "s":
            Console.WriteLine("\nTvá statistika:\n\n\n");
            break;
        case "p":
            Console.WriteLine("" +
                "\n1) Nepoužívej číslice a charaktery s háčky a čárkami, jinak se nebudou počítat" +
                "\n2) Nezadávej více než jeden charakter, je to k ničemu" +
                "\n3) I když budete vědět slovo, doplňte charaktery po jednom" +
                "");
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
