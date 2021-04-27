using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GraphicLibrary;


namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void RectangleCalculator_Right()
        {
            //arrange
            double expected=174591.027;
            int a = 1;
            int b = 100;
            int n = 100000;
            RectangleCalculator rectangleCalculator = new RectangleCalculator();
            Func<double, double> f = x => 35 * x - Math.Log(10 * x) + 2;

            //act
            double actual = rectangleCalculator.Calculate(a, b, n, f);
            //accert
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void TrapCalculator_Right()
        {
            //arrange
            double expected = 174591.027;
            int a = 1;
            int b = 100;
            int n = 100000;
            TrapCalculator TrapCalculator = new TrapCalculator();
            Func<double, double> f = x => 35 * x - Math.Log(10 * x) + 2;

            //act
            double actual = TrapCalculator.Calculate(a, b, n, f);
            //accert
            Assert.AreEqual(expected, actual,0.001);
        }

        [TestMethod]
        public void SimpsonCalculator_Right()
        {
            //arrange
            double expected = 174591.027;
            int a = 1;
            int b = 100;
            int n = 100000;
            SimpsonCalculator SimpsonCalculator = new SimpsonCalculator();
            Func<double, double> f = x => 35 * x - Math.Log(10 * x) + 2;

            //act
            double actual = SimpsonCalculator.Calculate(a, b, n, f);
            //accert
            Assert.AreEqual(expected, actual,0.001);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void Error_if_a_and_b_below_zero()
        {
            double expected = 174591.027;
            int a = -1;
            int b = -100;
            int n = 100;
            Func<double, double> f = x => 35 * x - Math.Log(10 * x) + 2;

            RectangleCalculator RectangleCalculator = new RectangleCalculator();
            TrapCalculator TrapCalculator = new TrapCalculator();
            SimpsonCalculator SimpsonCalculator = new SimpsonCalculator();
            
            //act
            double actual1 = RectangleCalculator.Calculate(a, b, n, f);
            double actual2 = TrapCalculator.Calculate(a, b, n, f);
            double actual3 = SimpsonCalculator.Calculate(a, b, n, f);
        }

    }
}
