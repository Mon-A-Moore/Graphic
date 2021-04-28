using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLibrary
{
    public class RectangleCalculator1 : ICalculator
    {
        private readonly object sumLock = new object();

        public double Calculate(double a, double b, long n, Func<double, double> f)
        {
            if ((a < 0) | (b < 0)) throw new ArgumentException("a или b меньше допустимо значения");

            double h = (b - a) / n;
            a += h * 0.5;

            double sum = 0;

            Parallel.For(0, n, (i) =>
            {
                double buf = f(a + h * i);
                lock (sumLock)
                {
                    sum += buf;
                }
            });

            return sum * h;

        }
    }


}
