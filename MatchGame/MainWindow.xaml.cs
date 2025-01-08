using System;
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

namespace MatchGame
{
    using System.Windows.Threading;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        int tenthsOfSecondEllapsed;
        int matchesFound;
        public MainWindow()
        {
            InitializeComponent();

            dispatcherTimer.Interval = TimeSpan.FromSeconds(.1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;

            SetUpGame();
            
        }
        
        private void DispatcherTimer_Tick(object? sender, EventArgs e)
        {
            tenthsOfSecondEllapsed++;
            timerTextBlock.Text = (tenthsOfSecondEllapsed / 10F).ToString("0.0s");
            if(matchesFound == 8)
            {
                dispatcherTimer.Stop();
                timerTextBlock.Text = timerTextBlock.Text + " - Play Again?";
            }
        }

        private void SetUpGame()
        {
            matchesFound = 0;
            List<string> animalEmoji = new()
            {
                "🙊", "🙊",
                "🐔", "🐔",
                "🐪", "🐪",
                "🐍", "🐍",
                "🐟", "🐟",
                "🐞", "🐞",
                "🦊", "🦊",
                "🦜", "🦜"
            };

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                textBlock.Visibility = Visibility.Visible;
                if (textBlock.Text != timerTextBlock.Text)
                {
                    Random random = new();

                    int index = random.Next(animalEmoji.Count);
                    string nextEmoji = animalEmoji[index];
                    textBlock.Text = nextEmoji;
                    animalEmoji.RemoveAt(index);
                }
            }

            dispatcherTimer.Start();
        }

        TextBlock lastTB;
        bool firstClick = false;
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock currentTB = sender as TextBlock;

            if (firstClick == false)
            {
                lastTB = currentTB;
                firstClick = true;
                currentTB.Visibility = Visibility.Hidden;
            }
            else if (lastTB.Text == currentTB.Text)
            {
                firstClick = false;
                currentTB.Visibility = Visibility.Hidden;
                matchesFound++;
            }
            else
            {
                lastTB.Visibility = Visibility.Visible;
                firstClick = false;
            }
        }
        
        private void timerTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
                tenthsOfSecondEllapsed = 0;
            }

        }
    }
}