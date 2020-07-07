using System;
using System.Collections.Generic;

namespace Clubotchi
{
    internal class GameController
    {
        private Character character;
        private Serializer serializer = new Serializer();

        public GameController(Character character)
        {
            this.character = character;
        }

        internal void start()
        {
            setUpActions();
            while (true)    //The game loop
            {
                character.showAction();
                var tmp = Console.ReadLine();
                var tmplist = tmp.Split(" ");
                List<int> actions = new List<int>();
                foreach (string s in tmplist)
                {
                    try
                    {
                        actions.Add(Int32.Parse(s));
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Unable to parse '{0}'", s);
                    }
                }
                var returnValue = character.doAction(actions);
                if (returnValue == 1) return;
                if (returnValue == 2) saveGame(); 
            }
        }

        public void saveGame()
        {
            serializer.saveGame(character);            
        }

        public Character loadGame(string name)
        {
            return serializer.loadGame(name);
        }

        public void setUpActions()
        {
            character.actions = serializer.actions(character.race);
        }
    }
}
