using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktika
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vajuta Y, et käivitada mäng");
            WaitForKey(ConsoleKey.Y);
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
        }

        static void mineKooli()
        {
            Console.WriteLine("\nLähen kooli");
        }
    }
}
