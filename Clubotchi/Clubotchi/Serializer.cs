using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Clubotchi
{
    class Serializer
    {
        public void saveGame(Character character)
        {
            //read the saved games
            var path = Directory.GetCurrentDirectory() + "//SavedCharacter.json";
            StreamReader reader = new StreamReader(path);
            List<Character> characters = JsonSerializer.Deserialize<List<Character>>(reader.ReadToEnd());
            reader.Close();

            //update or add the saved game
            bool findOne = false;
            foreach(Character search in characters)
            {
                if (character.name == search.name) 
                {
                    search.copy(character);
                    findOne = true;
                }
            }
            if (!findOne) characters.Add(character);
            
            //write back to the file
            string saveJson = JsonSerializer.Serialize<List<Character>>(characters);
            StreamWriter writer = new StreamWriter(path);
            writer.Write(saveJson);
            writer.Close();
        }

        public Character loadGame(string name)
        {
            //read the file
            var path = Directory.GetCurrentDirectory() + "//SavedCharacter.json";
            StreamReader file = new StreamReader(path);
            List<Character> characters = JsonSerializer.Deserialize<List<Character>>(file.ReadToEnd());
            file.Close();
            
            //search for the character with the given name
            foreach(Character character in characters)
            {
                if (character.name == name) return character;
            }
            return null;
        }

        public List<Action> actions(RacesEnum race) 
        {
            //read the file
            var path = Directory.GetCurrentDirectory() + "//SavedCharacter.xml";
            StreamReader reader = new StreamReader(path);
            List<Action> tmp = JsonSerializer.Deserialize<List<Action>>(reader.ReadToEnd());
            reader.Close();

            //choose for the given class
            List<Action> actions = new List<Action>();
            foreach(Action action in tmp)
            {
                if (action.race.Contains(race)) actions.Add(action);
            }
            return actions;
        }
    }
}
