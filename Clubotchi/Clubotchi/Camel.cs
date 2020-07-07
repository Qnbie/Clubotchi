using System.Collections.Generic;
using System.Transactions;

namespace Clubotchi
{
    internal class Camel : Character
    {
        public Camel(string name) : base(name)
        {
            race = RacesEnum.Camel;
        }

        public override void error(int number)
        {
            System.Console.WriteLine($"Hey doode! I dont know the action numre {0}! Pleas give me clear orders!", number);
        }

        public override void report()
        {
            System.Console.WriteLine("ooooooooo caaaamel");
        }
    }
}