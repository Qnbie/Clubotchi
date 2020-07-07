using System.Collections.Generic;

namespace Clubotchi
{
    internal class Pinguin : Character
    {
        public Pinguin(string name) : base(name)
        {
            race = RacesEnum.Pinguin;
        }

        public override void error(int number)
        {
            System.Console.WriteLine($"Action numre {0}? I'm not sure what kind of action it is. Maybe try another one.", number);
        }

        public override void report()
        {
            System.Console.WriteLine("pingvin");
        }
    }
}