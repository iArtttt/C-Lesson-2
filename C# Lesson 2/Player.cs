using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Less_3
{
    internal class Player
    {
        public List<Card> Hand { get; private set; }

        public Player() 
        {
            Hand = new List<Card>();
        }

        public void TakingCard(Deck cards)
        {
            if (cards.Cards.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("В колоде больше нет карт!");
                Console.ResetColor();
                return;
            }
            Hand.Add(cards.GiveCard());
        }
        public int PlayerPoints()
        {
            int PlayerPoints = 0;

            foreach (Card card in Hand)
            {
                PlayerPoints += (int)card.Name;
            }
            return PlayerPoints;
        }
        public void ShowAllPlayersCard()
        {
            Console.WriteLine();

            for (int i = 0; i < Hand.Count; i++)
            {
                Deck.CardPrint(Hand[i]);
                Console.Write($"\t{(int)Hand[i].Name} очков\n");
            }
            Console.WriteLine($"=====[ Всего {PlayerPoints()} очков ]=====");

        }

    }
}
