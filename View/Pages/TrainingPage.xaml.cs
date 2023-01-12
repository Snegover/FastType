using FastType_Proskurin_Sideleva.AppData;
using FastType_Proskurin_Sideleva.View.Windows;
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
using System.Windows.Threading;

namespace FastType_Proskurin_Sideleva.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для TrainingPage.xaml
    /// </summary>
    public partial class TrainingPage : Page
    {
        DispatcherTimer timer = null;
        int temp = 0;

        public TrainingPage()
        {
            InitializeComponent();

            //таймер
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;

            // автофокус на TextBox
            InputLineTb.Focus();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ++temp;
        }

        private void InputLineTb_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            foreach (StackPanel sp in KeyboardGrid.Children)
            {
                foreach (Button button in sp.Children)
                {
                    if (button.Name == e.Key.ToString())
                    {
                        button.BorderThickness = new Thickness(0);
                    }
                }
            }
        }

        private void InputLineTb_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            foreach (StackPanel sp in KeyboardGrid.Children)
            {
                foreach (Button button in sp.Children)
                {
                    if (button.Name == e.Key.ToString())
                    {
                        button.BorderThickness = new Thickness(5);
                    }

                    if (e.Key == Key.Space)
                    {
                        ++InputLineTb.CaretIndex;
                    }
                }
            }

            if (e.Key == Key.Tab || e.Key == Key.Right || e.Key == Key.Left || e.Key == Key.Back)
            {
                e.Handled = true;
            }
        }

        private void InputLineTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                timer.Start();

                if (e.Text == InputLineTb.Text.Substring(InputLineTb.CaretIndex, 1))
                {
                    FakeInputLineTb.Text = InputLineTb.Text.Substring(0, ++InputLineTb.CaretIndex);
                }
            }
            catch
            {
                timer.Stop();

                NavigationService.Navigate(new TrainerRezultPage(TypeQuality.CalculateSpeed(InputLineTb, temp)));
            }

        }
    }
}
