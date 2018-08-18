using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CardGame_Assignment
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public int[] Cards = new int[3];
        public int Score = 0;
        public Random RandomGenerator = new Random();
        int PNewScore = 0;
        int CNewScore = 0;
        int PScore = 0;
        int CScore = 0;

        public MainPage()

        {
           // Windows.UI.ViewManagement.ApplicationView.PreferredLaunchViewSize = new Size(1000, 800);
           // Windows.UI.ViewManagement.ApplicationView.PreferredLaunchWindowingMode = Windows.UI.ViewManagement.ApplicationViewWindowingMode.PreferredLaunchViewSize;
            this.InitializeComponent();
            SetupGame();
        }

        private void SetupGame()
        {
            Start.IsEnabled = true;
            PickCard1.IsEnabled = false;
            PickCard2.IsEnabled = false;
            PickCard3.IsEnabled = false;
            Shuffle.IsEnabled = false;

            Card1.DisplayCard(1);
            Card2.DisplayCard(1);
            Card3.DisplayCard(1);
            PlayerCard.DisplayCard(1);
            CPUCard.DisplayCard(1);

            StatusMessage.Text = "Press Start!";

        }

        private void Shuffle_Click(object sender, RoutedEventArgs e)
        {
            Shuffle.IsEnabled = false;

            StatusMessage.Text = "Choose a card";

            for (int i = 0; i < Cards.Length; i++)
            {
                int CardValue = RandomGenerator.Next(1, 14);
                Cards[i] = CardValue;
            }

            while (Cards[0] == Cards[1] || Cards[0] == Cards[2] || Cards[1] == Cards[2])
            {
                for (int i = 0; i < Cards.Length; i++)
                {
                    int CardValue = RandomGenerator.Next(2, 14);
                    Cards[i] = CardValue;
                }
            }

            Card1.DisplayCard(Cards[0]);
            Card2.DisplayCard(Cards[1]);
            Card3.DisplayCard(Cards[2]);
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
  
            StatusMessage.Text = "Choose a card";
            
            PickCard1.IsEnabled = true;
            PickCard2.IsEnabled = true;
            PickCard3.IsEnabled = true;
            Shuffle.IsEnabled = true;
            
            for (int i = 0; i < Cards.Length; i++)
            {
                int CardValue = RandomGenerator.Next(2, 14);
                Cards[i] = CardValue;
            }

            while (Cards[0] == Cards[1] || Cards[0] == Cards[2] || Cards[1] == Cards[2])
            {

                for (int i = 0; i < Cards.Length; i++)
                {
                    int CardValue = RandomGenerator.Next(2, 14);
                    Cards[i] = CardValue;
                }
            }

            Card1.DisplayCard(Cards[0]);
            Card2.DisplayCard(Cards[1]);
            Card3.DisplayCard(Cards[2]);

        }

        private void PickCard1_Click(object sender, RoutedEventArgs e)
        {
    
            PickCard1.IsEnabled = false;
            PickCard2.IsEnabled = false;
            PickCard3.IsEnabled = false;
            Shuffle.IsEnabled = false;

            PlayerCard.DisplayCard(Cards[0]);

            Card1.DisplayCard(14);
            Card2.DisplayCard(14);
            Card3.DisplayCard(14);

            int PlayerIndex = Cards[0];

            GameRules(PlayerIndex);
        }

        private void PickCard2_Click(object sender, RoutedEventArgs e)
        {
            PickCard1.IsEnabled = false;
            PickCard2.IsEnabled = false;
            PickCard3.IsEnabled = false;
            Shuffle.IsEnabled = false;

            PlayerCard.DisplayCard(Cards[1]);

            Card1.DisplayCard(14);
            Card2.DisplayCard(14);
            Card3.DisplayCard(14);

            int PlayerIndex = Cards[1];

            GameRules(PlayerIndex);
        }

        private void PickCard3_Click(object sender, RoutedEventArgs e)
        {

            PickCard1.IsEnabled = false;
            PickCard2.IsEnabled = false;
            PickCard3.IsEnabled = false;
            Shuffle.IsEnabled = false;

            PlayerCard.DisplayCard(Cards[2]);

            Card1.DisplayCard(14);
            Card2.DisplayCard(14);
            Card3.DisplayCard(14);

            int PlayerIndex = Cards[2];

            GameRules(PlayerIndex);
        }

        private void GameRules(int PlayerIndex)
        {

            string WinMessage = "";

            int ChosenCardIndex = PlayerIndex;

            int rand = RandomGenerator.Next(2, 14);

            while (ChosenCardIndex == rand)
            {
                rand = RandomGenerator.Next(2, 14);
            }
            CPUCard.DisplayCard(rand);

            int OpponentCardIndex = rand;

            if (ChosenCardIndex > OpponentCardIndex)
            {
                PNewScore = ((ChosenCardIndex + OpponentCardIndex) - 2) * 10;
                WinMessage = "Awesome! You won! You gained " + PNewScore + " points on your score!";
                PScore = PScore + PNewScore;
            }
            else
            {
                CNewScore = ((ChosenCardIndex + OpponentCardIndex) - 2) * 10; ;
                WinMessage = "Sorry, the opponent had the better card this time...";
                CScore = CScore + CNewScore;

            }

            Start.Content = "Play Again?";


            PlayerScore.Text = PScore.ToString();
            CPUScore.Text = CScore.ToString();
            StatusMessage.Text = WinMessage;
        }

        private void Card1_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Card2_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Card3_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
