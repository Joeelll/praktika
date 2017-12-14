using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
            Console.WindowWidth = 150;
            Console.WindowHeight = 30;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "MÄNG MAIDU ELUST!";
            Console.WriteLine("Vajuta pohhuilt nuppu, et käivitada mäng");
            Console.ReadKey(true);
            game();

        }


        static void game()
        {
            if (restartGame == false)
            {
                Mait = new opilane();
                Mait.raha = 15;
                Console.WriteLine("\nSul on raha: " + Mait.raha);
                Mait.nalg = 0;
                Console.WriteLine("Su nälg on hetkel: " + Mait.nalg);
                Mait.janu = 0;
                Console.WriteLine("Su janu on: " + Mait.janu);
                Mait.vasimus = 15;
                Console.WriteLine("Väsimus on: " + Mait.vasimus);
                Mait.volgnevused = 0;
                Console.WriteLine("Võlgnevuste suurus on: " + Mait.volgnevused);
                Mait.stress = 0;
                Console.WriteLine("Stressinäitaja on: " + Mait.stress);
                Mait.promill = 0;
                Console.WriteLine("Joobeseisund on " + Mait.promill + " promilli.");
                Mait.tups = 10;
                Thread.Sleep(1000);

                Console.Clear();
                Console.WriteLine(" 0000  000000    0000    0000  ");
                Console.WriteLine("0    0     0    0    0  0    0");
                Console.WriteLine("0    0   000    0    0  0    0");
                Console.WriteLine("0    0   0      0    0  0    0");
                Console.WriteLine(" 0000   0    o   0000    0000  ");
                Console.WriteLine("On varahommik ja tuleb kooli minna. Sa ei läinud eile normaalsel ajal magama, nagu sul kombeks on ja nüüd on uni rõvedalt suur.\nSul on valida kas:");
                Thread.Sleep(1500);
                skoor_pluss("A - Maga edasi, olen naguinii praktikas kõigest ees ja õps ei kontrolli kohalolekut.");
                Thread.Sleep(500);
                skoor_miinus("B - Mine kooli, koolis on Jaan ja Jaan on äge vend.\n");
                key = Console.ReadKey().Key.ToString();
                kustuta_sisend();
                if (key.ToUpper() == "A")
                {
                    skoor++;
                    magaEdasi();
                }
                else if (key.ToUpper() == "B")
                {
                    mineKooli();
                }
            }
        }

        static void magaEdasi()
        {
            Console.WriteLine(" 0000  000000   000000   0000  ");
            Console.WriteLine("0    0     0         0  0    0");
            Console.WriteLine("0    0   000     00000  0    0");
            Console.WriteLine("0    0   0           0  0    0");
            Console.WriteLine(" 0000   0    o  000000   0000  ");
            Console.WriteLine("\nOled parajalt oma astraalrännakut sooritamas, kui ema peksab su ukse maha ja ajab sind üles. Pead ikka kooli minnema.");
            Mait.volgnevused += 10;
            Mait.vasimus -= 5;
            Mait.stress += 5;
            kontrollinaitajaid();
            skoor++;
            Thread.Sleep(3333);
            Console.Clear();
            mineKooli();

        }

        static void mineKooli()
        {
            Console.Clear();
            Console.WriteLine("Tellid omale Uberi ja lähed kooli.");
            Thread.Sleep(1000);
            Console.Write("Sõidad kooli..... ");
            using (var progress = new ProgressBar())
            {
                for (int i = 0; i <= 100; i++)
                {
                    progress.Report((double)i / 50);
                    Thread.Sleep(50);
                }
            }
            Mait.volgnevused = 0;
            Mait.vasimus += 10;
            Mait.stress += 5;
            var surnud = kontrollinaitajaid();
            if (surnud)
            {
                game();
            }
            Console.Clear();
            Console.WriteLine("Oled jõudnud kooli. Tund hakkab, õpetaja andis rühmatunnitöö.");
            Thread.Sleep(2222);
            tunnitoo();

            Console.WriteLine("Kuuled kella helinat. Algab söögivahetund.");
            Thread.Sleep(2222);
            skoor_pluss("A - Lähed toitlustusasutusse Hesburger.");
            Thread.Sleep(500);
            skoor_miinus("B - Lähed sööklasse. Täna pidi eriti maitsev toit olema.\n");
            key = Console.ReadKey().Key.ToString();
            kustuta_sisend();
            if (key.ToUpper() == "A")
            {
                Console.Clear();
                Console.WriteLine("Lähed Hesburgerisse...");
                using (var progress = new ProgressBar())
                {
                    for (int i = 0; i <= 100; i++)
                    {
                        progress.Report((double)i / 50);
                        Thread.Sleep(50);
                    }
                }
                Thread.Sleep(2000);
                hessi();
            }
            else if (key.ToUpper() == "B")
            {
                Console.Clear();
                sookla();

            }
            int chance = rnd.Next(1, 100);
            if (chance % 2 == 0)
            {
                Console.Clear();
                kehaline();
            }
            else
            {
                Console.Clear();
                kontrolltoo();
            }
        }

        static void hessi()
        {
            if (Mait.raha <= 5)
            {
                skoor_miinus("Läksid Hesburgerisse, aga unustsid, et oled õppetoetust saamata ja rahad on otsas. Jääd ühe tunni hiljaks!");
                Mait.volgnevused += 10;
                Mait.vasimus += 5;
                Mait.nalg += 10;
                Mait.janu += 10;
                skoor--;
                Thread.Sleep(2000);
                Console.Clear();
            }
            else
            {
                skoor_pluss("Läksid Hesburgerisse, aga seal oli pikk järjekord ja sa jäid selle tõttu ühe tunni hiljaks!");
                Mait.vasimus += 5;
                Mait.volgnevused += 10;
                Mait.nalg = 0;
                Mait.janu = 0;
                skoor++;
                Thread.Sleep(2000);
                Console.Clear();
            }
        }

        static void autosoit()
        {
            Console.WriteLine("\nKoolipäev on läbi ja kätte on jõudnud õhtu\nKas sa tahad minna ilma lubadeta autoga sõitma?");
            skoor_pluss("A - Lähen sõitma!");
            skoor_miinus("B - Ei lähe sõitma\n");
            key = Console.ReadKey().Key.ToString();
            kustuta_sisend();
            if (key.ToUpper() == "A")
            {
                int chance = rnd.Next(1, 100);
                if (chance % 2 == 0)
                {
                    Console.WriteLine("\nJäid Politseile vahele, huligaan!");
                    Mait.stress += 30;
                    Mait.raha = 0;
                    politseilabiraakimised();
                }
                else
                {
                    Console.WriteLine("\nVedas, ei jäänud vahele!");
                    skoor++;
                }
            }
            else if (key.ToUpper() == "B")
            {
                Console.WriteLine("\nVäga tubli! Ilma lubadeta ei tohi sõita!");
            }
            var surnud = kontrollinaitajaid();
            if (surnud)
            {
                game();
            }
            ohtusook();
        }

        static void politseilabiraakimised()
        {
            Console.WriteLine("Kas sa proovid politseist välja rääkida? Kui läbirääkimised ei õnnestu, siis on suurem trahv");
            skoor_pluss("A - Proovi valja rääkida");
            skoor_miinus("B - Ära proovi rääkida, su eesti keele hinne on 3 ju.\n");
            key = Console.ReadKey().Key.ToString();
            kustuta_sisend();
            if (key.ToUpper() == "A")
            {
                int chance = rnd.Next(1, 100);
                if (chance % 2 == 0)
                {
                    skoor_pluss("\n Suutsid politsei ära rääkida, said vaiksema trahvi");
                    Mait.raha -= 5;
                    Mait.stress += 15;
                    Mait.vasimus += 5;
                    skoor++;
                }
                else
                {
                    skoor_miinus("\nSa ei rääkinud politseid ara, said suurema trahvi");
                    Mait.raha -= 15;
                    Mait.stress += 20;
                    Mait.vasimus += 5;
                    skoor--;
                }
            }
            if (key.ToUpper() == "B")
            {
                Console.WriteLine("\nSa ei proovinud politseiga raakida, said tavalise trahvi.");
                Mait.raha -= 10;
                Mait.stress += 15;
                Mait.vasimus += 5;
            }

        }
        static void sookla()
        {
            Console.WriteLine("Lähed sööklasse!\nKontrollid, kas kaardi võtsid.");
            int chance = rnd.Next(1, 100);
            Thread.Sleep(2000);
            if (chance % 2 == 0)
            {
                skoor_miinus("Jätsid kaardi koju lollpea!");
                Mait.stress += 10;
                skoor--;
                Console.WriteLine("\nA - Räägi söögitädiga");
                Console.WriteLine("B - Osta puhvetist toitu");
                skoor_pluss("C - Mine ikka Hesburgerisse\n");
                key = Console.ReadKey().Key.ToString();
                kustuta_sisend();
                if (key.ToUpper() == "A")
                {
                    if (Mait.volgnevused <= 5)
                    {
                        Console.WriteLine("\nRäägid söögitädiga...");
                        using (var progress = new ProgressBar())
                        {
                            for (int i = 0; i <= 100; i++)
                            {
                                progress.Report((double)i / 50);
                                Thread.Sleep(50);
                            }
                        }
                        skoor_pluss("\nOskad vene keelt hästi, saad süüa!");
                        skoor++;
                        
                    }
                    else
                    {
                        skoor_miinus("\nMait: Izvinite u menja kartochka njetu!\nSöögitädi: Kartochka net, edy net!");
                        Mait.nalg += 20;
                        Mait.janu += 10;
                        skoor--;
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
                        Mait.nalg += 10;
                        Mait.janu -= 10;
                    }
                }
                else if (key.ToUpper() == "C")
                {
                    Thread.Sleep(2000);
                    hessi();
                }
            }
            else
            {
                if (chance % 2 == 0)
                {
                    Console.WriteLine("Kaart on olemas, täna on söögiks kalaburger.");
                }
                else
                {
                    Console.WriteLine("Kaart on olemas, täna on söögiks kalasupp.");
                }
                Mait.nalg = 0;
                Mait.janu = 0;
                
            }
            var surnud = kontrollinaitajaid();
            if (surnud)
            {
                game();
            }
            Console.WriteLine("Kell käib. Söögivahetund sai läbi. Lähed järgmisesse tundi.");
            Thread.Sleep(5000);
            Console.Clear();
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
            skoor_miinus("A - Tee kaasa, sest sa tahad ka ükspäev oma firma teha ja tulumaksu mitte maksta.");
            Thread.Sleep(500);
            skoor_pluss("B - Lase teistel kõik töö ära teha nagu kombeks, sa lähed ju Soome tänavakive panema.\n");
            key = Console.ReadKey().Key.ToString();
            kustuta_sisend();
            if (key.ToUpper() == "A")
            {
                Console.WriteLine("\nOled tubli tuupur, õppisid venekeelse Dell'i manuaali pähe! Tulevikutöö läpakaid parandada Lasnamäel on juba kasvõi kotis!");
                Mait.vasimus += 10;
            }
            else if (key.ToUpper() == "B")
            {
                Console.WriteLine("\nLased teistel kõik tunnis ära teha. Ilmselt ei tee sa enam vahet, mis on voda ja vodka vahe, kuid sellest hoolimata ei ole sa enam stressis.");
                Mait.volgnevused += 10;
                Mait.stress -= 10;
                skoor++;
            }
            var surnud = kontrollinaitajaid();
            if (surnud)
            {
                game();
            }
            Thread.Sleep(3000);
            Console.Clear();
        }

        static void kontrolltoo()
        {
            Console.WriteLine("Tund algab. Said üllatusena teada, et meil on kontrolltöö!");
            skoor_pluss("A - Spikerda");
            Console.WriteLine("B - Looda parimat\n");
            key = Console.ReadKey().Key.ToString();
            kustuta_sisend();
            if (key.ToUpper() == "A")
            {
                int chance = rnd.Next(1, 100);
                if (chance % 2 == 0)
                {
                    skoor_pluss("\nSpikerdad edukalt, saad viie!");
                    skoor++;
                }
                else
                {
                    skoor_miinus("\nJäid vahele, sa vana spikerdaja!");
                    Mait.stress += 10;
                    Mait.volgnevused += 15;
                    skoor--;
                }
                Thread.Sleep(2000);
                Console.Clear();
            }
            else if (key.ToUpper() == "B")
            {
                if (Mait.volgnevused <= 5)
                {
                    skoor_pluss("\nOled tubli tuupur ja saad viie!");
                    skoor++;
                }
                else
                {
                    skoor_miinus("\nSaid kahe! Lollpea, mida sa üritad!");
                    Mait.stress += 10;
                    Mait.volgnevused += 15;
                    skoor--;

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
            Console.WriteLine("Söögivahetund sai läbi. Hakkab kehalise tund Kallega.");
            int chance = rnd.Next(1, 100);
            Boolean exit = false;
            Boolean exit2 = false;
            Boolean exit3 = false;
            Thread.Sleep(2000);
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
                        skoor_pluss("\nKalle on rõõmus, õige käsk!");
                        skoor++;
                        while (exit2 == false)
                        {
                            Console.WriteLine("Järgmine käsk on: \nA-Joondu\nB-Keskele vaat\nC-Valvel");
                            key = Console.ReadKey().Key.ToString();
                            kustuta_sisend();
                            if (key.ToUpper() == "A")
                            {
                                skoor_pluss("\nKalle on rõõmus, õige käsk!");
                                skoor++;
                                while (exit3 == false)
                                {
                                    Console.WriteLine("Järmine käsk on: \nA-Keskele vaat\nB-Valvel");
                                    key = Console.ReadKey().Key.ToString();
                                    kustuta_sisend();
                                    if (key.ToUpper() == "A")
                                    {
                                        skoor_miinus("\nVale käsk! Kalle on vihane, 15 kätekõverdust!");
                                        Mait.stress += 5;
                                        Mait.vasimus += 5;
                                        skoor--;
                                    }
                                    else if (key.ToUpper() == "B")
                                    {
                                        skoor_pluss("\nKalle on rõõmus, õige käsk!");
                                        skoor++;
                                        Thread.Sleep(1000);
                                        Console.WriteLine("Keskele vaat!");
                                        exit = true;
                                        exit2 = true;
                                        exit3 = true;
                                        Console.WriteLine("Tund saab läbi.\n");
                                        Thread.Sleep(2000);
                                    }
                                }
                            }
                            else if (key.ToUpper() == "B")
                            {
                                skoor_miinus("\nVale käsk! Kalle on vihane, 15 kätekõverdust!");
                                skoor--;
                                Mait.stress += 5;
                                Mait.vasimus += 5;
                            }
                            else if (key.ToUpper() == "C")
                            {
                                skoor_miinus("\nVale käsk! Kalle on vihane, 15 kätekõverdust!");
                                skoor--;
                                Mait.stress += 5;
                                Mait.vasimus += 5;
                            }
                        }
                    }
                    else if (key.ToUpper() == "B")
                    {
                        skoor_miinus("\nVale käsk! Kalle on vihane, 15 kätekõverdust!");
                        skoor--;
                        Mait.stress += 5;
                        Mait.vasimus += 5;
                    }
                    else if (key.ToUpper() == "C")
                    {
                        skoor_miinus("\nVale käsk! Kalle on vihane, 15 kätekõverdust!");
                        Mait.stress += 5;
                        Mait.vasimus += 5;
                        skoor--;
                    }
                    else if (key.ToUpper() == "C")
                    {
                        skoor_miinus("\nVale käsk! Kalle on vihane, 15 kätekõverdust!");
                        Mait.stress += 5;
                        Mait.vasimus += 5;
                        skoor--;
                    }
                    else if (key.ToUpper() == "D")
                    {
                        skoor_miinus("\nVale käsk! Kalle on vihane, 15 kätekõverdust!");
                        Mait.stress += 5;
                        Mait.vasimus += 5;
                        skoor--;
                    }
                }
            }
            else
            {
                skoor_pluss("Vedas, mingi teine lollpea peab korrapidaja olema!\nIstud jõusaalis ja mängid growtopiat!");
                skoor++;
                Thread.Sleep(5000);
                Console.WriteLine("Tund saab läbi.");
                Console.Clear();
            }
            var surnud = kontrollinaitajaid();
            if (surnud)
            {
                game();
            }
            tups();
        }


        static void tups()
        {
            Console.WriteLine("Kell käib ja viimane tund sai läbi. Kas sa lähed peale kooli raha teenima tupsu müümisega?");
            Thread.Sleep(2000);
            skoor_pluss("A - Lähen müüma, sest raha on vaja.");
            skoor_miinus("B - Ei lähe müüma, raha on piisavalt praegu.\n");
            key = Console.ReadKey().Key.ToString();
            kustuta_sisend();
            int chance = rnd.Next(1, 100);
            if (key.ToUpper() == "A")
            {
                if (chance % 2 == 0)
                {
                    skoor_pluss("\nMüüsid tupsu ja ei jäänud vahele. Vedas!");
                    Mait.raha += 10;
                    Mait.stress += 5;
                    skoor++;
                    Mait.tups -= 5;
                }
                else
                {
                    skoor_miinus("\nMüüsid tupsu ja jäid vahele. Su kogu tups konfiskeeriti ära.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    politseilabiraakimised();
                    skoor--;

                }
            }
            else if (key.ToUpper() == "B")
            {
                kustuta_sisend();
                skoor_pluss("\nTubli! Tupsu ei tohigi müüa");
                skoor++;
            }
            var surnud = kontrollinaitajaid();
            if (surnud)
            {
                game();
            }
            Thread.Sleep(2000);
            Console.Clear();
            autosoit();
        }

        static void ohtusook()
        {
            Console.WriteLine("\nOled nüüd jõudnud koju ja on aeg süüa õhtust \nA - Lahen söön õhtust, sest kõht on tühi ja olen väsinud \nB - Ei söö õhtust, sest CSi on vaja pelada\n");
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
            Console.WriteLine("\nNüüd oleks aeg teha kodutöid");
            skoor_miinus("A - Teen oma kodutööd ära");
            skoor_pluss("B - Lähen puhkama, mängin arvutiga ja vaatan telekat\n");
            key = Console.ReadKey().Key.ToString();
            kustuta_sisend();
            if (key.ToUpper() == "A")
            {
                Console.WriteLine("\nHea töö! Õpetajad on homme koolis kindlasti rahul");
                Mait.stress += 5;
                Mait.vasimus += 5;
                skoor--;
            }
            if (key.ToUpper() == "B")
            {
                Console.WriteLine("\nPole hullu. Said võlgnevusi juurde, aga samas puhkasid välja");
                Mait.vasimus -= 5;
                Mait.stress -= 5;
                Mait.volgnevused += 10;
                skoor++;
            }
            magamine();
        }
        static void magamine()
        {
            Console.WriteLine("\nKell on palju. On aeg magama minna \nA - Lähen magama \nB - Ei lähe magama ja pelan terve öö csi\n");
            key = Console.ReadKey().Key.ToString();
            kustuta_sisend();
            if (key.ToUpper() == "A")
            {
                skoor_miinus("\nLäksid magama, puhkad välja.");
                Mait.vasimus -= 10;
                Mait.stress -= 5;
                Mait.nalg += 5;
                Mait.janu += 5;
                skoor--;
                hommik2();
            }
            else if (key.ToUpper() == "B")
            {
                skoor_pluss("\nPelasid terve öö csi ja oled nüüd väga väsinud.");
                Mait.vasimus += 20;
                Mait.nalg += 10;
                Mait.janu += 10;
                skoor++;
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
                Mait.stress = 0;
                Console.WriteLine("Stressinäitaja on: " + Mait.stress);
                Mait.promill = 0;
                Console.WriteLine("Joobeseisund on " + Mait.promill + " promilli.");
                Mait.tups = 10;
                Console.WriteLine("\nMÄNG ON LÄBI!");
            }
        }

        static void hommik2()
        {
            Console.WriteLine("Hommik! Kätte on saabunud nädalavahetus.");
            skoor_miinus("A - Lähen teen süüa köögis");
            skoor_pluss("B - Lähen söön väljas");
            skoor_pluss("C - Magan edasi");
            key = Console.ReadKey().Key.ToString();
            kustuta_sisend();
            if (key.ToUpper() == "A")
            {
                Console.WriteLine("Tegid omale vorstivõileiva nagu sööklas ja oled valmis tegudeks!");
                Mait.nalg -= 5;
                Mait.janu -= 5;
                Mait.vasimus -= 5;
                Mait.stress -= 5;
                skoor--;
            }
            if (key.ToUpper() == "B")
            {
                Console.WriteLine("Sõid väljas ja oled valmis tegudeks!");
                Mait.raha -= 5;
                Mait.nalg -= 5;
                Mait.janu -= 5;
                Mait.stress -= 5;
                Mait.vasimus -= 5;
                skoor++;

            }
            if (key.ToUpper() == "C")
            {
                Console.WriteLine("Magasid kaua ja oled valmis tegudeks tühja kõhuga");
                Mait.vasimus -= 10;
                Mait.stress -= 5;
                Mait.janu += 5;
                Mait.nalg += 5;
                skoor++;
                plaanid();

            }


        }

        static void plaanid()
        {
            Console.WriteLine("Kuna kätte on jõudnud nädalavahetus, siis sul pole kooli. Seega mis sa teha tahad?");
            skoor_pluss("A - Mängin terve päev csi ja õhtul lähed peole");
            skoor_pluss("B - Saad sõpradega kokku, veedad sõpradega aega ja õhtul lähed peole");
            skoor_miinus("C - Teed terve päev võlgnevusi tasa ja lähed õhtul peole");
            key = Console.ReadKey().Key.ToString();
            kustuta_sisend();
            if (key.ToUpper() == "A")
            {
                Console.WriteLine("Mängisid terve päev CSi, aga kahjuks ei saanud rank upi. Lähed peole");
                Mait.vasimus += 5;
                Mait.janu += 5;
                Mait.nalg += 5;
                skoor++;
            }
            if (key.ToUpper() == "B")
            {
                Console.WriteLine("Olid terve päev sõpradega. Tegite Solarises torusiilipommi ja muid sehkendusi. Lähed peole");
                Mait.tups += 5;
                Mait.vasimus += 5;
                Mait.stress += 5;
                Mait.janu += 5;
                Mait.nalg += 5;
                skoor++;
            }
            if (key.ToUpper() == "C")
            {
                Console.WriteLine("Õppisid terve päev oma võlgnevusi. Lähed peole");
                Mait.janu += 5;
                Mait.nalg += 5;
                Mait.vasimus += 10;
                Mait.stress += 15;
                Mait.volgnevused -= 20;
                skoor--;
            }
        }

        static void pidu()
        {
            Console.WriteLine("Jõuad peole, hakkad sõpradega viina võtma.");
            Mait.promill += 30;
            Thread.Sleep(1111);
            while (true)
            {
                Console.WriteLine("Kas tahad veel paar pitsi viina võtta?");
                skoor_pluss("A- Poh, mis see paar pitsi ikka teeb?");
                skoor_miinus("B- Ei ma olen ilge pussar ja lähen nüüd koju YouChikke vaatama.\n");
                key = Console.ReadKey().Key.ToString();
                kustuta_sisend();
                if (key.ToUpper() == "A")
                {
                    Mait.promill += 15;
                    skoor++;
                    var surnud = kontrollinaitajaid();
                    if (surnud)
                    {
                        game();
                    }
                }
                else if (key.ToUpper() == "B")
                {
                    pealePidu();
                }
            }
        }

        static void pealePidu()
        {
            Console.WriteLine("Jõudsid öösel koju, ema sai tigedaks su peale, sest käisid joomas. Lähed magama.");
            Thread.Sleep(1111);
            Console.WriteLine("Ema ajab sind tigedalt üles ja käsib sul hoovis tööle hakata.");
            Console.WriteLine("Hakkad tööle pohmakaga.....");
            using (var progress = new ProgressBar())
            {
                for (int i = 1; i < 200; i++)
                {
                    progress.Report((double)i / 180);
                    Thread.Sleep(20);
                }
            }
            Mait.stress += 10;
            Mait.vasimus += 50;
            Console.WriteLine("Töö tehtud.");
            Thread.Sleep(1111);
            Console.WriteLine("Oled räigelt väsinud ja tahaksid magada.");
        }

        static void skoor_pluss(string valik)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(valik);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void skoor_miinus(string valik)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(valik);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
