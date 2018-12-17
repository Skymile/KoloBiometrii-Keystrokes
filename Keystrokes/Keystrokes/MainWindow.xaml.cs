using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Keystrokes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Input.Text = "Apollo 11 was the spaceflight that landed the first two people on the Moon Armstrong became the first person to step onto the lunar surface six hours after landing on July 21 Aldrin joined him about 20 minutes later";
            this.Output.Focus();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.Input.Text = string.Join("\n", this.keystrokes);
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Output_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.isReleased)
            {
                this.isReleased = false;
                this.dwellTime = (int)this.sw.ElapsedMilliseconds;
                this.sw = Stopwatch.StartNew();
            }
        }

        private static string KeyToString(Key key)
        {
            switch (key)
            {
                case var x when x >= Key.A && x <= Key.Z:
                    return ((char)(x - Key.A + 'A')).ToString();

                case var x when x >= Key.D0 && x <= Key.D9:
                    return ((char)(x - Key.D0 + '0')).ToString();

                case Key.LeftShift:
                    return "LShift";

                case Key.RightShift:
                    return "RShift";

                case Key.CapsLock:
                    return "CapsLock";

                default: return "Undefined";
            }
        }

        private void Output_KeyUp(object sender, KeyEventArgs e)
        {
            this.isReleased = true;

            this.keystrokes.Add(new Keystroke(
                this.dwellTime, 
                (int)this.sw.ElapsedMilliseconds, 
                KeyToString(e.Key))
            );

            this.sw = Stopwatch.StartNew();
        }

        private bool isReleased = true;
        private int dwellTime = 0;

        private List<Keystroke> keystrokes = new List<Keystroke>();
        private Stopwatch sw = Stopwatch.StartNew();
    }
}
