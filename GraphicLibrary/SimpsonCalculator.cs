using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLibrary
{
    public class SimpsonCalculator : ICalculator
    {
        private readonly object sumLock = new object();

        public double Calculate(double a, double b, long n, Func<double, double> f)
        {
            if ((a < 0)|(b<0)) throw new ArgumentException("a или b меньше допустимо значения");

            double h = (b - a) / n;
            double sum1 = 0;
            double sum2 = 0;

            Parallel.For(0, n, (k) =>
            {
                double xk = a + k * h;
                double xk_1 = a + (k - 1) * h;
                double buf = f((xk + xk_1) / 2);
                lock (sumLock)
                {
                    if (k <= n - 1)
                    {
                        sum1 += f(xk);
                    }
                    sum2 += buf;
                }
            });

            double result = h / 3d * (1d / 2d * f(a) + sum1 + 2 * sum2 + 1d / 2d * f(b));
            return result;

        }
    }
}
