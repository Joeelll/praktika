﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktika
{
    class Program
    {
        internal static opilane Mait = new opilane();

        static void Main(string[] args)
        {
            Console.WriteLine("Vajuta Y, et käivitada mäng");
            WaitForKey(ConsoleKey.Y);

            Mait.raha = 10;
            Mait.nalg = 0;
            Mait.janu = 0;
            Mait.vasimus = 15;
            Mait.volgnevused = 0;
            Mait.stress = 0;

            Console.WriteLine("Täna lähme kooli. \nVajuta A - maga edasi\n B- mine kooli");
            string key = Console.ReadKey().Key.ToString();

            if (key.ToUpper() == "A")
            {
                magaEdasi();
            }
            else if(key.ToUpper() == "B")
            {
                mineKooli();
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

            Console.WriteLine();
        }

        static void alkomyrgitus()
        {

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
    }
}
