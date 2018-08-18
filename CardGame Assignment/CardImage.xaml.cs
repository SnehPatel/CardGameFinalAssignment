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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CardGame_Assignment
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CardImage : Page
    {
        private const int NumCards = 14;
        public Image[] Cards = new Image[NumCards];


        public CardImage()
        {
            this.InitializeComponent();
            CardArray();
        }

        private void CardArray()
        {
            Cards[0] = Back;
            Cards[1] = Ace;
            Cards[2] = TwoD;
            Cards[3] = ThreeD;
            Cards[4] = FourD;
            Cards[5] = FiveD;
            Cards[6] = SixD;
            Cards[7] = SevenD;
            Cards[8] = EightD;
            Cards[9] = NineD;
            Cards[10] = TenD;
            Cards[11] = JackD;
            Cards[12] = QueenD;
            Cards[13] = KingD;
        }


        public void DisplayCard(int CardID)
        {
            CardID = CardID - 1;

            for (int i = 0; i < NumCards; i++)
            {
                if (i == CardID)
                {
                    Cards[i].Visibility = Visibility.Visible;
                }
                else
                {
                    Cards[i].Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
