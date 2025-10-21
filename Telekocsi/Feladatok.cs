using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekocsi
{
    internal class Feladatok
    {
        private List<Auto> autok = new List<Auto>();
        private List<Igeny> igenyek = new List<Igeny>();
        public Feladatok() {
            F01("autok.csv");
            F02();
            F03();
            F04();
            F05("igenyek.csv");
            F06();
        }

        private void F01(string file)
        {
            StreamReader sr = new StreamReader(file);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(";");
                autok.Add(new Auto(sor[0], sor[1], sor[2], sor[3], int.Parse(sor[4])));
            }
            
        }

        private void F02()
        {
            Console.WriteLine($"2. feladat\n{autok.GroupBy(a => a.RendSzam).Count()} autós hirdet fuvart");            
        }

        private void F03()
        {
            Console.WriteLine($"3. feladat\nÖsszesen {autok.Where(a => a.Cel == "Miskolc" && a.Indulas == "Budapest").Sum(a => a.Ferohely)} férőhelyet hirdettek az autósok Budapestről Miskolcra");
        }

        private void F04()
        {
            Auto legtobb = autok.OrderByDescending(a => a.Ferohely).First();
            Console.WriteLine($"4. feladat\nA legtöbb férőhelyet ({legtobb.Ferohely}-et) a {legtobb.Indulas}-{legtobb.Cel} útvonalon ajánlották fel a hírdetők");
        }

        private void F05(string file)
        {
            Console.WriteLine("5.feladat");
            StreamReader sr = new StreamReader(file);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(";");
                igenyek.Add(new Igeny(sor[0], sor[1], sor[2], int.Parse(sor[3])));
            }

            foreach (var igeny in igenyek)
            {
                foreach (var auto in autok)
                {
                    if (igeny.Indulas == auto.Indulas && igeny.Cel == auto.Cel && igeny.Szemelyek == auto.Ferohely)
                    {
                        Console.WriteLine($"{igeny.Azonosito} => {auto.RendSzam}");
                    }
                }
                
            }
        }

        private void F06()
        {
            StreamWriter sw = new StreamWriter("utasuzenetek.txt", false);
            foreach (var igeny in igenyek)
            {
                if (autok.Select(a => a.Cel).Contains(igeny.Cel) && autok.Select(a => a.Indulas).Contains(igeny.Indulas) && autok.Select(a => a.Ferohely).Contains(igeny.Szemelyek))
                {          
                    foreach (var auto in autok)
                    {
                        if (igeny.Indulas == auto.Indulas && igeny.Cel == auto.Cel && igeny.Szemelyek == auto.Ferohely)
                        {
                            Console.WriteLine($"{igeny.Azonosito}: Rendszám: {auto.RendSzam}, Telefonszám: {auto.TelefonSzam}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{igeny.Azonosito}: Sajnos nem sikerültautót találni");
                }

            }
        }
    }
}
