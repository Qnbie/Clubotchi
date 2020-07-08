using System.Collections.Generic;

namespace Clubotchi
{
    internal abstract class Character
    {
        public string name { set; get; }
        public RacesEnum race { set; get; }
        public List<Action> actions { set; get; }

        protected int hunger { set; get; }
        protected int fatigue { set; get; }
        protected int boredome { set; get; }

        protected int mood { set; get; }

        public Character() { }

        public Character(string name)
        {
            this.name = name;
        }
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