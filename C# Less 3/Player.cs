using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Less_3
{
    internal class Player
    {
        public List<Card> Arm { get; private set; }

        public Player() 
        {
            Arm = new List<Card>();
        }

        public void TakingCard(List<Card> cards)
        {
            if (cards.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("В колоде больше нет карт!");
                Console.ResetColor();
                return;
            }
            Arm.Add(cards[0]);
            cards.Remove(cards[0]);
        }
        public int PlayerPoints()
        {
            int PlayerPoints = 0;

            foreach (Card card in Arm)
            {
                PlayerPoints += card.Points;
            }
            return PlayerPoints;
        }
        public void ShowAllPlayersCard()
        {
            Console.WriteLine();

            for (int i = 0; i < Arm.Count; i++)
            {
                Deck.CardPrint(Arm[i]);
                Console.Write($"\t{Arm[i].Points} очков\n");
            }
            Console.WriteLine($"=====[ Всего {PlayerPoints()} очков ]=====");

        }

    }
}
