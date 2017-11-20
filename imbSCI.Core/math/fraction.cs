namespace imbSCI.Core.math
{
    using System;

    /// <summary>
    /// Expended version of Microsoft example code for Operator
    /// https://docs.microsoft.com/en-us/dotnet/articles/csharp/language-reference/keywords/operator
    /// </summary>
    public class Fraction
    {
        int num, den;
        public Fraction(int num, int den)
        {
            this.num = num;
            this.den = den;
        }

        // overload operator +
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.num * b.den + b.num * a.den,
               a.den * b.den);
        }

        // overload operator *
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.num * b.num, a.den * b.den);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            throw new NotImplementedException();
            return new Fraction(a.num * b.den + b.num * a.den,
               a.den * b.den);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            throw new NotImplementedException();
            return new Fraction(a.num * b.den + b.num * a.den,
               a.den * b.den);
        }

        public static implicit operator String(Fraction f)
        {
            return f.ToString();
        }

        public static implicit operator Fraction(String s)
        {
            var sl = s.Split('/');
            Int32 num = Convert.ToInt32(sl[0].Trim());
            Int32 den = Convert.ToInt32(sl[1].Trim());
            Fraction f = new Fraction(num, den);
            return f.ToString();
        }

        public override string ToString()
        {
            return den + " / " + num;
        }

        public static implicit operator double(Fraction f)
        {
            return (double)f.num / f.den;
        }

        public static implicit operator decimal(Fraction f)
        {
            return (decimal)f.num / f.den;
        }

        public static implicit operator float(Fraction f)
        {
            return (float)f.num / f.den;
        }
    }

  
}
