using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLibrary
{
    public class TrapCalculator1 : ICalculator
    {
        private readonly object sumLock = new object();

        public double Calculate(double a, double b, long n, Func<double, double> f)
        {
            if ((a < 0) | (b < 0)) throw new ArgumentException("a или b меньше допустимо значения");

            double h = (b - a) / n;
            double sum = 0;

            Parallel.For(1, n, (i) =>
            {
                double buf = f(a + h * i);
                lock (sumLock)
                {
                    sum += buf;
                }
            });

            sum += (f(a) + f(b)) / 2;

            return sum * h;

        }
    }
}