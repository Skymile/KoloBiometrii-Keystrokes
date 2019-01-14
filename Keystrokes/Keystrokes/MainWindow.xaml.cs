using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

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

            this.Input.Text = "Apollo 11 was the spaceflight that landed the first two people on the Moon Armstrong became the first person to step onto the lunar surface six hours after landing on July 21 Aldrin joined him 20 minutes later";
            this.Output.Focus();
        }

        private void Save_Click(object sender, RoutedEventArgs e) => 
            this.Input.Text = string.Join("\n", this.keystrokes);

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            this.keystrokes.Clear();
            this.Output.Text = "";
        }

        public void A(int a) => a = 4;

        private bool IsCaps(Key key) =>
            key == Key.LeftShift || key == Key.RightShift || key == Key.CapsLock;

        private void Output_KeyDown(object sender, KeyEventArgs e)
        {
            if (IsCaps(e.Key))
                InternalKeyDown(ref this.ShiftKey);
            else
                InternalKeyDown(ref this.NormalKey);
        }
        
        private static void InternalKeyDown(ref (bool isReleased, int dwellTime, Stopwatch sw) key)
        {
            if (key.isReleased)
            {
                key.isReleased = false;
                key.dwellTime = (int)key.sw.ElapsedMilliseconds;
                key.sw = Stopwatch.StartNew();
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
            if (IsCaps(e.Key))
                InternalKeyUp(e, this.ShiftKey);
            else
                InternalKeyUp(e, this.NormalKey);
        }

        private void InternalKeyUp(KeyEventArgs e, (bool isReleased, int dwellTime, Stopwatch sw) key)
        {
            key.isReleased = true;

            this.keystrokes.Add(new Keystroke(
                key.dwellTime,
                (int)key.sw.ElapsedMilliseconds,
                KeyToString(e.Key))
            );

            key.sw = Stopwatch.StartNew();
        }

        private (bool isReleased, int dwellTime, Stopwatch sw) NormalKey = (false, 0, Stopwatch.StartNew());
        private (bool isReleased, int dwellTime, Stopwatch sw) ShiftKey  = (false, 0, Stopwatch.StartNew());

        private List<Keystroke> keystrokes = new List<Keystroke>();
    }
}
