using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Less_3
{
    internal class Deck
    {
        public List<Card> Cards { get; private set; }

        public Deck() => CardCreate();

        private void CardCreate()
        {
            Cards = new List<Card>();
            var name = Enum.GetValues<CardName_Points>();
            var suit = Enum.GetValues<CardSuit>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Cards.Add(new Card(name[j] , suit[i]));
                }
            }
            AllCardToSort();
        }

        public void SearchOfSpadesPosition()
        {
            Console.WriteLine();
            for (int i = 0; i < Cards.Count; i++)
            {
                if (Cards[i].Suit == CardSuit.Пик)
                    Console.WriteLine($"{Cards[i].Name} {Cards[i].Suit} на позиции \t[ {i} ]");
            }
        }

        public void AllSpadesToBegin()
        {
            int insertToPosition = 0;
            Card temp;
            for (int i = 0; i < Cards.Count; i++)
            {
                if (i == insertToPosition && Cards[i].Suit == CardSuit.Пик)
                {
                    insertToPosition++;
                    continue;
                }
                if (Cards[i].Suit == CardSuit.Пик)
                {
                    temp = Cards[i];
                    Cards[i] = Cards[insertToPosition];
                    Cards[insertToPosition] = temp;
                    insertToPosition++;
                }
            }

        }

        public void SearchOfAces()
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                if (Cards[i].Name == CardName_Points.Туз)
                    Console.WriteLine($"{Cards[i].Name} {Cards[i].Suit} on position \t[ {i} ]");

            }
        }

        public void AllCardToSort()
        {
            Cards = Cards.OrderBy(c => c.Suit).ThenBy(c => (int)c.Name switch
            {
                11 => 0,
                4 => 1,
                3 => 2,
                2 => 3,
                10 => 4,
                9 => 5,
                8 => 6,
                7 => 7,
                6 => 8,
                _ => 0
            }).ToList();
        }
        public void CardsShuffle()
        {
            Card temp;
            Random random = new Random();

            int numberFromRandom;
            int amountOfMixing = 0;
            int totalAmountOfMixing = random.Next(2, 6);

            do
            {
                for (int i = 0; i < Cards.Count; i++)
                {
                    numberFromRandom = random.Next(0, Cards.Count);
                    temp = Cards[numberFromRandom];
                    Cards[numberFromRandom] = Cards[i];
                    Cards[i] = temp;
                }
            } while (amountOfMixing++ < totalAmountOfMixing);
        }

        public Card GiveCard()
        {
            Card toGive = Cards[0];
            Cards.RemoveAt(0);
            return toGive;
        }

        public void ShowAllCards()
        {
            foreach (var card in Cards)
            {
                CardPrint(card);
            }
        }
        public void ShowAllCardPosition()
        {
            Console.WriteLine();
            for (int i = 0; i < Cards.Count; i++)
            {
                CardPrint(Cards[i]);
                Console.Write($"\tна позиции ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" \t[ {i} ]\n");
                Console.ResetColor();
            }
        }
        private static ConsoleColor SetCardSuitColor(Card card)
        {
            return card.Suit switch
            {
                CardSuit.Чирва => Console.ForegroundColor = ConsoleColor.DarkRed,
                CardSuit.Бубна => Console.ForegroundColor = ConsoleColor.Red,
                CardSuit.Креста => Console.ForegroundColor = ConsoleColor.Blue,
                CardSuit.Пик => Console.ForegroundColor = ConsoleColor.DarkBlue,
                _ => Console.ForegroundColor = ConsoleColor.Gray,
            };
        }
        private static ConsoleColor SetCardNameColor(Card card)
        {
            return card.Name switch
            {
                CardName_Points.Туз => Console.ForegroundColor = ConsoleColor.Yellow,
                CardName_Points.Король => Console.ForegroundColor = ConsoleColor.Yellow,
                CardName_Points.Дама => Console.ForegroundColor = ConsoleColor.Yellow,
                CardName_Points.Валет => Console.ForegroundColor = ConsoleColor.Yellow,
                _ => Console.ForegroundColor = ConsoleColor.DarkYellow,
            };
        }
        public static void CardPrint(Card card)
        {
            Console.ForegroundColor = SetCardNameColor(card);
            Console.Write($"{card.Name} ");
            Console.ForegroundColor = SetCardSuitColor(card);
            Console.Write($"\t{card.Suit} ");
            Console.ResetColor();
        }

    }
}