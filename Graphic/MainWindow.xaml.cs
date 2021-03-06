using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GraphicLibrary;
using OxyPlot;

namespace Graphic
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btCalculate_Click(object sender, RoutedEventArgs e)
        {
            DateTime StartTime;
            StartTime = DateTime.Now;
            var time = Calculate();
            DateTime EndTime = DateTime.Now;
            tbTime.Text = Convert.ToString(EndTime - StartTime);
            DrawGraph(time);

        }

         private void DrawGraph(ICollection<(double Time, int PointCount)> times)
        {
            var model = DataContext as MainViewModel;
            model.Points.Clear();
            graph.InvalidatePlot(true);

            foreach (var (time, count) in times)
            {
                model.Points.Add(new DataPoint(count, time));
            }

            graph.InvalidatePlot(true);
        }

        private void ClearGraph()
        {
            MainViewModel model = DataContext as MainViewModel;
            model.Points.Clear();
            graph.InvalidatePlot(true);
        }

        private ICollection<(double Time, int PointCount)> Calculate()
        {
            double a = Convert.ToDouble(tbLowerBound.Text);
            double b = Convert.ToDouble(tbUpperBound.Text);
            long n = Convert.ToInt64(tbN.Text);

            ICalculator calculator = GetCalculator();
            var time = new List<(double, int)>();
           
            double result = 0.0;
            result = calculator.Calculate(a, b, n, x => 35 * x - Math.Log(10 * x) + 2);
            for (var i = 0; i < n; i +=10000)
            {
                var timeStart = DateTime.Now;
                calculator.Calculate(a, b, i, x => 35 * x - Math.Log(10 * x) + 2);
                var timeStop = DateTime.Now;
                time.Add(((timeStop - timeStart).TotalMilliseconds, i));
            }

            tbResult.Text = Convert.ToString(result);
            return time;
        }

        private ICalculator GetCalculator()
        {
            switch (cbmMethod.SelectedIndex)
            {
                case 0:
                    return new RectangleCalculator1();
                    break;
                case 1:
                    return new TrapCalculator1();
                    break;
                case 2:
                    return new SimpsonCalculator1(); 
                    break;
                case 3:
                    return new RectangleCalculator();
                    break;
                case 4:
                    return new TrapCalculator();
                    break;
                case 5:
                    return new SimpsonCalculator();
                    break;
                default:
                    return new RectangleCalculator();
                    break;
            }
        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            ClearGraph();
        }


    }
}
