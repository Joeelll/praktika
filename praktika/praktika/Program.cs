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
        static bool restartGame = false;
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Vajuta pohhuilt nuppu, et käivitada mäng");
            Console.ReadKey(true);
            game();
        }


        static void game()
        {
            if (restartGame == false)
            {
                Mait = new opilane();
                Mait.raha = 10;
                Console.WriteLine("\nSul on raha: " + Mait.raha);
                Mait.nalg = 0;
                Console.WriteLine("Su nälg on hetkel: " + Mait.nalg);
                Mait.janu = 0;
                Console.WriteLine("Su janu on: " + Mait.janu);
                Mait.vasimus = 15;
                Console.WriteLine("Väsimus on: " + Mait.vasimus);
                Mait.volgnevused = 0;
                Console.WriteLine("Võlgnevuste suurus on: " + Mait.volgnevused);
                Mait.stress = 90;
                Console.WriteLine("Stressinäitaja on: " + Mait.stress);
                Mait.promill = 0;
                Console.WriteLine("Joobeseisund on " + Mait.promill + " promilli.");
                Mait.tups = 10;

                Console.WriteLine("\nOn varahommik ja tuleb kooli minna. Sa ei läinud eile normaalsel ajal magama, nagu sul kombeks on ja nüüd on uni rõvedalt suur. Sul on valida kas:\nVajuta: \nA - Maga edasi\nB - Mine kooli\n");

                key = Console.ReadKey().Key.ToString();
                kustuta_sisend();
                if (key.ToUpper() == "A")
                {
                    skoor++;
                    magaEdasi();
                }
                else if (key.ToUpper() == "B")
                {
                    skoor++;
                    mineKooli();
                }
            }
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
            var surnud = kontrollinaitajaid();
            if (surnud)
            {
                game();
            }

            Console.WriteLine("Jõudsid kooli ja õpetaja andis rühmatunnitöö.\nA - Tee kaasa\nB - Mängi growtopiat\n");
            tunnitoo();

            Console.WriteLine("On söögi vahetund.\nA - Lähed toitlustusasutusse Hesburger\nB - Lähed sööklasse\n");
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
            Console.WriteLine("\nKoolipäev on läbi ja kätte on jõudnud õhtu\nKas sa tahad minna ilma lubadeta autoga sõitma? \nA - Lähen sõitma!\nB - Ei lähe sõitma\n");
            key = Console.ReadKey().Key.ToString();
            kustuta_sisend();
            if (key.ToUpper() == "A")
            {
                int chance = rnd.Next(1, 100);
                if (chance % 2 == 0)
                {
                    Console.WriteLine("\nJäid Politseile vahele, huligaan!\n");
                    Mait.stress += 30;
                    Mait.raha = 0;
                }
                else
                {
                    Console.WriteLine("\nVedas, ei jäänud vahele!\n");
                    skoor++;
                }
            }
            else if (key.ToUpper() == "B")
            {
                Console.WriteLine("Väga tubli! Ilma lubadeta ei tohi sõita!\n");
            }
            var surnud = kontrollinaitajaid();
            if (surnud)
            {
                game();
            }
            ohtusook();
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
                Console.WriteLine("A - Räägi söögitädiga\nB - Osta puhvetist toitu\nC - Mine ikka Hesburgerisse\n");
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
                        Console.WriteLine("\nMait: Izvinite u menja kartochka njetu!\nSöögitädi: Kartochka net, edy net!");
                        Mait.nalg += 20;
                        Mait.janu += 10;
                    }
                }
                else if (key.ToUpper() == "B")
                {
                    kustuta_sisend();
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
            var surnud = kontrollinaitajaid();
            if (surnud)
            {
                game();
            }
        }

        static void kustuta_sisend()
        {
            if (Console.CursorTop == 0) return;
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        static void alkomyrgitus()
        {
            if (Mait.raha >= 5)
            {
                Mait.raha -= 5;
                Mait.stress += 10;
                Console.WriteLine("Haiglaarve tuli 5 euri. Sul on raha alles: " + Mait.raha + "euri");
            }
            else
            {
                Console.WriteLine("Sul pole raha, et haiglaarvet maksta. Sind jäetakse surema.");
                surm();
            }
            var surnud = kontrollinaitajaid();
            if (surnud)
            {
                game();
            }
        }

        static bool kontrollinaitajaid()
        {
            if (Mait.stress >= 100)
            {
                Console.WriteLine("\nTegid suicide.");
                var sunud = surm();
                return sunud;
            }
            if (Mait.nalg >= 100)
            {
                Console.WriteLine("Surid nälga.");
                var sunud = surm();
                return sunud;
            }
            if (Mait.promill >= 75)
            {
                Console.WriteLine("Said alkoholimürgituse, sind viiakse kiirabiga haiglasse.");
                alkomyrgitus();
                skoor++;
                return false;
            }
            return false;
        }

        static bool surm()
        {
            Console.WriteLine("Mäng on läbi. Skoor on: " + skoor);
            Console.WriteLine("A- alusta uuesti\n B- pane mäng kinni");

            skoor = 0;
            key = Console.ReadKey().Key.ToString();
            kustuta_sisend();
            if (key.ToUpper() == "A")
            {
                Console.Clear();
                game();
            }
            else if (key.ToUpper() == "B")
            {
                Environment.Exit(0);
            }
            return restartGame = true;
        }

        static void tunnitoo()
        {
            key = Console.ReadKey().Key.ToString();
            kustuta_sisend();
            if (key.ToUpper() == "A")
            {
                Console.WriteLine("\nOled tubli tuupur, õppisid Dell'i manuaali pähe!");
                Mait.vasimus += 10;
            }
            else if (key.ToUpper() == "B")
            {
                Console.WriteLine("\nAvasid growtopias viienda leveli, aga jäid vist teemast maha!");
                Mait.volgnevused += 10;
                Mait.stress -= 10;
                skoor++;
            }
            var surnud = kontrollinaitajaid();
            if (surnud)
            {
                game();
            }
        }

        static void kontrolltoo()
        {
            Console.WriteLine("\nKoolis on kontrolltöö!\nA - Spikerda\nB - Looda parimat\n");
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
            var surnud = kontrollinaitajaid();
            if (surnud)
            {
                game();
            }
            tups();
        }
        static void kehaline()
        {
            Console.WriteLine("\nAlgab kehalise tund!");
            int chance = rnd.Next(1, 100);
            Boolean exit = false;
            Boolean exit2 = false;
            Boolean exit3 = false;

            if (chance % 2 == 0)
            {
                Console.WriteLine("Ei vedanud, täna oled sina rivikorrapidaja!");
                while (exit == false)
                {
                    Console.WriteLine("\nAlustad korrapidamist käsuga: \nA-Rühm joonele kogu\nB-Joondu\nC-Keskele vaat\nD-Valvel");
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
                                        Console.WriteLine("Tund saab läbi.");
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
                Console.WriteLine("Vedas, mingi teine lollpea peab korrapidaja olema!\nIstud jõusaalis ja mängid growtopiat!");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("Tund saab läbi.");
            }
            var surnud = kontrollinaitajaid();
            if (surnud)
            {
                game();
            }
            autosoit();
        }


        static void tups()
        {
            Console.WriteLine("Lähed peale kooli raha teenima tupsu müümisega?\nA - Lähen müüma, sest raha on vaja.\nB - Ei lähe müüma, raha on piisavalt praegu.\n");
            key = Console.ReadKey().Key.ToString();
            kustuta_sisend();   
            if (key.ToUpper() == "A")
            {
                
                int chance = rnd.Next(1, 100);
                if (chance % 2 == 0)
                {
                    Console.WriteLine("Müüsid tupsu ja ei jäänud vahele. Vedas!");
                    Mait.raha += 10;
                    Mait.stress += 5;
                    skoor++;
                    Mait.tups -= 5;
                }
                else
                {
                    Console.WriteLine("Müüsid tupsu ja jäid vahele. Su kogu tups konfiskeeriti ära.");
                    Mait.raha -= 10;
                    Mait.stress += 15;
                    Mait.vasimus += 10;
                    Mait.tups = 0;
                }
            }
            else if (key.ToUpper() == "B")
            {
                kustuta_sisend();
                Console.WriteLine("Tubli! Tupsu ei tohigi müüa");
                skoor++;
            }
            var surnud = kontrollinaitajaid();
            if (surnud)
            {
                game();
            }
            autosoit();
        }

        static void ohtusook()
        {
            Console.WriteLine("\nOled jõudnud koju. On aeg suua ohtust \nA - Lahen soon ohtust kuna koht on tuhi ja olen vasinud \nB - Ei soo ohtust kuna csi on vaja pelada\n");
            key = Console.ReadKey().Key.ToString();
            if (key.ToUpper() == "A")
                kustuta_sisend();
            {
                Mait.vasimus -= 5;
                Mait.stress -= 5;
                skoor++;
            }
            if (key.ToUpper() == "B")
                kustuta_sisend();
            {
                Mait.vasimus += 10;
                Mait.stress -= 5;
                skoor++;
            }
            kodutood();
            
        }
        static void kodutood()
        {
            key = Console.ReadKey().Key.ToString();
            Console.WriteLine("\nNüüd oleks aeg teha kodutoid \nA - Teen oma kodutood ara \nB - Lähen puhkama, mängin arvutiga ja vaatan telekat");
            if (key.ToUpper() == "A")
                kustuta_sisend();
            {
                Console.WriteLine("Hea too! Opetajad on homme koolis kindlasti rahul");
                Mait.stress += 5;
                Mait.vasimus += 5;
                skoor++;
            }
            if (key.ToUpper() == "B")
                kustuta_sisend();
            {
                Console.WriteLine("Pole hullu. Said volgnevusi juurde, aga samas puhkasid välja");
                Mait.vasimus -= 5;
                Mait.stress -= 5;
                Mait.volgnevused += 10;
                skoor++;
            }

        }
            static void fight()
            {
                int Mait_hp = 100;
                int vastane_hp = 100;

                Console.WriteLine("Sul on " + Mait_hp + " HP\nVastasel on: " + vastane_hp + " HP");
                Console.WriteLine("Valikud:\nA-Jab\nB-Uppercut\n");

            }
        }
    }





    

