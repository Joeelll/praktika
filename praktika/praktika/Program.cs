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
            Console.WriteLine("Vajuta pohhuilt nuppu, et käivitada mäng");
            Console.ReadKey(true);

            Mait = new opilane();
            Mait.raha = 10;
            Mait.nalg = 0;
            Mait.janu = 0;
            Mait.vasimus = 15;
            Mait.volgnevused = 0;
            Mait.stress = 0;
            Mait.promill = 0;


            Console.WriteLine("Täna lähme kooli.\nVajuta: \nA - maga edasi\nB - mine kooli");

            key = Console.ReadKey().Key.ToString();
            kustuta_sisend();
            if (key.ToUpper() == "A")
            {
                magaEdasi();
                skoor++;
            }
            else if (key.ToUpper() == "B")
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
            Mait.vasimus -= 5;
            Mait.stress += 5;
            kontrollinaitajaid();
            skoor++;
            mineKooli();
        }

        static void mineKooli()
        {
            Console.WriteLine("\nLähen kooli");
            Mait.volgnevused = 0;
            Mait.vasimus += 10;
            Mait.stress += 5;
            kontrollinaitajaid();


            Console.WriteLine("Jõudsid kooli ja õpetaja andis rühmat tunnitöö.\nA - Tee kaasa\nB - Mängi growtopiat");
            tunnitoo();



            Console.WriteLine("On söögi vahetund.\nA - Lähed toitlustusasutusse Hesburger\nB - Lähed sööklasse");
            key = Console.ReadKey().Key.ToString();
            kustuta_sisend();
            if (key.ToUpper() == "A")
            {
                hessi();
            }
            else if (key.ToUpper() == "B")
            {
                sookla();

            }
            int chance = rnd.Next(1, 100);
            if (chance % 2 == 0)
            {
                kehaline();
            }
            else
            {
                kontrolltoo();
            }
            
        }


        static void hessi()
        {

            Console.WriteLine("Lähen Hessi!\nHessis on järjekord, jääd tundi hiljaks!");
            Mait.vasimus = 5;
            Mait.volgnevused = 10;
            Mait.nalg = 0;
            Mait.janu = 0;
            skoor++;
            
        }

        static void autosoit()
        {
            Console.WriteLine("Koolipäev on läbi ja ktte on jõudnud õhtu\nKas sa tahad minna ilma lubadeta autoga sõitma? \nA - Lähen sõitma!\nB - Ei lähe sõitma");
            key = Console.ReadKey().Key.ToString();
            kustuta_sisend();
            if (key.ToUpper() == "A")
            {
                int chance = rnd.Next(1, 100);
                if (chance % 2 == 0)
                {
                    Console.WriteLine("Jäid Politseile vahele, huligaan!");
                    Mait.stress += 30;
                    Mait.raha = 0;
                }
                else
                {
                    Console.WriteLine("Vedas, ei jäänud vahele!");
                    skoor++;
                }
            }
            else if (key.ToUpper() == "B")
            {
                Console.WriteLine("Väga tubli! Ilma lubadeta ei tohi sõita!");
                skoor++;
            }
        }

        static void sookla()
        {
            Console.WriteLine("\nLähed sööklasse!\nKontrollid, kas kaardi võtsid.");
            int chance = rnd.Next(1, 100);
            System.Threading.Thread.Sleep(2000);
            if (chance % 2 == 0)
            {
                Console.WriteLine("Jätsid kaardi koju lollpea!");
                Mait.stress += 10;
                Console.WriteLine("A - Räägi söögitädiga\nB - Osta puhvetist toitu\nC - Mine ikka Hesburgerisse");
                key = Console.ReadKey().Key.ToString();
                kustuta_sisend();
                if (key.ToUpper() == "A")
                {
                    if (Mait.volgnevused <= 5)
                    {
                        Console.WriteLine("\nOskad vene keelt hästi, saad süüa!");
                        skoor++;
                    }
                    else
                    {
                        Console.WriteLine("Mait: Izvinite u menja kartochka njetu!\nSöögitädi: Kartochka net, edy net!");
                        Mait.nalg += 20;
                        Mait.janu += 10;
                    }
                }
                else if (key.ToUpper() == "B")
                {
                    if (Mait.raha >= 5)
                    {
                        Mait.raha -= 5;
                        Console.WriteLine("Sööd kuivanud kooli pitsat! Gurmee!");
                        Mait.stress += 5;
                    }
                    else
                    {
                        Console.WriteLine("Sa oled rahadega põhjas. Jood teed ja varastad leiba!");
                        Mait.nalg += 15;
                        Mait.janu -= 5;
                    }
                }
                else if (key.ToUpper() == "C")
                {
                    hessi();
                }

            }
            else
            {
                Console.WriteLine("Kaart on olemas, täna saab süüa.");
                Mait.nalg = 0;
                Mait.janu = 0;
            }
<<<<<<< HEAD

        }





