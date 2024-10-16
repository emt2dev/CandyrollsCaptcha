using System;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CandyrollsCaptcha
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> OneRArray = new List<string>
        {
            "cord", "bored", "torn", "laurie", "wired", "subscribe"
        };
        List<string> TwoRArray = new List<string>
        { "terrifying", "prearranged",
            "married", "reiterative", "garrulous", "aerator", "erroneously", "interred","carpenter", "terraformed"
        };
        List<string> GreaterRArray = new List<string>
        {
            "carriers", "barrier",
            "reverberate", "reverberated", "terrarium",
            "surrender", "horrors", "sorcerer", "rearranging", "errantry"
        };


        public int MaxValueAnswer = 3;
        public int SelectedAnswerValue = 0;
        public bool AlLEqualFlag = false;

        List<string> RandomChoices = new List<string>();

        public MainWindow()
        {
            Random random = new Random();
            Dictionary<int, int> selectedIndices = new Dictionary<int, int>();

            var oneR = random.Next(OneRArray.Count);
            selectedIndices.Add(1, oneR);

            var twoR = random.Next(TwoRArray.Count);
            selectedIndices.Add(2, twoR);

            var threeR = random.Next(GreaterRArray.Count);
            selectedIndices.Add(3, threeR);

            RandomChoices.Add(OneRArray[selectedIndices[1]]);
            RandomChoices.Add(TwoRArray[selectedIndices[2]]);
            RandomChoices.Add(GreaterRArray[selectedIndices[3]]);
            InitializeComponent();
            Items.ItemsSource = RandomChoices;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (Items.SelectedItem is not null)
            {
                var SelectedAnswer = Items.SelectedItem.ToString()!.ToLower();

                foreach (char item in SelectedAnswer)
                {
                    if (item == 'r')
                        SelectedAnswerValue++;
                }

                if (SelectedAnswerValue == MaxValueAnswer)
                    MessageBox.Show("You are correct!");
                else
                    MessageBox.Show("You are unable to login!");
            }
            else
            {
                MessageBox.Show("Must pick an answer");
            }
        }
    }
}