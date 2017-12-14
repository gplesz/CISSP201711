using System;

namespace OOPDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // var cegesBankszmla = new Bankszamla("Kerékgyártás KFT");

            // System.Console.WriteLine(cegesBankszmla.Nev);
            // cegesBankszmla.Jovairas(5000);
            // cegesBankszmla.Terheles(2000);
            // cegesBankszmla.Terheles(4000);

            var kamatozoBankszmla = new KamatozoBankszamla("Kerékgyártás KFT");

            System.Console.WriteLine(kamatozoBankszmla.Nev);
            kamatozoBankszmla.Jovairas(5000);
            kamatozoBankszmla.Terheles(2000);
            kamatozoBankszmla.Terheles(4000);

        }
    }

    public class Bankszamla
    {
        private string nev;

        public Bankszamla(string nev)
        {
            this.nev = nev;
        }

        public string Nev { get {return this.nev;} }

        private int egyenleg;
        public int Egyenleg { get {return this.egyenleg;} }

        public void Terheles(int osszeg)
        {
            if (osszeg < 0)
            {
                throw new Exception("terhelni csak pozitív számot lehet");
            }

            if (Egyenleg<osszeg)
            {
                throw new Exception($"a terhelendő összeg {osszeg} nagyobb, mint a rendelkezésre álló összeg {egyenleg}");
            }

            egyenleg = egyenleg - osszeg;
            System.Console.WriteLine($"{osszeg} terhelése megtörtént, új egyenleg: {egyenleg}");
        }

        public void Jovairas(int osszeg)
        {
            if (osszeg < 0)
            {
                throw new Exception("jovairni csak pozitív számot lehet");
            }

            egyenleg = egyenleg + osszeg;
            System.Console.WriteLine($"{osszeg} jóváírása megtörtént, új egyenleg: {egyenleg}");
        }
        


    }

    public class KamatozoBankszamla : Bankszamla
    { //csak a kamatozással kell foglalkoznom, a Bankszamla osztály már hozza az egyenleg/jóváírás/terhelés tulajdonságokat
        public KamatozoBankszamla(string nev) : base(nev)
        { }
    }

}
