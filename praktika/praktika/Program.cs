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
        static string key = Console.ReadKey().Key.ToString();
        static int skoor = 0;

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

            Console.WriteLine("Täna lähme kooli. \nVajuta A - maga edasi\n B- mine kooli");

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

        static void WaitForKey(ConsoleKey key)
        {
            while (Console.ReadKey(true).Key != key)
            { }
        }

        static void magaEdasi()
        {
            Console.WriteLine("\nMagan edasi");
            Mait.volgnevused += 10;
            Mait.vasimus -= 75;
            Mait.stress = 0;
        }

        static void mineKooli()
        {
            Console.WriteLine("\nLähen kooli");
            Mait.volgnevused = 0;
            Mait.vasimus += 15;
            Mait.stress = 50;

            Console.WriteLine("On söögi vahetund.\n A- lähed hessi\n B- lähed sööklasse");
            if (key.ToUpper() == "A")
            {


            }
            else if (key.ToUpper() == "B")
            {

            }
        }

        static void hessi()
        {

        }

        static void sookla()
        {

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
            }
        }

        static void kontrollinaitajaid()
        {
            if (Mait.stress >= 100)
            {
                Console.WriteLine("Tegid suicide");
            }
            if (Mait.nalg >= 100)
            {
                Console.WriteLine("Surid nälga");
            }
            if (Mait.promill >= 75)
            {
                Console.WriteLine("Said alkoholimürgituse, sind viiakse kiirabiga haiglasse");
                alkomyrgitus();
            }

        }
        
        static void surm()
        {
            Console.WriteLine("Mäng on läbi, surid ära. Skoor on: " + skoor);
        }
    }
}
