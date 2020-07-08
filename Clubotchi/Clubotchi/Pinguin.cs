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
            System.Console.WriteLine($"Action number {0}? I'm not sure what kind of action it is. Maybe try another one.", number);
        }

        public override void report()
        {
            //hunger status
            if (hunger < -50) System.Console.WriteLine("I'm STARVING");
            else if (hunger < -15) System.Console.WriteLine("I'm hungry");
            else if (hunger > 50) System.Console.WriteLine("I'm full");

            //fatigue status
            if (fatigue < -50) System.Console.WriteLine("I have to sleep");
            else if (fatigue < -15) System.Console.WriteLine("I'm tired");
            else if (fatigue > 50) System.Console.WriteLine("I slept too much");

            //boredom status
            if (boredome < -50) System.Console.WriteLine("I'm VERY bored");
            else if (boredome < -15) System.Console.WriteLine("I am bored");
            else if (boredome > 50) System.Console.WriteLine("I have an adrenaline rush");

            //mood status
            if (mood < -50) System.Console.WriteLine("I'm sad :(");
            else if (mood <= 50) System.Console.WriteLine("I'm ok :|");
            else if (mood > 50) System.Console.WriteLine("I'm happy :)");
        }
    }
}