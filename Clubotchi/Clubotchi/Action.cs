using System.Collections.Generic;

namespace Clubotchi
{
    internal class Action
    {
        public string name { set; get; }
        public RacesEnum[] race { set; get; }
        public int hunger { set; get; }
        public int fatigue { set; get; }
        public int boredome { set; get; }
    }
}