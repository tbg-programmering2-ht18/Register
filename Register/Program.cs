using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Register
{
    class Program
    {
        static Dictionary<String, String> userPasswDict = new Dictionary<string, string>();
        static Dictionary<String, Animal> userAnimalDict = new Dictionary<string, Animal>();

        static void Main(string[] args)
        {
            string path = @"c:\Temp\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string urFilename = path + "user_register.txt";
            if (!File.Exists(urFilename))
            {
                FileStream f = File.Create(urFilename);
                f.Close();
                userPasswDict.Add("Viktor", "420");
                userPasswDict.Add("Billy", "112");
                userPasswDict.Add("Satan", "666");

                

                string jsonUserpasswd = JsonConvert.SerializeObject(userPasswDict, Formatting.Indented);
                File.WriteAllText(urFilename, jsonUserpasswd);
            }
            else
            {
                string json = File.ReadAllText(urFilename);
                userPasswDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            string arFilename = path + "animal_register.txt";
            if (!File.Exists(arFilename))
            {
                FileStream f = File.Create(arFilename);
                f.Close();
                userAnimalDict.Add("Viktor", new Animal("Cat", "Brownie", "Mjaow", false));
                userAnimalDict.Add("Satan", new Animal("Devil", "Göran", "Omae wa mo Shindeiru", true));

                string jsonuserAnimal = JsonConvert.SerializeObject(userAnimalDict, Formatting.Indented);
                File.WriteAllText(arFilename, jsonuserAnimal);
            }
            else
            {
                string json = File.ReadAllText(arFilename);
                userAnimalDict = JsonConvert.DeserializeObject<Dictionary<string, Animal>>(json);
            }
             
            

            bool userloggedIn = false;
            bool done = false;

            while (!done)
            {
                // Keeps on trying to log the user in until the user is finally done...
                Console.Write("Insert your Dominance here");
                string user = Console.ReadLine();
                string registeredPasswd;
                //Given the (User) gets the value for that users (registeredpasswd)
                //However if the user does not exist in the dictionary so will the false be returned(into variable userexist)
                bool userExist = userPasswDict.TryGetValue(user, out registeredPasswd);
                if (userExist)
                {
                    Console.Write("Insert your password");
                    string passwd = ReadPassword();
                    //Console.WriteLine("Sorry me bad at keeping track of password");
                    if (passwd.CompareTo(registeredPasswd) == 0)
                    {
                        Console.WriteLine("Welcome you´re logged in!", user);

                        Animal registeredAnimal;
                        bool animalexist = userAnimalDict.TryGetValue(user, out registeredAnimal);
                        if (animalexist)
                        {
                            Console.WriteLine("This is your chosen Animal:{0}", registeredAnimal.show());
                        }
                        else
                        {
                            Console.WriteLine("Sorry there´s no Animals for you!");
                        }
                        Console.WriteLine("Enter any possible keys to get logged out and exit the light realm...");
                        done = true;
                        userloggedIn = false;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You entered the wrong password.");
                    }
                }
                else
                {
                    Console.WriteLine("The user {0} is lost in the darkness",user);
                    Console.Write("Retry? (Enter Yes or No): ");
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