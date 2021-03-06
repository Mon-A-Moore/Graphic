using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicLibrary
{
    public class SimpsonCalculator1 : ICalculator
    {
        private readonly object sumLock = new object();

        public double Calculate(double a, double b, long n, Func<double, double> f)
        {
            if ((a < 0) | (b < 0)) throw new ArgumentException("a или b меньше допустимо значения");

            double h = (b - a) / n;
            double sum1 = 0;
            double sum2 = 0;

            for (var k = 1; k <= n; k++)
            {
                 var xk = a + k * h;
                 if (k <= n - 1)  
                 sum1 += f(xk);
                 var xk_1 = a + (k - 1) * h;
                 sum2 += f((xk + xk_1) / 2);
             }

            double result = h / 3d * (1d / 2d * f(a) + sum1 + 2 * sum2 + 1d / 2d * f(b));
            return result;

        }
    }
}
