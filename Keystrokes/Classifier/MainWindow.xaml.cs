using System.Collections.Generic;
using System.IO;
using System.Windows;
using Keystrokes;

namespace Classifier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Samples = GetSamples_1(
                Directory.GetCurrentDirectory(),
                "*.txt"
            );
            ;
        }

        private static List<(int Id, List<Keystroke>)> GetSamples_1(
                string directory,
                string pattern
            )
        {
            var samples = new List<(int Id, List<Keystroke> Keystrokes)>();

            foreach (string file in Directory.GetFiles(directory, pattern))
            {
                int Id = int.Parse(
                    Path.GetFileNameWithoutExtension(file)
                        .Substring(1, 2)
                );
                var Keystrokes = new List<Keystroke>();

                foreach (string line in File.ReadLines(file))
                    if (!string.IsNullOrWhiteSpace(line))
                        Keystrokes.Add(Keystroke.FromString(line));

                samples.Add((Id, Keystrokes));
            }

            return samples;
        }

        private List<(int Id, List<Keystroke> Keystrokes)> Samples;
    }
}