=======
        
}


        private static void kustuta_sisend()
        {
            if (Console.CursorTop == 0) return;
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }


>>>>>>> f812d7ac2fab1b4b948c77692db1cd240780450a



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
            Console.WriteLine("\nMäng on läbi, surid ära. Skoor on: " + skoor);
        }

        static void tunnitoo()
        {
            key = Console.ReadKey().Key.ToString();
            kustuta_sisend();
            if (key.ToUpper() == "A")
            {
                Console.WriteLine("\nOled tubli tuupur, õppisid Dell'i manuaali pähe!");
                Mait.stress += 10;
            }
            else if (key.ToUpper() == "B")
            {
                Console.WriteLine("\nAvasid growtopias viienda leveli, aga jäid vist teemast maha!");
                Mait.volgnevused += 10;
                Mait.stress -= 10;
                skoor++;
            }
        }

        static void kontrolltoo()
        {
            Console.WriteLine("Koolis on kontrolltöö!\nA - Spikerda\nB - Looda parimat");
            key = Console.ReadKey().Key.ToString();
            kustuta_sisend();
            if (key.ToUpper() == "A")
            {
                int chance = rnd.Next(1, 100);
                if (chance % 2 == 0)
                {
                    Console.WriteLine("\nSpikerdad edukalt, saad viie!");
                    skoor++;
                }
                else
                {
                    Console.WriteLine("\nJäid vahele, sa vana spikerdaja!");
                    Mait.stress += 10;
                    Mait.volgnevused += 15;
                }
            }
            else if (key.ToUpper() == "B")
            {
                if (Mait.volgnevused <= 5)
                {
                    Console.WriteLine("\nOled tubli tuupur ja saad viie!");
                    skoor++;
                }
                else
                {
                    Console.WriteLine("\nSaid kahe! Lollpea, mida sa üritad!");
                    Mait.stress += 10;
                    Mait.volgnevused += 15;
                    
                }
            }
<<<<<<< HEAD
            tups();
        
=======
            autosoit();
        }
        static void kehaline()
        {
            Console.WriteLine("\nAlgab kehalise tund!");
            int chance = rnd.Next(1, 100);
            Boolean exit = false;
            Boolean exit2 = false;
            Boolean exit3 = false;
            Boolean exit4 = false;
            if (chance % 2 == 0)
            {
                Console.WriteLine("Ei vedanud, täna oled sina rivikorrapidaja!");
                while (exit == false)
                {
                    Console.WriteLine("Alustad korrapidamist käsuga: \nA-Rühm joonele kogu\nB-Joondu\nC-Keskele vaat\nD-Valvel");
                    key = Console.ReadKey().Key.ToString();
                    kustuta_sisend();
                    if (key.ToUpper() == "A")
                    {
                        Console.WriteLine("\nKalle on rõõmus, õige käsk!");
                        while (exit2 == false)
                        {
                            Console.WriteLine("Järgmine käsk on: \nA-Joondu\nB-Keskele vaat\nC-Valvel");
                            key = Console.ReadKey().Key.ToString();
                            kustuta_sisend();
                            if (key.ToUpper() == "A")
                            {
                                Console.WriteLine("\nKalle on rõõmus, õige käsk!");
                                while (exit3 == false)
                                {
                                    Console.WriteLine("Järmine käsk on: \nA-Keskele vaat\nB-Valvel");
                                    key = Console.ReadKey().Key.ToString();
                                    kustuta_sisend();
                                    if (key.ToUpper() == "A")
                                    {
                                        Console.WriteLine("\nVale käsk! Kalle on vihane, 15 kätekõverdust!");
                                        Mait.stress += 5;
                                        Mait.vasimus += 5;
                                    }
                                    else if (key.ToUpper() == "B")
                                    {
                                        Console.WriteLine("\nKalle on rõõmus, õige käsk!");
                                        Console.WriteLine("Keskele vaat!");
                                        exit = true;
                                        exit2 = true;
                                        exit3 = true;
                                    }
                                }
                            }
                            else if (key.ToUpper() == "B")
                            {
                                Console.WriteLine("\nVale käsk! Kalle on vihane, 15 kätekõverdust!");
                                Mait.stress += 5;
                                Mait.vasimus += 5;
                            }
                            else if (key.ToUpper() == "C")
                            {
                                Console.WriteLine("\nVale käsk! Kalle on vihane, 15 kätekõverdust!");
                                Mait.stress += 5;
                                Mait.vasimus += 5;
                            }
                        }
                    }
                    else if (key.ToUpper() == "B")
                    {
                        Console.WriteLine("\nVale käsk! Kalle on vihane, 15 kätekõverdust!");
                        Mait.stress += 5;
                        Mait.vasimus += 5;
                    }
                    else if (key.ToUpper() == "C")
                    {
                        Console.WriteLine("\nVale käsk! Kalle on vihane, 15 kätekõverdust!");
                        Mait.stress += 5;
                        Mait.vasimus += 5;
                    }
                    else if (key.ToUpper() == "C")
                    {
                        Console.WriteLine("\nVale käsk! Kalle on vihane, 15 kätekõverdust!");
                        Mait.stress += 5;
                        Mait.vasimus += 5;
                    }
                    else if (key.ToUpper() == "D")
                    {
                        Console.WriteLine("\nVale käsk! Kalle on vihane, 15 kätekõverdust!");
                        Mait.stress += 5;
                        Mait.vasimus += 5;
                    }
                }
            }
            else
            {
                Console.WriteLine("Vedas! Keegi teine lollpea on rivikorrapidaja. Oled terve tunni telefonis jõusaalis!");
            }
>>>>>>> f812d7ac2fab1b4b948c77692db1cd240780450a
        }

        static void tups()
        {
            Console.WriteLine("Lähed peale kooli raha teenima tupsu müümisega? \n-A Lähen müüma, sest raha on vaja. \n-B Ei lähe müüma, raha on piisavalt praegu. ");
            key = Console.ReadKey().Key.ToString();
            if (key.ToUpper() == "A")
            {
                int chance = rnd.Next(1, 100);
                if (chance % 2 == 0)
                {
                    Console.WriteLine(" Müüsid tupsu ja ei jäänud vahele. Vedas!");
                    Mait.raha += 10;
                    Mait.stress += 5;
                    skoor++;
                }
                else
                {
                    Console.WriteLine(" Müüsid tupsu ja jäid vahele");
                    Mait.raha -= 10;
                    Mait.stress += 15;
                    Mait.vasimus += 10;
                }
            }
            if (key.ToUpper() == "B")
            {
                Console.WriteLine("Tubli! Tupsu ei tohigi müüa");
                skoor++;
            }
        }







        static void WaitForKey(ConsoleKey key)
        {
            while (Console.ReadKey(true).Key != key)
            { }
        }
    }
}




    

