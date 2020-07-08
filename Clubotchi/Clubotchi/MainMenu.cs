﻿using System;
using System.Threading;

namespace Clubotchi
{
    class MainMenu
    {
        static private GameController mainGameController = new GameController();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Clubotchi!");
            var menu = showMenu();
            while(true)
            {
                Character character = null;

                switch (menu)
                {
                    case "1":
                        character = characterCretion();
                        break;
                    case "2":
                        System.Environment.Exit(1);
                        break;
                }

                if (character != null) 
                {
                    mainGameController.character = character;
                    mainGameController.start();
                }
                menu = showMenu();
            }
        }

        private static Character characterCretion()
        {
            //race picker
            string race;
            do
            {
                Console.WriteLine("Choose your character:");
                var values = Enum.GetValues(typeof(RacesEnum));
                Console.WriteLine("1: Camel");
                Console.WriteLine("2: Pinguin");
                race = Console.ReadLine();
            } while (race != "1" && race!= "2");
            Console.WriteLine("Give a name to your pet: ");
            var name = Console.ReadLine();
            if (race == "1") return new Camel(name);
            else return new Pinguin(name);
        }

        private static string showMenu()
        {
            bool valid = true;
            do
            {
                if (valid)
                {
                    Console.WriteLine("Please choose an option:");
                }
                else Console.WriteLine("Choose a valid option:");
                Console.WriteLine("1 - New Game");
                Console.WriteLine("2 - Exit Game");

                string menu = Console.ReadLine();
                if (menu != "1" && menu != "2") valid = false;
                else return menu;
            } while (true);

        }

        
    }
}
