using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Clubotchi
{
    class Serializer
    {
        public List<Action> actions(RacesEnum race) 
        {
            //read the file
            var path = Directory.GetCurrentDirectory() + "//SavedActions.json";
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
