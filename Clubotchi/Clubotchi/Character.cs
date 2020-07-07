using System.Collections.Generic;

namespace Clubotchi
{
    internal abstract class Character
    {
        public string name { set; get; }
        public RacesEnum race { set; get; }
        public List<Action> actions { set; get; }

        private int hunger { set; get; }
        private int fatigue { set; get; }
        private int boredome { set; get; }
    
        private int mood { set; get; }

        public Character(string name)
        {
            this.name = name;
        }
        public virtual void showAction()
        {
            var index = 0;
            foreach(Action action in actions)
            {
                System.Console.WriteLine($"{0}: {1}", index, action.name);
                index++;
            }
            System.Console.WriteLine($"{0}: Save Game", index);
            System.Console.WriteLine($"{0}: Exit Game", index + 1);
        }
        public int doAction(List<int> actions) { 
            foreach(int actionIndex in actions)
            {
                if (actionIndex == actions.Count) return 1;
                else if (actionIndex == actions.Count + 1) return 2;
                else if (actionIndex == actions.Count + 1) error(actionIndex);
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
        public void copy(Character character)
        {
            this.hunger = character.hunger;
            this.fatigue = character.fatigue;
            this.boredome = character.boredome;
        }
        public abstract void report();
        public abstract void error(int number);
    }
}