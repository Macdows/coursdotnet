using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Library
{
    public class Fraction
    {
        private float numerateur;
        private float denominateur;

        public Fraction(float num, float den)
        {
            den = den != 0 ? den : 1;

            float gcd = GCD(num, den);
            this.numerateur = num / gcd;
            this.denominateur = den / gcd;
        }

        public Fraction(string input)
        {
            string pattern = @"(-?\d+)[\.,]?(\d{1,2})?\/(-?\d+)[\.,]?(\d{1,2})?";
            Regex r = new Regex(pattern);
            Match m = r.Match(input);
            if (m.Success)
            {
                if (m.Groups[2] != null && string.IsNullOrWhiteSpace(m.Groups[2].Value))
                {
                    string str_num = m.Groups[1].Value + "." + m.Groups[2].Value;
                    this.numerateur = float.Parse(str_num, System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                {
                    this.numerateur = Convert.ToSingle(m.Groups[1].Value);
                }

                if (m.Groups[4] != null && string.IsNullOrWhiteSpace(m.Groups[4].Value))
                {
                    string str_den = m.Groups[3].Value + "." + m.Groups[4].Value;
                    this.denominateur = float.Parse(str_den, System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                {
                    if (Convert.ToSingle(m.Groups[3].Value) != 0)
                    {
                        this.denominateur = Convert.ToSingle(m.Groups[3].Value);
                    }
                    else
                    {
                        this.denominateur = 1;
                    }
                }
            }
            else
            {
                this.numerateur = 1;
                this.denominateur = 1;
            }
        }

        public float ToFloat()
        {
            return this.numerateur / this.denominateur;
        }

        private float GCD(float a, float b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
        
        public override string ToString()
        {
            return Convert.ToString(this.numerateur) + "/" + Convert.ToString(this.denominateur);
        }
    }

    public class FractionDAO : List<Fraction>
    {
        private string filePath = @"C:\Users\maloc\Desktop\parterre.txt";

        public bool Save(Fraction fraction)
        {
            File.AppendAllLines(filePath, new string[] { fraction.ToString() } );
            return true;
        }

        public bool Load()
        {
            foreach (string line in File.ReadLines(filePath))
            {
                Console.WriteLine(line);
                Fraction frac = new Fraction(line);
                this.Add(frac);
            }
            return true;
        }
    }
}
