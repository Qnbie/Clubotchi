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
            //hunger status
            if (hunger < -50) System.Console.WriteLine("I NEED FOOD!");
            else if (hunger < -15) System.Console.WriteLine("I can eat something");
            else if (hunger > 50) System.Console.WriteLine("I'm done with eating");

            //fatigue status
            if (fatigue < -50) System.Console.WriteLine("I'm totaly drained");
            else if (fatigue < -15) System.Console.WriteLine("I am fatigued");
            else if (fatigue > 50) System.Console.WriteLine("Enough sleep for now");

            //boredom status
            if (boredome < -50) System.Console.WriteLine("PLEASE! WE HAVE TO DO SOMETHING!");
            else if (boredome < -15) System.Console.WriteLine("Booooooored");
            else if (boredome > 50) System.Console.WriteLine("I need some chill");

            //mood status
            if (mood < -50) System.Console.WriteLine("I'm distressed :(");
            else if (mood <= 50) System.Console.WriteLine("I'm fine :|");
            else if (mood > 50) System.Console.WriteLine("I'm GOOD :)");
        }
    }
}