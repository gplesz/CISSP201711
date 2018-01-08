using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo
{
    public class Bankszamla
    {
        private string nev;

        public Bankszamla(string nev)
        {
            this.nev = nev;
        }

        public string Nev { get { return this.nev; } }

        private int egyenleg;
        public int Egyenleg { get { return this.egyenleg; } }

        public void Terheles(int osszeg)
        {
            if (osszeg < 0)
            {
                throw new Exception("terhelni csak pozitív számot lehet");
            }

            if (Egyenleg < osszeg)
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
}
