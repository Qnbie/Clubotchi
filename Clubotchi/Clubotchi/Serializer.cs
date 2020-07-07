using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;

namespace Clubotchi
{
    class Serializer
    {
        public void saveGame(Character character)
        {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Character>));
            var path = Directory.GetCurrentDirectory() + "//SavedCharacter.xml";
            StreamReader reader = new StreamReader(path);
            List<Character> characters = (List<Character>)xmlSerializer.Deserialize(reader);
            reader.Close();

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

            StreamWriter writer = new StreamWriter(path);

            xmlSerializer.Serialize(writer, character);
            writer.Close();
        }
        public Character loadGame(string name)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Character>));
            var path = Directory.GetCurrentDirectory() + "//SavedCharacter.xml";
            StreamReader file = new StreamReader(path);
            List<Character> characters = (List<Character>)xmlSerializer.Deserialize(file);
            file.Close();

            foreach(Character character in characters)
            {
                if (character.name == name) return character;
            }

            return null;
        }
        public List<Action> actions(RacesEnum race) 
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Action>));
            var path = Directory.GetCurrentDirectory() + "//SavedCharacter.xml";
            StreamReader reader = new StreamReader(path);
            List<Action> tmp = (List<Action>)xmlSerializer.Deserialize(reader);
            reader.Close();
            List<Action> actions = new List<Action>();
            foreach(Action action in tmp)
            {
                if (action.race.Contains(race)) actions.Add(action);
            }
            return actions;
        }
    }
}
