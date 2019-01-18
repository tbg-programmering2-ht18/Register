using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register
{
    class Program
    {
        static Dictionary<String, String> userPasswDict = new Dictionary<string, string>();
        static Dictionary<String, Animal> userAnimalDict = new Dictionary<string, Animal>();

        static void Main(string[] args)
        {
            userPasswDict.Add("Alp", "420");
            userPasswDict.Add("Thot", "112");
            userPasswDict.Add("Satan", "666");

            userPasswDict.Add("Satan", new Animal("Dragon", "Lizzard", "Rawr"));
            

            bool userloggedIn = false;
            bool done = false;

            while (!done)
            {
                Console.WriteLine("Insert your Dominance here");
                string user = Console.ReadLine();

                bool userExist = userPasswDict.TryGetValue(user, out RegisteredPasswd);
                if (userExist)
                {
                    Console.Write("Insert your password");
                    string passwd = ReadPassword();
                    Console.WriteLine("Sorry me bad at keeping password");
                }
            }
        }
    }
    private static string ReadPassword()
    {
        string pass = "";

        ConsoleKeyInfo key = Console.ReadKey(true);
        while (key ==null || key.Key != ConsoleKey.Enter)
        {
            pass += key.KeyChar; //pass = pass + key.char
            Console.Write("*");
            key.Console.Readkey
        }
    }
}
