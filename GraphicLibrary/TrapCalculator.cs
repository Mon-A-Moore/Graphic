using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLibrary
{
    public class TrapCalculator : ICalculator
    {
        public double Calculate(double a, double b, long n, Func<double, double> f)
        {
            if ((a < 0) | (b < 0)) throw new ArgumentException("a или b меньше допустимо значения");
            
            double h = (b - a) / n;

            double sum = 0;
            for (int i = 1; i < n; i++)
            {
                sum += f(a + h * i);
            }

            sum += (f(a) + f(b)) / 2;

            return sum * h;

        }
    }
}