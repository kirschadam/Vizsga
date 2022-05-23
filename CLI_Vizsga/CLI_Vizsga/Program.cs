using System;

namespace CLI_Vizsga
{
    public class Program
    {
        static void Main()
        {
            int a = -1, b = -1;
            do
            {
                Console.WriteLine("Adja meg a téglalap 'a' és 'b' oldalát!");
                if (int.TryParse(Console.ReadLine(), out a) && int.TryParse(Console.ReadLine(), out b))
                {
                    if (a > 0 && b > 0)
                    {
                        Console.WriteLine(Atlo(a, b));
                        Console.WriteLine(Kerulet(a, b));
                        Console.WriteLine(Terulet(a, b));
                    }
                    else Console.WriteLine("Valamelyik érték negatív!");
                }
                else Console.WriteLine("Valamelyik érték nem konvertálható!");
            } while (a <= 0 || b <= 0);
            Console.ReadKey();
        }

        public static int Terulet(int a, int b)
        {
            return a*b;
        }

        public static int Kerulet(int a, int b)
        {
            return 2 * (a + b);
        }

        public static double Atlo(int a, int b)
        {
            return Math.Sqrt(a * a + b * b);
        }
    }
}
