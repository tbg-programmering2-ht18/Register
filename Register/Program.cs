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
            userPasswDict.Add("Viktor", "420");
            userPasswDict.Add("Billy", "112");
            userPasswDict.Add("Satan", "666");

            userAnimalDict.Add("Viktor", new Animal("Dragon", "Lizzard", "Rawr", true));


            bool userloggedIn = false; //
            bool done = false;

            while (!done)
            {
                Console.WriteLine("Insert your Dominance here");
                string user = Console.ReadLine();
                string registeredPasswd;
                bool userExist = userPasswDict.TryGetValue(user, out registeredPasswd);
                if (userExist)
                {
                    Console.Write("Insert your password");
                    string passwd = ReadPassword();
                    Console.WriteLine("Sorry me bad at keeping password");
                }
                else
                {
                    Console.WriteLine("The user {0} is lost in the darkness",user);
                    Console.Write("Retry? (Enter Yes or No):");
                    string answer = Console.ReadLine();
                    done = (!answer.ToLower().StartsWith("y"));
                }
            }
        }


        private static string ReadPassword()
        {
            string pass = "";

            ConsoleKeyInfo key = Console.ReadKey(true);
            while (key == null || key.Key != ConsoleKey.Enter)
            {
                pass += key.KeyChar; //pass = pass + key.char
                Console.Write("*");
                key = Console.ReadKey(true);
            }
            return pass;
        }
    }
}