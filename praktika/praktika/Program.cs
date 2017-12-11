using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktika
{
    class Program
    {
        static opilane Mait;
        static string key;
        static int skoor = 0;
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Vajuta Y, et käivitada mäng");
            WaitForKey(ConsoleKey.Y);

            Mait = new opilane();
            Mait.raha = 10;
            Mait.nalg = 0;
            Mait.janu = 0;
            Mait.vasimus = 15;
            Mait.volgnevused = 0;
            Mait.stress = 0;
            Mait.promill = 0;

            Console.WriteLine("Täna lähme kooli. \nVajuta A - maga edasi\n B- mine kooli");

            key = Console.ReadKey().Key.ToString();
            if (key.ToUpper() == "A")
            {
                magaEdasi();
                skoor++;
            }
            else if(key.ToUpper() == "B")
            {
                mineKooli();
                skoor++;
            }


            Console.ReadLine();
        }

        static void magaEdasi()
        {
            Console.WriteLine("\nOtsustasid edasi magada, kuid ema ajas sind ikka kooli.");
            Mait.volgnevused += 10;
            Mait.vasimus -= 75;
            Mait.stress += 5;
            mineKooli();
        }

        static void mineKooli()
        {
            Console.WriteLine("\nLähen kooli");
            Mait.volgnevused = 0;
            Mait.vasimus += 15;
            Mait.stress = 50;

            Console.WriteLine("On söögi vahetund.\n A- lähed hessi\n B- lähed sööklasse");
            key = Console.ReadKey().Key.ToString();
            if (key.ToUpper() == "A")
            {

                hessi();
            }
            else if (key.ToUpper() == "B")
            {
                sookla();
            }
        }

        static void hessi()
        {

            Console.WriteLine("-Lähen Hessi!");
            Console.WriteLine("Hessis on järjekord, jääd tundi hiljaks!");
            Mait.vasimus = 5;
            Mait.volgnevused = 10;
            Mait.nalg = 0;
            Mait.janu = 0;
            skoor++;
        }

        static void sookla()
        {
            Console.WriteLine("\nLähed sööklasse!" + "\nKontrollid, kas kaardi võtsid.");
            int chance = rnd.Next(1, 100);
            if (chance % 2 == 0)
            {
                Console.WriteLine("Jätsid kaardi koju lollpea!");
                Console.WriteLine("Klapid asjad söögitädiga ära");
                Mait.stress += 10;
                Mait.nalg = 0;
                Mait.janu = 0;
            }
            else
            {
                Console.WriteLine("Kaart on olemas, täna saab süüa");
                Mait.nalg = 0;
                Mait.janu = 0;
            }
        }

        static void alkomyrgitus()
        {
            if (Mait.raha >= 5)
            {
                Mait.raha -= 5;
                Console.WriteLine("Haiglaarve tuli 5 euri. Sul on raha alles: " + Mait.raha + "euri");
            }
            else
            {
                Console.WriteLine("Sul pole raha, et haiglaarvet maksta. Sind jäetakse surema.");
                surm();
            }
        }

        static void kontrollinaitajaid()
        {
            if (Mait.stress >= 100)
            {
                Console.WriteLine("Tegid suicide");
                surm();
            }
            if (Mait.nalg >= 100)
            {
                Console.WriteLine("Surid nälga");
                surm();
            }
            if (Mait.promill >= 75)
            {
                Console.WriteLine("Said alkoholimürgituse, sind viiakse kiirabiga haiglasse");
                alkomyrgitus();
                skoor++;
            }

        }
        
        static void surm()
        {
            Console.WriteLine("Mäng on läbi, surid ära. Skoor on: " + skoor);
        }

        static void WaitForKey(ConsoleKey key)
        {
            while (Console.ReadKey(true).Key != key)
            { }
        }
    }
}
