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

namespace EkzMobilki
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static Random rnd = new Random();
        public static string hardness = "";
        public static string answerTypeS = "";
        //public static int voprosCount = 0;
        public static TimeSpan trueAnswer = new TimeSpan(0, 0, 0);
        public static int allRight = 0;
        public static int allNotRight = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            notRightС.Content = allNotRight;
            RightС.Content = allRight;

            hardness = ComboBox.Text;
            answerTypeS = AnswerTypeCombo.Text;
            notRight.Visibility = Visibility.Hidden;
            right.Visibility = Visibility.Hidden;
            notRightFormat.Visibility = Visibility.Hidden;

            if (hardness == "Детский")
            {
                //30 минут на 1 часть по 5 минут = 6
                var parts1 = rnd.Next(0, 6);
                var minutes1 = parts1 * 5;
                var ts1 = new TimeSpan(0, minutes1, 0);
                First.Content = $"{ts1.Hours}:{ts1.Minutes}";

                var parts2 = rnd.Next(0, 6);
                var minutes2 = parts2 * 5;
                var ts2 = new TimeSpan(0, minutes2, 0);
                Second.Content = $"{ts2.Hours}:{ts2.Minutes}";

                trueAnswer = ts1 + ts2;
            }
            //voprosCount = int.Parse(TextBox.Text);

            if (hardness == "Лёгкий")
            {
                //полтора часа на 1 часть по 5 минут = 18
                var parts1 = rnd.Next(0, 36);
                var minutes1 = parts1 * 5;
                var ts1 = new TimeSpan(0, minutes1, 0);
                First.Content = $"{ts1.Hours}:{ts1.Minutes}";

                var parts2 = rnd.Next(0, 36);
                var minutes2 = parts2 * 5;
                var ts2 = new TimeSpan(0, minutes2, 0);
                Second.Content = $"{ts2.Hours}:{ts2.Minutes}";

                trueAnswer = ts1 + ts2;
            }

            if (hardness == "Средний")
            {
                //4 часа на 1 часть по 5 минут = 48
                var parts1 = rnd.Next(0, 96);
                var minutes1 = parts1 * 5;
                var ts1 = new TimeSpan(0, minutes1, 0);
                First.Content = $"{ts1.Hours}:{ts1.Minutes}";

                var parts2 = rnd.Next(0, 96);
                var minutes2 = parts2 * 5;
                var ts2 = new TimeSpan(0, minutes2, 0);
                Second.Content = $"{ts2.Hours}:{ts2.Minutes}";

                trueAnswer = ts1 + ts2;
            }

            if (hardness == "Сложный")
            {
                //24 часа * 12 частей по 5 минут = 288
                var parts1 = rnd.Next(0, 288);
                var minutes1 = parts1 * 5;
                var ts1 = new TimeSpan(0, minutes1, 0);
                First.Content = $"{ts1.Hours}:{ts1.Minutes}";

                var parts2 = rnd.Next(0, 288);
                var minutes2 = parts2 * 5;
                var ts2 = new TimeSpan(0, minutes2, 0);
                Second.Content = $"{ts2.Hours}:{ts2.Minutes}";

                trueAnswer = ts1 + ts2;
            }

        }

        public static TimeSpan answerTS = new TimeSpan(0, 0, 0);
        public static string answerS = "";
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            notRightС.Content = allNotRight;
            RightС.Content = allRight;

            notRight.Visibility = Visibility.Hidden;
            right.Visibility = Visibility.Hidden;
            notRightFormat.Visibility = Visibility.Hidden;

            if (answerTypeS == "В минутах")
            {
                string Uanswer = Answer.Text;
                if (int.TryParse(Uanswer, out int i) == true)
                {
                    
                    answerS = Answer.Text;

                    if (int.Parse(answerS) == trueAnswer.Hours * 60 + trueAnswer.Minutes)
                    {
                        right.Visibility = Visibility.Visible;
                        allRight++;
                    }
                    else
                    {
                        notRight.Visibility = Visibility.Visible;
                        allNotRight++;
                    }
                }
                else
                {
                    notRightFormat.Visibility = Visibility.Visible;
                    allNotRight++;
                }
            }

            else
            {
                string Uanswer = Answer.Text;
                if (TimeSpan.TryParse(Uanswer, out TimeSpan t) == true)
                {
                    answerTS = TimeSpan.Parse(Answer.Text);



                    if (answerTS == trueAnswer)
                    {
                        right.Visibility = Visibility.Visible;
                        allRight++;
                    }
                    else
                    {
                        notRight.Visibility = Visibility.Visible;
                        allNotRight++;
                    }

                }
                else
                {
                    notRightFormat.Visibility = Visibility.Visible;
                    allNotRight++;
                }

            }
        }
    }
}

    