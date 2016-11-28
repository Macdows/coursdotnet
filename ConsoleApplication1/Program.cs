using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice = "y";
            Fraction frac = new Fraction(100, 10);
            Console.WriteLine(frac.ToFloat());

            Fraction froc = new Fraction("153.65/485.52");
            Console.WriteLine(froc.ToFloat());

            FractionDAO doa = new FractionDAO();

            while (choice == "y")
            {
                Console.WriteLine("Type a fraction");
                string userInput = Console.ReadLine();
                Fraction userFraction = new Fraction(userInput);
                Console.WriteLine(userFraction.ToFloat());

                doa.Save(userFraction);

                Console.WriteLine("Try again ? (y/n)");
                choice = Console.ReadLine();
            }

            Console.WriteLine("Load file ?");
            string userChoice = Console.ReadLine();
            if (userChoice == "y")
            {
                doa.Load();
            }
            Console.ReadLine();
        }
    }
}
