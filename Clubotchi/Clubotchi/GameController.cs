using System;
using System.Collections.Generic;

namespace Clubotchi
{
    internal class GameController
    {
        //A járékos álltal irányított karakter
        public Character character;
        //Az akciók szerializálásához használt objektum
        private Serializer serializer = new Serializer();

        public GameController(){}


        internal void start()
        {
            setUpActions();
            while (true)    //The game loop
            {
                //Minden "körben" megmutatjuk a játékosnak hogy az adott karakter mi mindent tud csinálni
                character.showAction();
                var tmp = Console.ReadLine();
                //szétvágjuk a space-ek mentén a kapott utasításaokat és átalakítjuk int-ekké
                var tmplist = tmp.Split(" ");
                List<int> actions = new List<int>();
                foreach (string s in tmplist)
                {
                    try
                    {
                        actions.Add(Int32.Parse(s));
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Unable to parse '{0}'", s);
                    }
                }
                //végrehajtatjuk a karakterrel a kapott akciókat
                var returnValue = character.doAction(actions);
                //ha a karakter az akciók végrehajtása közben 1-esseé tér vissza az azt jelenti hogy a játékos ki akar lépni a játékból
                if (returnValue == 1) return;
            }
        }

        //Itt adjuk meg a karakternek hogy milyen akciókat hajthat véger
        public void setUpActions()
        {
            character.actions = serializer.actions(character.race);
        }
    }
}
