using System.Collections.Generic;

namespace Clubotchi
{
    // A játékos álltal irányított karater
    internal abstract class Character
    {
        public string name { set; get; }        // A karakter neve
        public RacesEnum race { set; get; }     // A karakter fajtája
        public List<Action> actions { set; get; }   // A karakter álltal végrehajtható akciók

        protected int hunger { set; get; }
        protected int fatigue { set; get; }
        protected int boredome { set; get; }

        protected int mood { set; get; }

        public Character() { }

        public Character(string name)
        {
            this.name = name;
        }
        //Kiírja a felhasználónakm hogy milyen akciókat tud a karakter elvégezni
        public virtual void showAction()
        {
            var index = 0;
            foreach(Action action in actions)
            {
                System.Console.WriteLine($"{index}: {action.name}");
                index++;
            }
            System.Console.WriteLine($"{index}: Exit Game");
        }
        /* A kapott lista alapján elvégzi a benne megjelölt akciókat
            Ha a játékos ki akar lépni a programbó 1-el tér vissza, egyébként 0-val*/
        public int doAction(List<int> actions) { 
            foreach(int actionIndex in actions)
            {
                if (actionIndex == this.actions.Count) return 1;
                else if (actionIndex > this.actions.Count) error(actionIndex);
                else
                {
                    this.hunger += this.actions[actionIndex].hunger;
                    this.fatigue += this.actions[actionIndex].fatigue;
                    this.boredome += this.actions[actionIndex].boredome;
                }
            }
            report();
            return 0;
        }
        // A karakter jelentést tesz a felhasználónak az állapotáról
        public abstract void report();
        // A karakter szól a felhasználónak ha olyan akciót akar választani amit a karakter nem képes elvégezni
        public abstract void error(int number);
    }
}